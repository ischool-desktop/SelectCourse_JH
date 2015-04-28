using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.UDT;

namespace SelectCourse_JH.Forms
{
    public partial class frmSubjectCreator : Form
    {
        private AccessHelper Access;
        private UDT.Subject mRecord;
        private ErrorProvider errorProvider1;
        private string school_year;
        private string semester;

        public frmSubjectCreator(string title, string school_year, string semester)
        {
            InitializeComponent();

            Event.DeliverActiveRecord.Received += new EventHandler<Event.DeliverActiveRecordEventArgs>(Subject_Received);

            this.Text = title;

            this.school_year = school_year;
            this.semester = semester;

            this.Load += new EventHandler(frmSubjectCreator_Load);
        }

        public frmSubjectCreator(string title) : this(title, string.Empty, string.Empty)        {        }

        private void frmSubjectCreator_Load(object sender, EventArgs e)
        {
            if (this.mRecord == null)
            {
                this.mRecord = new UDT.Subject();
                this.mRecord.SchoolYear = int.Parse(this.school_year);
                this.mRecord.Semester = int.Parse(this.semester);
            }
        }

        private void Subject_Received(object sender, Event.DeliverActiveRecordEventArgs e)
        {
            IEnumerable<ActiveRecord> records = e.ActiveRecords;
            if (records == null || records.Count() == 0)
            {
                mRecord = new UDT.Subject();
                return;
            }

            mRecord = records.ElementAt(0) as UDT.Subject;

            this.SubjectName.Text = mRecord.SubjectName.Trim();
            this.Institute.Text = mRecord.Institute.Trim();
            this.Level.Text = mRecord.Level + "";
            this.Credit.Text = mRecord.Credit + "";
            this.Type.Text = mRecord.Type.Trim();
            this.Limit.Text = mRecord.Limit.ToString();
            this.Goal.Text = mRecord.Goal.Trim().Replace("\n", "\r\n");
            this.Content.Text = mRecord.Content.Trim().Replace("\n", "\r\n");
            this.Memo.Text = mRecord.Memo.Trim().Replace("\n", "\r\n");
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Is_Valid())
                    return;

                mRecord.SubjectName = this.SubjectName.Text.Trim();
                if (!string.IsNullOrWhiteSpace(this.Level.Text))
                    mRecord.Level = int.Parse(this.Level.Text.Trim());
                if (!string.IsNullOrWhiteSpace(this.Credit.Text))
                    mRecord.Credit = int.Parse(this.Credit.Text.Trim());
                mRecord.Institute = this.Institute.Text.Trim();
                mRecord.Type = this.Type.Text.Trim();
                mRecord.Limit = int.Parse(this.Limit.Text.Trim());
                mRecord.Goal = this.Goal.Text.Trim();
                mRecord.Content = this.Content.Text.Trim();
                mRecord.Memo = this.Memo.Text.Trim();

                mRecord.Save();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                this.DialogResult = DialogResult.Cancel;
            }
            this.Close();
        }

        private bool Is_Valid()
        {
            errorProvider1 = new ErrorProvider();
            int no;
            bool result;
            bool is_valid = true;

            if (string.IsNullOrWhiteSpace(this.SubjectName.Text))
            {
                errorProvider1.SetError(this.SubjectName, "必填");
                is_valid = false;
            }
            else
                errorProvider1.SetError(this.SubjectName, "");

            if (!string.IsNullOrWhiteSpace(this.Level.Text))
            {
                result = int.TryParse(this.Level.Text.Trim(), out no);

                if (!result)
                {
                    errorProvider1.SetError(this.Level, "請填阿拉伯數字");
                    is_valid = false;
                }
                else
                    errorProvider1.SetError(this.Level, "");
            }
            else
                errorProvider1.SetError(this.Level, "");

            if (!string.IsNullOrWhiteSpace(this.Credit.Text))
            {
                result = int.TryParse(this.Credit.Text.Trim(), out no);

                if (!result)
                {
                    errorProvider1.SetError(this.Credit, "請填阿拉伯數字");
                    is_valid = false;
                }
                else
                    errorProvider1.SetError(this.Credit, "");
            }
            else
                errorProvider1.SetError(this.Credit, "");

            if (string.IsNullOrWhiteSpace(this.Limit.Text))
            {
                errorProvider1.SetError(this.Limit, "必填");
                is_valid = false;
            }
            else
            {
                result = int.TryParse(this.Limit.Text.Trim(), out no);

                if (!result)
                {
                    errorProvider1.SetError(this.Limit, "請填阿拉伯數字");
                    is_valid = false;
                }
                else
                    errorProvider1.SetError(this.Limit, "");
            }

            return is_valid;
        }
    }
}