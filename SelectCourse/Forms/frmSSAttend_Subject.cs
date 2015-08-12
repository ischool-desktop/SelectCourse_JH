using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using FISCA.UDT;
using DevComponents.Editors;
using FISCA.Data;

namespace SelectCourse_JH.Forms
{
    public partial class frmSSAttend_Subject : BaseForm
    {
        private AccessHelper Access;
        private QueryHelper queryHelper;
        private int DefaultSchoolYear;
        private int DefaultSemester;
        private int CurrentSchoolYear;
        private int CurrentSemester;

        public frmSSAttend_Subject()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmSSAttend_Subject_Load);
        }

        private void frmSSAttend_Subject_Load(object sender, EventArgs e)
        {
            Access = new AccessHelper();
            queryHelper = new QueryHelper();

            //InitSchoolYear();
            //InitSemester();
            InitIdentity();
            InitCurrentSchoolYearSemester();
            InitDefaultSchoolYearSemester();
        }

        private void InitCurrentSchoolYearSemester()
        {
            List<UDT.OpeningTime> openingTimes = Access.Select<UDT.OpeningTime>();

            if (openingTimes == null || openingTimes.Count == 0)
            {
                MsgBox.Show("請先設定選課時間。");
                return;
            }

            this.lblSchoolYear.Text = openingTimes[0].SchoolYear.ToString();
            this.lblSemester.Text = openingTimes[0].Semester.ToString();
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

        //private void InitSchoolYear()
        //{
        //    this.cboSchoolYear.Items.Clear();

        //    int school_year = DateTime.Today.Year - 1911;

        //    this.cboSchoolYear.Items.Add("");
        //    this.cboSchoolYear.Items.Add(school_year);
        //    this.cboSchoolYear.Items.Add(school_year + 1);
        //    this.cboSchoolYear.Items.Add(school_year + 2);
        //}

        //private void InitSemester()
        //{
        //    this.cboSemester.Items.Clear();

        //    this.cboSemester.Items.Add("");
        //    this.cboSemester.Items.Add("1");
        //    this.cboSemester.Items.Add("2");
        //}

        private void cboSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!chkSelectNoneStudent.Checked)
                InitSSAttend();
            else
                InitNonSSAttend();
        }

        private void cboSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!chkSelectNoneStudent.Checked)
                InitSSAttend();
            else
                InitNonSSAttend();
        }

        private void cboIdentity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!chkSelectNoneStudent.Checked)
                InitSSAttend();
            else
                InitNonSSAttend();
        }

        //查詢選課學生(所有學生)
        private void InitSSAttend_AllStudent()
        {
            this.dgvData.Rows.Clear();

            if (string.IsNullOrEmpty(this.lblSchoolYear.Text) || string.IsNullOrEmpty(this.lblSemester.Text) || string.IsNullOrEmpty(cboIdentity.Text))
                return;

            string SQL = string.Format(@"select subject.subject_name, subject.level, subject.credit, subject.type, class_name, seat_no, student_number, student.name, class.grade_year from $ischool.course_selection.ss_attend as sa 
join $ischool.course_selection.subject as subject on sa.ref_subject_id=subject.uid
join student on student.id=sa.ref_student_id
left join class on class.id=student.ref_class_id
where subject.school_year={0} and subject.semester={1} and student.status in (1, 2)
order by subject.subject_name, subject.level, class_name, seat_no, student_number, student.name;", this.lblSchoolYear.Text, this.lblSemester.Text);

            DataTable dataTable = queryHelper.Select(SQL);
            foreach (DataRow row in dataTable.Rows)
            {
                object[] rowData = new object[] { row["subject_name"] + "", row["level"] + "", row["credit"] + "", row["type"] + "", row["class_name"] + "", row["seat_no"] + "", row["student_number"] + "", row["name"] + "" };

                int rowIndex = this.dgvData.Rows.Add(rowData);
            }
        }

        //查詢選課學生
        private void InitSSAttend()
        {
            this.dgvData.Rows.Clear();

            if (string.IsNullOrEmpty(this.lblSchoolYear.Text) || string.IsNullOrEmpty(this.lblSemester.Text) || string.IsNullOrEmpty(cboIdentity.Text))
                return;

            ComboItem item = (ComboItem)this.cboIdentity.SelectedItem;

            if (item.Text == "所有學生")
            {
                InitSSAttend_AllStudent();
                return;
            }

            UDT.Identity identity_Record = item.Tag as UDT.Identity;
            int grade_year = identity_Record.GradeYear;
            grade_year -= (this.CurrentSchoolYear - this.DefaultSchoolYear);
            string SQL = string.Format(@"select subject.subject_name, subject.level, subject.credit, subject.type, class_name, seat_no, student_number, student.name, class.grade_year from $ischool.course_selection.ss_attend as sa 
join $ischool.course_selection.subject as subject on sa.ref_subject_id=subject.uid
join student on student.id=sa.ref_student_id
left join class on class.id=student.ref_class_id
where subject.school_year={0} and subject.semester={1} and student.status in (1, 2)
order by subject.subject_name, subject.level, class_name, seat_no, student_number, student.name;", this.lblSchoolYear.Text, this.lblSemester.Text);

            DataTable dataTable = queryHelper.Select(SQL);
            foreach (DataRow row in dataTable.Rows)
            {
                if ((row["grade_year"] + "" != grade_year.ToString()))
                    continue;

                object[] rowData = new object[] { row["subject_name"] + "", row["level"] + "", row["credit"] + "", row["type"] + "", row["class_name"] + "", row["seat_no"] + "", row["student_number"] + "", row["name"] + "" };

                int rowIndex = this.dgvData.Rows.Add(rowData);
            }
        }

        //查詢未選課學生(所有學生)
        private void InitNonSSAttend_AllStudent()
        {
            this.dgvData.Rows.Clear();

            if (string.IsNullOrEmpty(this.lblSchoolYear.Text) || string.IsNullOrEmpty(this.lblSemester.Text) || string.IsNullOrEmpty(cboIdentity.Text))
                return;

            IEnumerable<UDT.Identity> identities = Access.Select<UDT.Identity>();
            IEnumerable<UDT.SIRelation> sirelations = Access.Select<UDT.SIRelation>();

            var qry = from cfr in identities
                      join cfmtr in sirelations on int.Parse(cfr.UID) equals cfmtr.IdentityID
                      select new { GradeYear = cfr.GradeYear };

            string SQL = string.Format(@"select class_name, seat_no, student_number, student.name, class.grade_year from student
left join class on class.id=student.ref_class_id 
where student.status in (1, 2) and class.status=1 and student.id not in 
(
select sa.ref_student_id from $ischool.course_selection.ss_attend as sa 
join $ischool.course_selection.subject as subject on subject.uid=sa.ref_subject_id
where subject.school_year={0} and subject.semester={1}
)
order by class_name, seat_no, student_number, student.name;", this.lblSchoolYear.Text, this.lblSemester.Text);

            DataTable dataTable = queryHelper.Select(SQL);
            foreach (DataRow row in dataTable.Rows)
            {
                if (qry.Where(x => (x.GradeYear - (this.CurrentSchoolYear - this.DefaultSchoolYear)).ToString() == (row["grade_year"] + "")).Count() == 0)
                    continue;

                object[] rowData = new object[] { "", "", "", "", row["class_name"] + "", row["seat_no"] + "", row["student_number"] + "", row["name"] + "" };

                int rowIndex = this.dgvData.Rows.Add(rowData);
            }
        }

        //查詢未選課學生
        private void InitNonSSAttend()
        {
            this.dgvData.Rows.Clear();

            if (string.IsNullOrEmpty(this.lblSchoolYear.Text) || string.IsNullOrEmpty(this.lblSemester.Text) || string.IsNullOrEmpty(cboIdentity.Text))
                return;

            ComboItem item = (ComboItem)this.cboIdentity.SelectedItem;

            if (item.Text == "所有學生")
            {
                InitNonSSAttend_AllStudent();
                return;
            }

            IEnumerable<UDT.Identity> identities = Access.Select<UDT.Identity>();
            IEnumerable<UDT.SIRelation> sirelations = Access.Select<UDT.SIRelation>();

            var qry = from cfr in identities
                      join cfmtr in sirelations on int.Parse(cfr.UID) equals cfmtr.IdentityID
                      select new { GradeYear = cfr.GradeYear };

            UDT.Identity identity_Record = item.Tag as UDT.Identity;
            int grade_year = identity_Record.GradeYear;
            grade_year -= (this.CurrentSchoolYear - this.DefaultSchoolYear);

            string SQL = string.Format(@"select class_name, seat_no, student_number, student.name, class.grade_year from student
left join class on class.id=student.ref_class_id 
where student.status in (1, 2) and class.status=1 and student.id not in 
(
select sa.ref_student_id from $ischool.course_selection.ss_attend as sa 
join $ischool.course_selection.subject as subject on subject.uid=sa.ref_subject_id
where subject.school_year={0} and subject.semester={1}
)
order by class_name, seat_no, student_number, student.name;", this.lblSchoolYear.Text, this.lblSemester.Text);

            DataTable dataTable = queryHelper.Select(SQL);
            foreach (DataRow row in dataTable.Rows)
            {
                if ((row["grade_year"] + "" != grade_year.ToString()))
                    continue;

                if (qry.Where(x => (x.GradeYear - (this.CurrentSchoolYear - this.DefaultSchoolYear)).ToString() == (row["grade_year"] + "")).Count() == 0)
                    continue;

                object[] rowData = new object[] { "", "", "", "", row["class_name"] + "", row["seat_no"] + "", row["student_number"] + "", row["name"] + "" };

                int rowIndex = this.dgvData.Rows.Add(rowData);
            }
        }

        private void chkSelectNoneStudent_Click(object sender, EventArgs e)
        {

        }

        private void chkSelectNoneStudent_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkSelectNoneStudent.Checked)
                InitSSAttend();
            else
                InitNonSSAttend();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (chkSelectNoneStudent.Checked)
            {
                saveFileDialog1.FileName = string.Format("匯出查詢未選課學生({0})", cboIdentity.SelectedItem.ToString());
            }
            else
            {
                saveFileDialog1.FileName = string.Format("匯出查詢已選課學生({0})", cboIdentity.SelectedItem.ToString());
            }

            saveFileDialog1.Filter = "Excel (*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            DataGridViewExport export = new DataGridViewExport(dgvData);
            export.Save(saveFileDialog1.FileName);

            if (new CompleteForm().ShowDialog() == DialogResult.Yes)
                System.Diagnostics.Process.Start(saveFileDialog1.FileName);





        }

    }
}
