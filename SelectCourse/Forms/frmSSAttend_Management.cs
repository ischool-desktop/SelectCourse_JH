using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using DevComponents.Editors;
using FISCA.UDT;
using FISCA.Data;
using System.Threading.Tasks;

namespace SelectCourse_JH.Forms
{
    public partial class frmSSAttend_Management : BaseForm
    {
        private AccessHelper Access;
        private QueryHelper queryHelper;
        private int DefaultSchoolYear;
        private int DefaultSemester;
        private int CurrentSchoolYear;
        private int CurrentSemester;
        private Dictionary<string, string> dicStudents;
        private Dictionary<string, string> dicIdentities;
        private Dictionary<string, KeyValuePair<string, int>> dicSIRelations;
        private Dictionary<string, int> dicSelectCounts;
        private List<UDT.SSAttend> SSAttends;
        private Dictionary<string, UDT.SSAttend> dicSSAttends;

        public frmSSAttend_Management()
        {
            InitializeComponent();

            Access = new AccessHelper();
            queryHelper = new QueryHelper();

            dicStudents = new Dictionary<string, string>();
            dicIdentities = new Dictionary<string, string>();
            dicSIRelations = new Dictionary<string, KeyValuePair<string, int>>();
            dicSelectCounts = new Dictionary<string, int>();
            dicSSAttends = new Dictionary<string, UDT.SSAttend>();

            this.progress.Visible = true;
            this.progress.IsRunning = true;
            this.AddSSAttend.Enabled = false;

            Task task = Task.Factory.StartNew(() =>
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("select student.id as student_id, ");
                //如果學生身上的科別代碼為空,就找班級上的科別代碼
                //sb.Append("case when student.ref_dept_id is NULL then class.ref_dept_id else student.ref_dept_id end as dept_id, ");
                sb.Append("class.grade_year from student join class on class.id=student.ref_class_id ");
                sb.Append("where class.status=1 and student.status in (1, 2)");

                DataTable dataTable = queryHelper.Select(sb.ToString());

                foreach (DataRow row in dataTable.Rows)
                {
                    if (!this.dicStudents.ContainsKey(row["student_id"] + ""))
                        this.dicStudents.Add(row["student_id"] + "", row["grade_year"] + "");
                }

                List<UDT.Identity> Identities = Access.Select<UDT.Identity>();
                Identities.ForEach((x) =>
                {
                    if (!this.dicIdentities.ContainsKey("" + x.GradeYear))
                        this.dicIdentities.Add("" + x.GradeYear, x.UID);
                });

                List<UDT.SIRelation> SIRelations = Access.Select<UDT.SIRelation>();
                SIRelations.ForEach((x) =>
                {
                    if (!this.dicSIRelations.ContainsKey(x.IdentityID + "-" + x.SubjectID))
                        this.dicSIRelations.Add(x.IdentityID + "-" + x.SubjectID, new KeyValuePair<string, int>(x.Group, x.CountLimit));
                });

                SSAttends = Access.Select<UDT.SSAttend>();
                SSAttends.ForEach((x) =>
                {
                    if (!this.dicSSAttends.ContainsKey(x.StudentID + "-" + x.SubjectID))
                        this.dicSSAttends.Add(x.StudentID + "-" + x.SubjectID, x);
                });

            });
            task.ContinueWith((x) =>
            {
                this.progress.Visible = false;
                this.progress.IsRunning = false;
                this.AddSSAttend.Enabled = true;
            }, TaskScheduler.FromCurrentSynchronizationContext());
            this.Load += new EventHandler(frmSSAttend_Management_Load);
        }

        private void frmSSAttend_Management_Load(object sender, System.EventArgs e)
        {
            //InitSchoolYear();
            //InitSemester();
            InitIdentity();
            InitCurrentSchoolYearSemester();
            InitDefaultSchoolYearSemester();

            this.lblSelectedAmount.Text = "已選修學生";
            this.lblCurrentSSAttendAmount.Text = "";
            this.lblNoneSelectedAmount.Text = "未選修學生";
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
            foreach (UDT.Identity record in identity_Records)
            {
                ComboItem item = new ComboItem(record.GradeYear + "年級");
                item.Tag = record;
                this.cboIdentity.Items.Add(item);
            }

            this.cboIdentity.SelectedItem = comboItem1;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboIdentity_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboItem item = (ComboItem)this.cboIdentity.SelectedItem;
            UDT.Identity identity_Record = item.Tag as UDT.Identity;

            InitSelectableSubject(identity_Record);
        }

        private void InitSelectableSubject(UDT.Identity identity)
        {
            this.cboSelectableSubject.Items.Clear();
            this.cboSelectableSubject.Text = string.Empty;

            if (identity == null)
                return;

            if (string.IsNullOrEmpty(this.lblSchoolYear.Text) || string.IsNullOrEmpty(this.lblSemester.Text))
                return;

            List<UDT.SIRelation> records = Access.Select<UDT.SIRelation>(string.Format("ref_identity_id = {0}", identity.UID));
            if (records.Count == 0)
                return;

            List<UDT.Subject> subjects = Access.Select<UDT.Subject>(string.Format("uid in ({0}) and school_year={1} and semester={2}", string.Join(",", records.Select(x => x.SubjectID)), this.lblSchoolYear.Text, this.lblSemester.Text));
            Dictionary<string, UDT.Subject> dicSubjects = new Dictionary<string, UDT.Subject>();
            if (subjects.Count == 0)
                return;

            dicSubjects = subjects.ToDictionary(x => x.UID);

            ComboItem comboItem1 = new ComboItem("");
            comboItem1.Tag = 0;
            this.cboSelectableSubject.Items.Add(comboItem1);
            foreach (UDT.SIRelation record in records)
            {
                if (!dicSubjects.ContainsKey(record.SubjectID.ToString()))
                    continue;

                string subject_name = dicSubjects[record.SubjectID.ToString()].SubjectName;
                string subject_level = dicSubjects[record.SubjectID.ToString()].Level.HasValue ? RomanChar(dicSubjects[record.SubjectID.ToString()].Level.Value.ToString()) : string.Empty;

                ComboItem item = new ComboItem(subject_name + subject_level);
                item.Tag = record.SubjectID;
                this.cboSelectableSubject.Items.Add(item);
            }

            this.cboSelectableSubject.SelectedItem = comboItem1;
        }

        private string RomanChar(string level)
        {
            switch (level)
            {
                case "1":
                    return "Ⅰ";
                case "2":
                    return "Ⅱ";
                case "3":
                    return "Ⅲ";
                case "4":
                    return "Ⅳ";
                case "5":
                    return "Ⅴ";
                case "6":
                    return "Ⅵ";
                default:
                    return "";
            }
        }

        private void cboSelectableSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboItem item = (ComboItem)this.cboSelectableSubject.SelectedItem;
            int subject_id = (int)item.Tag;

            InitSubjectInfo(subject_id);
            InitSelectableSubectInfo(subject_id);
            InitSSAttend(subject_id);
            InitNonSSAttend(subject_id);
        }

        private void InitSelectableSubectInfo(int subject_id)
        {
            this.lblGroup.Text = string.Empty;
            this.lblGroupLimit.Text = string.Empty;

            ComboItem item = (ComboItem)this.cboIdentity.SelectedItem;
            UDT.Identity identity_Record = item.Tag as UDT.Identity;

            if (identity_Record == null)
                return;

            List<UDT.SIRelation> records = Access.Select<UDT.SIRelation>(string.Format("ref_subject_id = ({0}) and ref_identity_id = ({1})", subject_id, identity_Record.UID));

            if (records.Count == 0)
                return;

            this.lblGroup.Text = records[0].Group;
            this.lblGroupLimit.Text = records[0].CountLimit.ToString();
        }

        private void InitSubjectInfo(int subject_id)
        {
            this.lblLimit.Text = string.Empty;

            List<UDT.Subject> subjects = Access.Select<UDT.Subject>(string.Format("uid = ({0})", subject_id));

            if (subjects.Count == 0)
                return;
            else
                this.lblLimit.Text = subjects[0].Limit.ToString();
        }

        private void InitSSAttend(int subject_id)
        {
            this.lblSelectedAmount.Text = "已選修學生";
            this.lblCurrentSSAttendAmount.Text = "";
            this.dgvSelectedStudent.Rows.Clear();

            if (string.IsNullOrEmpty(this.lblSchoolYear.Text) || string.IsNullOrEmpty(this.lblSemester.Text) || string.IsNullOrEmpty(cboIdentity.Text) || string.IsNullOrEmpty(cboSelectableSubject.Text))
                return;

            ComboItem item = (ComboItem)this.cboIdentity.SelectedItem;
            UDT.Identity identity_Record = item.Tag as UDT.Identity;
            int grade_year = identity_Record.GradeYear;
            grade_year -= (this.CurrentSchoolYear - this.DefaultSchoolYear);
            string SQL = string.Format(@"select class_name, seat_no, student_number, student.name, Student.id as student_id from $ischool.course_selection.ss_attend as sa 
join $ischool.course_selection.subject as subject on sa.ref_subject_id=subject.uid
join student on student.id=sa.ref_student_id
left join class on class.id=student.ref_class_id
where subject.school_year={0} and subject.semester={1} and subject.uid={2} and student.status in (1, 2)
order by class_name, seat_no, student_number, student.name;", this.lblSchoolYear.Text, this.lblSemester.Text, subject_id);

            DataTable dataTable = queryHelper.Select(SQL);
            foreach (DataRow row in dataTable.Rows)
            {
                object[] rowData = new object[] { row["class_name"] + "", row["seat_no"] + "", row["student_number"] + "", row["name"] };

                int rowIndex = this.dgvSelectedStudent.Rows.Add(rowData);
                this.dgvSelectedStudent.Rows[rowIndex].Tag = row["student_id"] + "";
            }
            if (this.dgvSelectedStudent.Rows.Count == 0)
                return;

            this.lblSelectedAmount.Text = "已選修學生：" + this.dgvSelectedStudent.Rows.Count + "人";
            this.lblCurrentSSAttendAmount.Text = this.dgvSelectedStudent.Rows.Count.ToString();
            this.dgvSelectedStudent.SelectedRows.Cast<DataGridViewRow>().ToList().ForEach(x => x.Selected = false);
        }

        private void InitNonSSAttend(int subject_id)
        {
            this.dgvSelectNoneStudent.Rows.Clear();
            this.lblNoneSelectedAmount.Text = "未選修學生";

            if (string.IsNullOrEmpty(this.lblSchoolYear.Text) || string.IsNullOrEmpty(this.lblSemester.Text) || string.IsNullOrEmpty(cboIdentity.Text) || string.IsNullOrEmpty(this.cboSelectableSubject.Text))
                return;

            ComboItem item = (ComboItem)this.cboIdentity.SelectedItem;
            UDT.Identity identity_Record = item.Tag as UDT.Identity;
            int grade_year = identity_Record.GradeYear;
            grade_year -= (this.CurrentSchoolYear - this.DefaultSchoolYear);

            StringBuilder sb = new StringBuilder();
            sb.Append("select class_name, seat_no, student_number, student.name, class.grade_year, student.id as student_id ");
            sb.Append("from student left join class on class.id=student.ref_class_id ");
            sb.Append("where student.status in (1, 2) and class.status=1 ");
            sb.Append("and student.id not in "); //學生不在...以下條件
            sb.Append("(select sa.ref_student_id from $ischool.course_selection.ss_attend as sa ");
            sb.Append("join $ischool.course_selection.subject as subject on subject.uid=sa.ref_subject_id ");
            sb.Append(string.Format("where subject.uid = {0}) ", subject_id));
            sb.Append("order by class_name, seat_no, student_number, student.name");

            DataTable dataTable = queryHelper.Select(sb.ToString());
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["grade_year"] + "" != grade_year.ToString())
                    continue;

                object[] rowData = new object[] { row["class_name"] + "", row["seat_no"] + "", row["student_number"] + "", row["name"] + "" };

                int rowIndex = this.dgvSelectNoneStudent.Rows.Add(rowData);
                this.dgvSelectNoneStudent.Rows[rowIndex].Tag = row["student_id"] + "";
            }
            if (this.dgvSelectNoneStudent.Rows.Count == 0)
                return;

            this.lblNoneSelectedAmount.Text = "未選修學生：" + this.dgvSelectNoneStudent.Rows.Count + "人";
            this.dgvSelectNoneStudent.SelectedRows.Cast<DataGridViewRow>().ToList().ForEach(x => x.Selected = false);
        }

        private void AddSSAttend_Click(object sender, EventArgs e)
        {
            int selectedAmount = 0;
            int.TryParse(this.lblCurrentSSAttendAmount.Text, out selectedAmount);

            int limit = 0;
            int.TryParse(this.lblLimit.Text, out limit);

            if ((this.dgvSelectNoneStudent.SelectedRows.Count + selectedAmount) > limit)
            {
                MsgBox.Show("加選人數：" + this.dgvSelectNoneStudent.SelectedRows.Count + "，目前選課人數：" + selectedAmount + "，合計超過修課人數上限：" + limit, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            ComboItem item = (ComboItem)this.cboSelectableSubject.SelectedItem;

            if (item.Tag == null)
                return;

            int subject_id = int.Parse(item.Tag.ToString());

            List<UDT.SSAttend> records = new List<UDT.SSAttend>();
            string error_message = string.Empty;
            foreach (DataGridViewRow row in this.dgvSelectNoneStudent.SelectedRows)
            {
                int student_id = int.Parse(row.Tag.ToString());
                if (this.overlimit(student_id, subject_id))
                    error_message += string.Format("班級「{0}」，座號「{1}」，學號「{2}」，姓名「{3}」\n", row.Cells[0].Value + "", row.Cells[1].Value + "", row.Cells[2].Value + "", row.Cells[3].Value + "");
                else
                {
                    UDT.SSAttend record = new UDT.SSAttend();

                    record.SubjectID = subject_id;
                    record.StudentID = student_id;

                    records.Add(record);
                }
            }
            if (!string.IsNullOrEmpty(error_message))
            {
                MsgBox.Show("因為已達科目群組選課數上限，下列學生無法加入選課清單中：\n\n" + error_message);
                return;
            }
            records.ForEach((x) =>
            {
                if (!this.dicSSAttends.ContainsKey(x.StudentID + "-" + x.SubjectID))
                    this.dicSSAttends.Add(x.StudentID + "-" + x.SubjectID, x);
            });

            records.SaveAll();
            InitSSAttend(subject_id);
            InitNonSSAttend(subject_id);
        }

        private void RemoveSSAttend_Click(object sender, EventArgs e)
        {
            ComboItem item = (ComboItem)this.cboSelectableSubject.SelectedItem;

            if (item.Tag == null)
                return;

            int subject_id = int.Parse(item.Tag.ToString());

            List<UDT.SSAttend> records = Access.Select<UDT.SSAttend>(string.Format("ref_subject_id = {0}", subject_id));
            if (records == null || records.Count == 0)
                return;
            List<UDT.SSAttend> dRecords = new List<UDT.SSAttend>();
            foreach (DataGridViewRow row in this.dgvSelectedStudent.SelectedRows)
            {
                int student_id = int.Parse(row.Tag.ToString());

                List<UDT.SSAttend> filterRecords = records.Where(x => x.StudentID == student_id).ToList();

                filterRecords.ForEach((x) =>
                {
                    x.Deleted = true;
                    dRecords.Add(x);
                });
                if (this.dicSSAttends.ContainsKey(student_id + "-" + subject_id))
                    this.dicSSAttends.Remove(student_id + "-" + subject_id);
            }
            dRecords.SaveAll();
            InitSSAttend(subject_id);
            InitNonSSAttend(subject_id);
        }

        private bool overlimit(int StudentID, int SubjectID)
        {
            bool over = false;

            string grade_year = "";

            if (this.dicStudents.ContainsKey(StudentID.ToString()))
            {
                grade_year = this.dicStudents[StudentID.ToString()];
            }
            else
                return over;

            string identity_uid = "";

            if (this.dicIdentities.ContainsKey(grade_year))
                identity_uid = this.dicIdentities[grade_year];
            else
                return over;

            int limit_count = this.GetSIRelationCount(identity_uid, SubjectID.ToString());
            int select_count = 0;
            string group_x = this.GetSIRelationGroup(identity_uid, SubjectID.ToString());
            foreach (UDT.SSAttend SSAttend in this.dicSSAttends.Values)
            {
                if (SSAttend.StudentID != StudentID)
                    continue;

                string group_y = this.GetSIRelationGroup(identity_uid, SSAttend.SubjectID.ToString());

                if (group_x == group_y)
                    select_count += 1;
            }
            if (select_count > limit_count)
                over = true;
            else
                over = false;

            return over;
        }

        private int GetSIRelationCount(string IdentityID, string SubjectID)
        {
            int count = int.MaxValue;

            if (this.dicSIRelations.ContainsKey(IdentityID + "-" + SubjectID))
                count = this.dicSIRelations[IdentityID + "-" + SubjectID].Value;

            return count;
        }

        private string GetSIRelationGroup(string IdentityID, string SubjectID)
        {
            string group = "";

            if (this.dicSIRelations.ContainsKey(IdentityID + "-" + SubjectID))
                group = this.dicSIRelations[IdentityID + "-" + SubjectID].Key;

            return group;
        }
    }
}