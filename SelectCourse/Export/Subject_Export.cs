using System;
using System.Collections.Generic;
using System.Xml;
using FISCA.UDT;
using FISCA.Data;
using System.Data;

namespace SelectCourse.Export
{
    public partial class Subject_Export : EMBA.Export.ExportProxyForm
    {
        private AccessHelper Access;
        private QueryHelper Helper;

        public Subject_Export()
        {
            InitializeComponent();

            this.Load += new EventHandler(Subject_Export_Load);
        }

        private void Subject_Export_Load(object sender, EventArgs e)
        {
            InitSchoolYear();
            InitSemester();

            InitializeData();
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

        private void InitializeData()
        {
            this.AutoSaveFile = true;
            this.AutoSaveLog = true;
            this.KeyField = "科目系統編號";
            this.InvisibleFields = null;
            this.ReplaceFields = null;
            this.Text = "匯出科目資料";
            this.Tag = this.Text;
            this.QuerySQL = SetQueryString();
        }

        private void nudSchoolYear_ValueChanged(object sender, EventArgs e)
        {
            this.QuerySQL = SetQueryString();
        }

        private void cboSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.QuerySQL = SetQueryString();
        }

        private string SetQueryString()
        {
            string school_year = string.IsNullOrEmpty(this.cboSchoolYear.Text) ? "0" : this.cboSchoolYear.Text;
            string semester = string.IsNullOrEmpty(this.cboSemester.Text) ? "0" : this.cboSemester.Text;
            string querySQL = string.Empty;

            querySQL = string.Format(@"select uid as 科目系統編號, school_year as 學年度, semester as 學期, subject_name as 科目名稱, level as 級別, credit as 學分, type as 課程類別, ""limit"" as 修課人數上限, goal as 教學目標, content as 教學內容, memo as 備註 from $ischool.course_selection.subject where school_year='{0}' and semester='{1}' order by subject_name, level", school_year, semester);

            return querySQL;
        }

        private void cboSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.QuerySQL = SetQueryString();
        }

        private void cboSemester_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            this.QuerySQL = SetQueryString();
        }
    }
}
