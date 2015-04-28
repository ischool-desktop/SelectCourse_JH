using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SHSchool.Data;
using DevComponents.Editors;
using FISCA.UDT;

namespace SelectCourse.Forms
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
            List<SHDepartmentRecord> records = SHDepartment.SelectAll();

            ComboItem comboItem1 = new ComboItem("");
            comboItem1.Tag = null;
            this.cboDepart.Items.Add(comboItem1);
            foreach (SHDepartmentRecord record in records)
            {                
                ComboItem item = new ComboItem(record.FullName);
                item.Tag = record;
                this.cboDepart.Items.Add(item);
            }

            this.cboDepart.SelectedItem = comboItem1;
            this.GradeYear.Focus();

            if (mRecord != null)
            {
                SHDepartmentRecord record = records.Where(x=>x.ID == mRecord.DeptID.ToString()).ElementAt(0);
                ComboItem item = new ComboItem(record.FullName);
                item.Tag = record;
                this.cboDepart.SelectedItem = record;
                this.cboDepart.Text = record.FullName;

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
            ComboItem item = (ComboItem)this.cboDepart.SelectedItem;
            SHDepartmentRecord dept = (SHDepartmentRecord)item.Tag;

            if (dept == null)                
                return false;

            int grade_year = 0;
            bool result = int.TryParse(this.GradeYear.Text, out grade_year);

            if (!result)
            {
                System.Windows.Forms.MessageBox.Show("年級請輸入阿拉伯數字！");
                return false;
            }

            List<UDT.Identity> records = Access.Select<UDT.Identity>(string.Format("ref_dept_id = {0} and grade_year = {1}", dept.ID, grade_year));

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
            ComboItem item = (ComboItem)this.cboDepart.SelectedItem;
            SHDepartmentRecord dept = (SHDepartmentRecord)item.Tag;

            int grade_year = 0;
            bool result = int.TryParse(this.GradeYear.Text, out grade_year);

            UDT.Identity record;

            if (mRecord == null)
                record = new UDT.Identity();
            else
                record = mRecord;

            record.DeptID = int.Parse(dept.ID);
            record.GradeYear = grade_year;

            record.Save();
        }
    }
}
