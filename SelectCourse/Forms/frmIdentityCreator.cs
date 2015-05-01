using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.Editors;
using FISCA.UDT;

namespace SelectCourse_JH.Forms
{
    public partial class frmIdentityCreator : Form
    {
        private AccessHelper Access;
        private UDT.Identity mRecord;

        public frmIdentityCreator(string UID)
        {
            InitializeComponent();

            this.Load += new EventHandler(frmIdentityCreator_Load);

            this.Access = new AccessHelper();

            if (string.IsNullOrEmpty(UID))
                mRecord = null;
            else
                mRecord = Access.Select<UDT.Identity>(string.Format("uid = {0}", UID)).ElementAt(0);
        }

        private void frmIdentityCreator_Load(object sender, EventArgs e)
        {
            this.GradeYear.Focus();

            if (mRecord != null)
            {
                this.GradeYear.Text = mRecord.GradeYear.ToString();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            if (Is_Validated())
            {
                SaveData();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                return;
            }
        }

        private bool Is_Validated()
        {
            int grade_year = 0;
            bool result = int.TryParse(this.GradeYear.Text, out grade_year);

            if (!result)
            {
                System.Windows.Forms.MessageBox.Show("年級請輸入阿拉伯數字！");
                return false;
            }

            List<UDT.Identity> records = Access.Select<UDT.Identity>(string.Format("grade_year = {0}", grade_year));

            if (mRecord == null)
            {
                if (records.Count > 0)
                {
                    System.Windows.Forms.MessageBox.Show("已存在同名身分！");
                    return false;
                }
            }
            else
            {
                if (records.Count > 0 && (records[0].DeptID == mRecord.DeptID && records[0].GradeYear == mRecord.GradeYear && records[0].UID != mRecord.UID))
                {
                    System.Windows.Forms.MessageBox.Show("已存在同名身分！");
                    return false;
                }
            }

            return true;
        }

        private void SaveData()
        {
            int grade_year = 0;
            bool result = int.TryParse(this.GradeYear.Text, out grade_year);

            UDT.Identity record;

            if (mRecord == null)
                record = new UDT.Identity();
            else
                record = mRecord;

            record.GradeYear = grade_year;

            record.Save();
        }
    }
}
