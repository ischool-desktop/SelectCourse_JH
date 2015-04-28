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
using DevComponents.DotNetBar.Controls;

namespace SelectCourse_JH.Forms
{
    public partial class frmOpeningTime : BaseForm
    {
        private AccessHelper Access;
        private ErrorProvider errorProvider1;

        public frmOpeningTime()
        {
            InitializeComponent();

            this.Load += new EventHandler(frmOpeningTime_Load);
        }

        private void frmOpeningTime_Load(object sender, EventArgs e)
        {
            this.Access = new AccessHelper();

            this.InitSchoolYear();
            this.InitSemester();
            this.InitOpeningTime();

            errorProvider1 = new ErrorProvider();
        }

        private void InitOpeningTime()
        {
            try
            {
                List<UDT.OpeningTime> records = Access.Select<UDT.OpeningTime>();

                if (records == null || records.Count == 0)
                    return;

                this.StartTime.Text = records[0].StartTime.ToString("yyyy/M/d HH:mm:ss");
                this.EndTime.Text = records[0].EndTime.ToString("yyyy/M/d HH:mm:ss");

                for (int i = 0; i < this.cboSchoolYear.Items.Count; i++)
                {
                    if (this.cboSchoolYear.Items[i].ToString() == records[0].SchoolYear.ToString())
                    {
                        this.cboSchoolYear.Text = records[0].SchoolYear.ToString();
                        break;
                    }
                }

                for (int i = 0; i < this.cboSemester.Items.Count; i++)
                {
                    if (this.cboSemester.Items[i].ToString() == records[0].Semester.ToString())
                    {
                        this.cboSemester.Text = records[0].Semester.ToString();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
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

        private bool Is_Validated()
        {
            bool result = true;

            if (string.IsNullOrEmpty(this.StartTime.Text))
            {
                errorProvider1.SetError(this.StartTime, "必填");
                result = false;
            }
            else
            {
                DateTime date;
                if (!DateTime.TryParse(this.StartTime.Text.Trim(), out date))
                {
                    errorProvider1.SetError(this.StartTime, "非日期格式");
                    result = false;
                }
                else
                    errorProvider1.SetError(this.StartTime, "");
            }

            if (string.IsNullOrEmpty(this.EndTime.Text))
            {
                errorProvider1.SetError(this.EndTime, "必填");
                result = false;
            }
            else
            {
                DateTime date;
                if (!DateTime.TryParse(this.EndTime.Text.Trim(), out date))
                {
                    errorProvider1.SetError(this.EndTime, "非日期格式");
                    result = false;
                }
                else
                    errorProvider1.SetError(this.EndTime, "");
            }

            if (string.IsNullOrEmpty(this.cboSchoolYear.Text))
            {
                errorProvider1.SetError(this.cboSchoolYear, "必填");
                result = false;
            }
            else
            {
                errorProvider1.SetError(this.cboSchoolYear, "");
            }

            if (string.IsNullOrEmpty(this.cboSemester.Text))
            {
                errorProvider1.SetError(this.cboSemester, "必填");
                result = false;
            }
            else
            {
                errorProvider1.SetError(this.cboSemester, "");
            }

            return result;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (!Is_Validated())
                return;

            try
            {
                UDT.OpeningTime record;
                List<UDT.OpeningTime> records = Access.Select<UDT.OpeningTime>();

                if (records == null || records.Count == 0)
                    record = new UDT.OpeningTime();
                else
                    record = records[0];

                DateTime startTime = DateTime.Parse(this.StartTime.Text);
                record.StartTime = startTime;                

                DateTime endTime = DateTime.Parse(this.EndTime.Text);
                if ((endTime.Hour + endTime.Minute + endTime.Second) == 0)
                    record.EndTime = endTime.AddDays(1).AddSeconds(-1);
                else
                    record.EndTime = endTime;

                record.SchoolYear = int.Parse(this.cboSchoolYear.Text);
                record.Semester = int.Parse(this.cboSemester.Text);

                record.Save();

                MsgBox.Show("儲存成功");
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }
        }
    }
}
