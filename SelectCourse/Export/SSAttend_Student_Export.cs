using System;
using System.Collections.Generic;
using System.Xml;
using FISCA.UDT;
using FISCA.Data;
using System.Data;
using FISCA.Presentation.Controls;
using DevComponents.Editors;
using System.Linq;

namespace SelectCourse_JH.Export
{
    public partial class SSAttend_Student_Export : EMBA.Export.ExportProxyForm
    {
        private int DefaultSchoolYear;
        private int DefaultSemester;
        private int CurrentSchoolYear;
        private int CurrentSemester;

        private AccessHelper Access;

        public SSAttend_Student_Export()
        {
            InitializeComponent();

            Access = new AccessHelper();

            InitCurrentSchoolYearSemester();
            InitDefaultSchoolYearSemester();

            InitializeData();

            this.Load += new EventHandler(Subject_Export_Load);
        }

        private void Subject_Export_Load(object sender, EventArgs e)
        {
            this.InitIdentity();
        }

        private void InitCurrentSchoolYearSemester()
        {
            List<UDT.OpeningTime> openingTimes = Access.Select<UDT.OpeningTime>();

            if (openingTimes == null || openingTimes.Count == 0)
            {
                MsgBox.Show("請先設定選課時間。");
                return;
            }

            this.CurrentSchoolYear = openingTimes[0].SchoolYear;
            this.CurrentSemester = openingTimes[0].Semester;
        }

        private void InitDefaultSchoolYearSemester()
        {
            if (!int.TryParse(K12.Data.School.DefaultSchoolYear, out this.DefaultSchoolYear) || !int.TryParse(K12.Data.School.DefaultSemester, out this.DefaultSemester))
            {
                MsgBox.Show("請先設定預設學年度學期。");
                return;
            }
        }

        private void InitIdentity()
        {
            List<UDT.Identity> identity_Records = Access.Select<UDT.Identity>();

            if (identity_Records.Count == 0)
            {
                return;
            }
            ComboItem comboItem1 = new ComboItem("");
            comboItem1.Tag = null;
            this.cboIdentity.Items.Add(comboItem1);

            //  所有學生
            ComboItem comboItem2 = new ComboItem("所有學生");
            comboItem2.Tag = null;
            this.cboIdentity.Items.Add(comboItem2);
            foreach (UDT.Identity record in identity_Records)
            {
                ComboItem item = new ComboItem(record.GradeYear + "年級");
                item.Tag = record;
                this.cboIdentity.Items.Add(item);
            }

            this.cboIdentity.SelectedItem = comboItem1;
        }

        private void InitializeData()
        {
            this.AutoSaveFile = true;
            this.AutoSaveLog = true;
            this.KeyField = "科目選課結果系統編號";
            this.InvisibleFields = new List<string>() { this.KeyField };
            this.ReplaceFields = null;
            this.Text = "匯出科目選課學生(" + this.CurrentSchoolYear + "學年度第" + this.CurrentSemester + "學期)";
            this.Tag = this.Text;
            this.QuerySQL = SetQueryString();
        }

        private string SetQueryString()
        {
            int school_year = this.CurrentSchoolYear;
            int semester = this.CurrentSemester;
            int grade_year = 0;
            int dept_id = 0;
            string querySQL = string.Empty;

            ComboItem item = this.cboIdentity.SelectedItem as ComboItem;
            UDT.Identity record = (item == null ? null : item.Tag as UDT.Identity);
            if (record != null)
            {
                grade_year = record.GradeYear;
                grade_year -= (this.CurrentSchoolYear - this.DefaultSchoolYear);
                dept_id = record.DeptID;
                querySQL = string.Format(@"select sa.uid as 科目選課結果系統編號, subject.school_year as 學年度, subject.semester as 學期, subject.subject_name as 科目名稱, subject.level as 級別, subject.credit as 學分, subject.type as 課程類別, class_name as 班級, seat_no as 座號, student_number as 學號, student.name as 姓名
from $ischool.course_selection.ss_attend as sa 
join $ischool.course_selection.subject as subject on sa.ref_subject_id=subject.uid 
join student on student.id=sa.ref_student_id 
left join class on class.id=student.ref_class_id 
where subject.school_year={0} and subject.semester={1} and class.grade_year={2} and case when student.ref_dept_id is NULL then class.ref_dept_id else student.ref_dept_id end = {3} and student.status in (1, 2)
order by subject.subject_name, subject.level, class_name, seat_no, student_number, student.name", school_year, semester, grade_year, dept_id);
            }
            else
            {
                if (item == null || string.IsNullOrEmpty(item.Text))
                {
                    querySQL = string.Format(@"select '' as 科目選課結果系統編號, '' as 學年度, '' as 學期, '' as 科目名稱, '' as 級別, '' as 學分, '' as 課程類別, '' as 班級, '' as 座號, '' as 學號, '' as 姓名");
                }
                else
                {
                    querySQL = string.Format(@"select sa.uid as 科目選課結果系統編號, subject.school_year as 學年度, subject.semester as 學期, subject.subject_name as 科目名稱, subject.level as 級別, subject.credit as 學分, subject.type as 課程類別, class_name as 班級, seat_no as 座號, student_number as 學號, student.name as 姓名
from $ischool.course_selection.ss_attend as sa 
join $ischool.course_selection.subject as subject on sa.ref_subject_id=subject.uid 
join student on student.id=sa.ref_student_id 
left join class on class.id=student.ref_class_id 
where subject.school_year={0} and subject.semester={1} and student.status in (1, 2)
order by subject.subject_name, subject.level, class_name, seat_no, student_number, student.name", school_year, semester);
                }
            }
            return querySQL;
        }

        private void cboIdentity_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.QuerySQL = this.SetQueryString();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }
    }
}
