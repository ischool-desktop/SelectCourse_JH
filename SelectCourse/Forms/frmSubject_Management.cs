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

namespace SelectCourse_JH.Forms
{
    public partial class frmSubject_Management : BaseForm
    {
        private AccessHelper Access;
        private string school_year;
        private string semester;
        private bool forSendingSubject;
        private ErrorProvider errorProvider1;
        private List<UDT.Subject> oRecords;

        public frmSubject_Management() : this(string.Empty, string.Empty)   {   }

        public frmSubject_Management(string school_year, string semester)
        {
            InitializeComponent();

            this.school_year = school_year;
            this.semester = semester;

            if (!string.IsNullOrEmpty(this.school_year) && !string.IsNullOrEmpty(this.semester))
                this.forSendingSubject = true;
            else
                this.forSendingSubject = false;

            this.Load += new EventHandler(frmSubject_Management_Load);
        }

        private void frmSubject_Management_Load(object sender, EventArgs e)
        {
            errorProvider1 = new ErrorProvider();

            this.Access = new AccessHelper();

            this.InitSchoolYear();
            this.InitSemester();

            if (this.forSendingSubject)
            {
                this.cboSchoolYear.Enabled = false;
                this.cboSemester.Enabled = false;

                this.cboSchoolYear.Text = this.school_year;
                this.cboSemester.Text = this.semester;

                this.Addd.Visible = false;
                this.Update.Visible = false;
                this.Delete.Visible = false;
            }
            else
            {
                this.cboSchoolYear.Enabled = true;
                this.cboSemester.Enabled = true;

                this.Addd.Visible = true;
                this.Update.Visible = true;
                this.Delete.Visible = true;
            }

            this.InitSubject();
        }

        private void InitSubject()
        {
            oRecords = new List<UDT.Subject>();
            this.dgvData.Rows.Clear();

            if (this.forSendingSubject)
            {
                this.dgvData.Columns[0].Visible = true;
                this.dgvData.AllowUserToDeleteRows = false;
                this.dgvData.AllowUserToAddRows = false;
            }
            else
                this.dgvData.Columns[0].Visible = false;

            if (string.IsNullOrEmpty(this.cboSchoolYear.Text) || string.IsNullOrEmpty(this.cboSemester.Text))
                return;

            List<UDT.Subject> records = Access.Select<UDT.Subject>(string.Format("school_year = {0} and semester = {1}", this.cboSchoolYear.Text, this.cboSemester.Text));
            this.dgvData.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvData.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvData.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvData.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //this.dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            foreach (UDT.Subject record in records)
            {
                object[] rowData = new object[] { "加入", record.Institute, record.SubjectName, record.Level, record.Credit, record.Type, record.Limit, record.Goal, record.Content, record.Memo };

                int rowIndex = this.dgvData.Rows.Add(rowData);
                DataGridViewRow row = this.dgvData.Rows[rowIndex];
                //this.dgvData.AutoResizeRow(rowIndex, DataGridViewAutoSizeRowMode.AllCells);
                row.Tag = record;

                oRecords.Add(record);
            }
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

        private void Save_Click(object sender, EventArgs e)
        {
            if (!this.Is_Validated())
                return;

            List<UDT.Subject> records = new List<UDT.Subject>();
            try
            {
                foreach (DataGridViewRow row in this.dgvData.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    UDT.Subject subj = (UDT.Subject)row.Tag;

                    if (subj == null)
                        subj = new UDT.Subject();

                    subj.Institute = row.Cells["Institute"].Value + "";
                    subj.SubjectName = row.Cells["SubjectName"].Value + "";

                    int level = 0;
                    if (int.TryParse(row.Cells["Level"].Value + "", out level))
                        subj.Level = level;

                    subj.Type = row.Cells["Type"].Value + "";

                    int credit = 0;
                    if (int.TryParse(row.Cells["Credit"].Value + "", out credit))
                        subj.Credit = credit;

                    subj.Limit = int.Parse(row.Cells["Limit"].Value + "");
                    subj.Goal = row.Cells["Goal"].Value + "";
                    subj.Content = row.Cells["Content"].Value + "";
                    subj.Memo = row.Cells["Memo"].Value + "";
                    subj.SchoolYear = int.Parse(this.cboSchoolYear.Text);
                    subj.Semester = int.Parse(this.cboSemester.Text);

                    records.Add(subj);
                }
                List<UDT.Subject> dRecords = new List<UDT.Subject>();
                oRecords.ForEach((x) =>
                {
                    if (records.Where(y => y.UID == x.UID).Count() == 0)
                    {
                        x.Deleted = true;
                        dRecords.Add(x);
                    }
                });
                records.SaveAll();
                dRecords.SaveAll();
                MsgBox.Show("儲存成功！");
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && this.forSendingSubject)
            {
                UDT.Subject record = this.dgvData.Rows[e.RowIndex].Tag as UDT.Subject;

                List<UDT.Subject> records = new List<UDT.Subject>();
                records.Add(record);

                Event.DeliverActiveRecord.RaiseSendingEvent(this, new Event.DeliverActiveRecordEventArgs(records));
            }
        }

        private void cboSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.InitSubject();
        }

        private void cboSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.InitSubject();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Is_Validated()
        {
            bool result = true;

            if (string.IsNullOrEmpty(this.cboSchoolYear.Text))
                errorProvider1.SetError(this.cboSchoolYear, "必填");
            else
                errorProvider1.SetError(this.cboSchoolYear, "");

            if (string.IsNullOrEmpty(this.cboSemester.Text))
                errorProvider1.SetError(this.cboSemester, "必填");
            else
                errorProvider1.SetError(this.cboSemester, "");

            if (string.IsNullOrEmpty(this.cboSchoolYear.Text) || string.IsNullOrEmpty(this.cboSemester.Text))
                return false;

            if (this.dgvData.Rows.Count == 0)
                return false;

            if (this.dgvData.Rows.Count == 1 && this.dgvData.Rows[0].IsNewRow)
                return false;

            foreach (DataGridViewRow row in this.dgvData.Rows)
            {
                if (row.IsNewRow)
                    continue;

                if (string.IsNullOrEmpty(row.Cells["SubjectName"].Value == null ? "" : row.Cells["SubjectName"].Value.ToString()))
                {
                    row.Cells["SubjectName"].ErrorText = "必填";
                    result = false;
                }
                else
                    row.Cells["SubjectName"].ErrorText = "";

                if (!string.IsNullOrEmpty(row.Cells["Level"].Value == null ? "" : row.Cells["Level"].Value.ToString()))
                {
                    int level = 0;
                    if (!int.TryParse(row.Cells["Level"].Value == null ? "" : row.Cells["Level"].Value.ToString(), out level))
                    {
                        row.Cells["Level"].ErrorText = "請填阿拉伯數字";
                        result = false;
                    }
                    else
                        row.Cells["Level"].ErrorText = "";
                }
                else
                    row.Cells["Level"].ErrorText = "";

                if (!string.IsNullOrEmpty(row.Cells["Credit"].Value == null ? "" : row.Cells["Credit"].Value.ToString()))
                {
                    int level = 0;
                    if (!int.TryParse(row.Cells["Credit"].Value == null ? "" : row.Cells["Credit"].Value.ToString(), out level))
                    {
                        row.Cells["Credit"].ErrorText = "請填阿拉伯數字";
                        result = false;
                    }
                    else
                        row.Cells["Credit"].ErrorText = "";
                }
                else
                    row.Cells["Credit"].ErrorText = "";

                if (!string.IsNullOrEmpty(row.Cells["Limit"].Value == null ? "" : row.Cells["Limit"].Value.ToString()))
                {
                    int level = 0;
                    if (!int.TryParse(row.Cells["Limit"].Value == null ? "" : row.Cells["Limit"].Value.ToString(), out level))
                    {
                        row.Cells["Limit"].ErrorText = "請填阿拉伯數字";
                        result = false;
                    }
                    else
                        row.Cells["Limit"].ErrorText = "";
                }
                else
                {
                    row.Cells["Limit"].ErrorText = "必填";
                    result = false;
                }
            }

            return result;
        }

        private void Addd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.cboSchoolYear.Text) || string.IsNullOrEmpty(this.cboSemester.Text))
            {
                MsgBox.Show("請先選擇「學年度」與「學期」。");
                return;
            }

            frmSubjectCreator frm = new frmSubjectCreator("新增科目", this.cboSchoolYear.Text, this.cboSemester.Text);
            frm.ShowDialog();

            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                this.InitSubject();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (this.dgvData.SelectedRows.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("請先選擇科目。");
                return;
            }

            try
            {
                frmSubjectCreator frm = new frmSubjectCreator("修改科目");
                UDT.Subject record = this.dgvData.SelectedRows[0].Tag as UDT.Subject;
                List<UDT.Subject> records = new List<UDT.Subject>();
                records.Add(record);

                Event.DeliverActiveRecord.RaiseSendingEvent(this, new Event.DeliverActiveRecordEventArgs(records));
                frm.ShowDialog();

                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                    this.InitSubject();
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (this.dgvData.SelectedRows.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("請先選擇科目。");
                return;
            }

            try
            {
                UDT.Subject record = this.dgvData.SelectedRows[0].Tag as UDT.Subject;
                record.Deleted = true;

                record.Save();

                this.InitSubject();
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void dgvData_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {           
            //this.dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //this.dgvData.AutoResizeRows();
            this.dgvData.Rows.Cast<DataGridViewRow>().ToList().ForEach(x => this.dgvData.AutoResizeRow(x.Index));
        }
    }
}
