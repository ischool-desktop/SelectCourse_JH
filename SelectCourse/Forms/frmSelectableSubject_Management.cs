using System;
using System.Collections.Generic;
using FISCA.Presentation.Controls;
using FISCA.UDT;
using DevComponents.Editors;
using System.Linq;
using System.Windows.Forms;
using FISCA.Data;
using System.Data;

namespace SelectCourse_JH.Forms
{
    public partial class frmSelectableSubject_Management : BaseForm
    {
        private AccessHelper Access;
        private List<UDT.SIRelation> oSIRelation_Records;
        private ErrorProvider errorProvider1;
        private QueryHelper queryHelper;
        private Dictionary<string, int> dicGroupCountLimits;
        private bool no_change;
        private bool form_loaded;

        public frmSelectableSubject_Management()
        {
            InitializeComponent();

            errorProvider1 = new ErrorProvider();
            this.Access = new AccessHelper();
            this.queryHelper = new QueryHelper();

            this.Load += new EventHandler(frmSubject_Management_Load);

            Event.DeliverActiveRecord.Received += new EventHandler<Event.DeliverActiveRecordEventArgs>(Subject_Received);

            this.dgvData.DataError += new DataGridViewDataErrorEventHandler(dgvData_DataError);
            this.dgvData.CurrentCellDirtyStateChanged += new EventHandler(dgvData_CurrentCellDirtyStateChanged);
            this.dgvData.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_ColumnHeaderMouseClick);
            this.dgvData.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_RowHeaderMouseClick);
            this.dgvData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvData_MouseClick);
            this.dgvData.CellEnter += new DataGridViewCellEventHandler(dgvData_CellEnter);
        }

        private void frmSubject_Management_Load(object sender, EventArgs e)
        {
            this.form_loaded = false;

            this.InitSchoolYear();
            this.InitSemester();
            this.InitIdentity();

            this.lblMessage.Text = string.Empty;
            this.lblMessage.Tag = null;
            this.no_change = false;

            this.form_loaded = true;
        }

        private void Subject_Received(object sender, Event.DeliverActiveRecordEventArgs e)
        {
            IEnumerable<ActiveRecord> records = e.ActiveRecords;
            if (records == null || records.Count() == 0)
                return;

            this.no_change = true;
            IEnumerable<DataGridViewRow> rows = this.dgvData.Rows.Cast<DataGridViewRow>();
            records.ToList().ForEach((x) =>
            {
                UDT.Subject record = x as UDT.Subject;
                if ((rows.Where(y => (y.Tag == null ? "" : y.Tag.ToString()) == record.UID).Count() == 0))
                {
                    object[] rowData = new object[] { record.SubjectName, record.Level, "", "" };

                    int rowIndex = this.dgvData.Rows.Add(rowData);
                    DataGridViewRow row = this.dgvData.Rows[rowIndex];
                    row.Tag = record.UID;
                }
            });
            this.no_change = false;
        }

        private void InitSchoolYear()
        {
            this.cboSchoolYear.Items.Clear();

            int school_year;

            if (!int.TryParse(K12.Data.School.DefaultSchoolYear, out school_year))
                school_year = DateTime.Today.Year - 1911;

            this.cboSchoolYear.Items.Add("");
            this.cboSchoolYear.Items.Add(school_year);
            this.cboSchoolYear.Items.Add(school_year + 1);
            this.cboSchoolYear.Items.Add(school_year + 2);
        }

        private void InitSemester()
        {
            this.cboSemester.Items.Clear();

            this.cboSemester.Items.Add("");
            this.cboSemester.Items.Add("1");
            this.cboSemester.Items.Add("2");
        }

        private void InitIdentity()
        {
            this.lstIdentity.Items.Clear();

            this.lstIdentity.DisplayMember = "Item";
            this.lstIdentity.ValueMember = "UID";

            List<UDT.Identity> records = Access.Select<UDT.Identity>();
            if (records.Count == 0)
                return;

            IEnumerable<UDT.Identity> filterRecords = records;

            foreach (UDT.Identity identity in filterRecords)
            {
                this.lstIdentity.Items.Add(new { UID = identity.UID, Item = (identity.GradeYear + "年級") });
            }

        }

        /// <summary>
        /// 新增可選課身份
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form frm = new frmIdentityCreator(string.Empty);
            frm.ShowDialog();

            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                this.InitIdentity();
        }

        /// <summary>
        /// 修改可選課身份
        /// </summary>
        private void Update_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ListBox lstBox = this.lstIdentity;
            if (lstBox.SelectedIndex == -1)
                return;

            string UID = ((dynamic)lstBox.SelectedItem).UID;
            System.Windows.Forms.Form frm = new frmIdentityCreator(UID);
            frm.ShowDialog();

            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                this.InitIdentity();
        }

        private void cmdSelectSubjects_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.cboSchoolYear.Text) || string.IsNullOrEmpty(this.cboSemester.Text) || this.lblMessage.Tag == null)
            {
                MsgBox.Show("請先選擇「學年度」、「學期」、「選課身分」！");
                return;
            }

            (new frmSubject_Management(this.cboSchoolYear.Text, this.cboSemester.Text)).ShowDialog();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (this.lblMessage.Tag == null)
                return;

            if (this.dgvData.Rows.Count > 0 && !Is_Validated())
                return;

            try
            {
                int identity_id = int.Parse(this.lblMessage.Tag.ToString());
                List<UDT.SIRelation> records = Access.Select<UDT.SIRelation>(string.Format("ref_identity_id = {0}", identity_id));
                if (records != null && records.Count > 0)
                {
                    List<UDT.Subject> subjects = Access.Select<UDT.Subject>(string.Format("uid in ({0}) and school_year={1} and semester={2}", string.Join(",", records.Select(x => x.SubjectID)), this.cboSchoolYear.Text, this.cboSemester.Text));
                    records.ForEach((x) =>
                    {
                        if (subjects.Where(y => y.UID == x.SubjectID.ToString()).Count() > 0)
                            x.Deleted = true;
                    });
                    records.SaveAll();
                }
                List<UDT.SIRelation> new_records = new List<UDT.SIRelation>();
                foreach (DataGridViewRow row in this.dgvData.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    UDT.SIRelation record = new UDT.SIRelation();

                    record.CountLimit = int.Parse(row.Cells["CountLimit"].Value + "");
                    record.Group = row.Cells["Group"].Value + "";
                    record.IdentityID = identity_id;
                    record.SubjectID = int.Parse(row.Tag.ToString());

                    new_records.Add(record);
                }
                new_records.SaveAll();
                MsgBox.Show("儲存成功。");
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private bool Is_Validated()
        {
            bool result = true;

            if (this.dgvData.Rows.Count == 0)
                return false;

            if (this.dgvData.Rows.Count == 1 && this.dgvData.Rows[0].IsNewRow)
                return false;

            foreach (DataGridViewRow row in this.dgvData.Rows)
            {
                if (row.IsNewRow)
                    continue;

                if (!string.IsNullOrEmpty(row.Cells["CountLimit"].Value + ""))
                {
                    int countLimit = 0;
                    if (!int.TryParse(row.Cells["CountLimit"].Value + "", out countLimit))
                    {
                        row.Cells["CountLimit"].ErrorText = "請填阿拉伯數字";
                        result = false;
                    }
                    else
                        row.Cells["CountLimit"].ErrorText = "";
                }
                else
                {
                    row.Cells["CountLimit"].ErrorText = "必填";
                    result = false;
                }
            }

            return result;
        }

        private void lstIdentity_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ListBox lstBox = (sender as System.Windows.Forms.ListBox);
            if (lstBox.SelectedIndex == -1)
            {
                this.lblMessage.Text = "";
                this.lblMessage.Tag = null;
                return;
            }

            this.lblMessage.Text = ((dynamic)lstBox.SelectedItem).Item + "可選科目";
            this.lblMessage.Tag = ((dynamic)lstBox.SelectedItem).UID;

            this.InitSelectableSubject();
        }

        private void InitSelectableSubject()
        {
            if (!this.form_loaded)
                return;

            this.no_change = true;
            this.dicGroupCountLimits = new Dictionary<string, int>();
            this.dgvData.Rows.Clear();
            this.oSIRelation_Records = new List<UDT.SIRelation>();

            if (this.lblMessage.Tag == null)
                return;

            if (string.IsNullOrEmpty(this.cboSchoolYear.Text) || string.IsNullOrEmpty(this.cboSemester.Text))
                return;

            int identity_id = int.Parse(this.lblMessage.Tag.ToString());
            List<UDT.SIRelation> records = Access.Select<UDT.SIRelation>(string.Format("ref_identity_id = {0}", identity_id));
            if (records.Count == 0)
                return;

            List<UDT.Subject> subjects = Access.Select<UDT.Subject>(string.Format("uid in ({0}) and school_year={1} and semester={2}", string.Join(",", records.Select(x => x.SubjectID)), this.cboSchoolYear.Text, this.cboSemester.Text));
            Dictionary<string, UDT.Subject> dicSubjects = new Dictionary<string, UDT.Subject>();
            if (subjects.Count == 0)
                return;

            dicSubjects = subjects.ToDictionary(x => x.UID);

            foreach (UDT.SIRelation record in records)
            {
                if (!dicSubjects.ContainsKey(record.SubjectID.ToString()))
                    continue;

                string subject_name = dicSubjects[record.SubjectID.ToString()].SubjectName;
                string subject_level = dicSubjects[record.SubjectID.ToString()].Level.HasValue ? dicSubjects[record.SubjectID.ToString()].Level.Value.ToString() : string.Empty;

                object[] rowData = new object[] { subject_name, subject_level, record.Group, record.CountLimit };

                int rowIndex = this.dgvData.Rows.Add(rowData);
                DataGridViewRow row = this.dgvData.Rows[rowIndex];
                row.Tag = record.SubjectID;

                if (!this.dicGroupCountLimits.ContainsKey(record.Group))
                    this.dicGroupCountLimits.Add(record.Group, record.CountLimit);
            }
            this.no_change = false;
        }

        private void cboSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitSelectableSubject();
        }

        private void cboSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitSelectableSubject();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (this.lblMessage.Tag == null)
                return;

            try
            {
                //  身分代碼
                int identity_id = int.Parse(this.lblMessage.Tag.ToString());

                List<UDT.Identity> Identity_Records = Access.Select<UDT.Identity>(string.Format("uid={0}", identity_id.ToString()));

                //  刪除身分不影響選課記錄，故不必串接刪除選課記錄
                //            DataTable dataTable = queryHelper.Select(string.Format(@"select student.id as student_id, dept.id as dept_id from student join dept on dept.id=student.ref_dept_id where student.ref_dept_id is not null and student.ref_dept_id={0} 
                //union
                //select student.id as student_id, dept.id as dept_id from student join class on student.ref_class_id=class.id join dept on dept.id=class.ref_dept_id where student.ref_dept_id is null and class.ref_dept_id={0}", identities[0].DeptID.ToString()));

                //            Dictionary<string, List<string>> dicDeptIDMappingStudentIDs = new Dictionary<string, List<string>>();

                //            foreach (DataRow row in dataTable.Rows)
                //            {
                //                if (!dicDeptIDMappingStudentIDs.ContainsKey(row["dept_id"] + ""))
                //                    dicDeptIDMappingStudentIDs.Add(row["dept_id"] + "", new List<string>());

                //                dicDeptIDMappingStudentIDs[row["dept_id"] + ""].Add(row["student_id"] + "");
                //            }

                //  可選修課目
                List<UDT.SIRelation> SIRelation_Records = Access.Select<UDT.SIRelation>(string.Format("ref_identity_id = {0}", identity_id));

                DialogResult result = MessageBox.Show("確定刪除「選課身分」及其所包含之所有學年度學期「可選修科目」？若僅刪除特定學年度學期「可選修科目」，請多選「可選修科目」並按「Del」鍵，再按「儲存」。", "警告", MessageBoxButtons.OKCancel);
                if (result == System.Windows.Forms.DialogResult.Cancel)
                    return;

                if (SIRelation_Records.Count > 0)
                {
                    SIRelation_Records.ForEach(x => x.Deleted = true);
                    SIRelation_Records.SaveAll();
                }
                if (Identity_Records.Count > 0)
                {
                    Identity_Records.ForEach(x => x.Deleted = true);
                    Identity_Records.SaveAll();
                }
                InitIdentity();
                this.lblMessage.Text = string.Empty;
                this.lblMessage.Tag = null;
                this.dgvData.Rows.Clear();
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message, "錯誤");
            }
        }

        private void dgvData_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvData.CurrentCell = null;
            dgvData.Rows[e.RowIndex].Selected = true;
        }

        private void dgvData_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvData.CurrentCell = null;
            dgvData.Columns[e.ColumnIndex].Selected = true;
        }

        private void dgvData_MouseClick(object sender, MouseEventArgs e)
        {
            MouseEventArgs args = (MouseEventArgs)e;
            DataGridView dgv = (DataGridView)sender;
            DataGridView.HitTestInfo hit = dgv.HitTest(args.X, args.Y);

            if (hit.Type == DataGridViewHitTestType.TopLeftHeader)
            {
                dgvData.CurrentCell = null;
                dgvData.SelectAll();
            }
        }

        private void dgvData_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            int rowIndex = dgvData.CurrentCell.RowIndex;
            int colIndex = dgvData.CurrentCell.ColumnIndex;

            dgvData.CommitEdit(DataGridViewDataErrorContexts.Commit);

            if (colIndex == 2)
            {
                if (this.dicGroupCountLimits.ContainsKey(dgvData.Rows[rowIndex].Cells["Group"].Value + ""))
                    dgvData.Rows[rowIndex].Cells["CountLimit"].Value = this.dicGroupCountLimits[dgvData.Rows[rowIndex].Cells["Group"].Value + ""];
            }
            if (colIndex == 3)
            {
                if (this.no_change)
                    return;

                int limit = 0;
                bool result = int.TryParse(dgvData.Rows[rowIndex].Cells["CountLimit"].Value + "", out limit);
                if (!result)
                    return;

                if (!this.dicGroupCountLimits.ContainsKey(dgvData.Rows[rowIndex].Cells["Group"].Value + ""))
                    this.dicGroupCountLimits.Add(dgvData.Rows[rowIndex].Cells["Group"].Value + "", limit);

                this.dicGroupCountLimits[dgvData.Rows[rowIndex].Cells["Group"].Value + ""] = limit;

                UpdateCountLimit();
            }
        }

        private void UpdateCountLimit()
        {
            this.no_change = true;
            foreach (DataGridViewRow row in this.dgvData.Rows)
            {
                if (dicGroupCountLimits.ContainsKey(row.Cells["Group"].Value + ""))
                    row.Cells["CountLimit"].Value = dicGroupCountLimits[row.Cells["Group"].Value + ""];
            }
            this.no_change = false;
        }

        private void dgvData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvData.SelectedCells.Count == 1)
            {
                dgvData.BeginEdit(true);
            }
        }

        private void dgvData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}