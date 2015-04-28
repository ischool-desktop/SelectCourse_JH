using System.Windows.Forms;
using FISCA;
using FISCA.UDT;
using FISCA.Presentation;
using FISCA.Permission;

namespace SelectCourse
{
    public static class Program
    {
        [MainMethod("新民高中選課模組")]
        static public void Main()
        {
            #region 模組啟用先同步Schema

            SchemaManager Manager = new SchemaManager(FISCA.Authentication.DSAServices.DefaultConnection);

            Manager.SyncSchema(new UDT.Identity());
            Manager.SyncSchema(new UDT.OpeningTime());
            Manager.SyncSchema(new UDT.SIRelation());
            Manager.SyncSchema(new UDT.SSAttend());
            Manager.SyncSchema(new UDT.Subject());

            //ServerModule.AutoManaged("https://module.ischool.com.tw/module/4923/shinmin.tc.edu.tw/udm.xml");
            ServerModule.AutoManaged("http://module.ischool.com.tw/module/140/Course_Selection/udm.xml");
            #endregion

            #region 教務作業/設定與管理
            InitRibbonBar();
            #endregion
        }

        public static void InitRibbonBar()
        {
            #region 教務作業

            #region 選修科目設定

            Catalog button_SelectableSubject_Management = RoleAclSource.Instance["教務作業"]["功能按鈕"];
            button_SelectableSubject_Management.Add(new RibbonFeature("Button_SelectableSubject_Management", "選修科目設定"));

            var vSelectableSubject_Management = MotherForm.RibbonBarItems["教務作業", "選課作業"]["設定"];
            vSelectableSubject_Management.Size = RibbonBarButton.MenuButtonSize.Large;
            vSelectableSubject_Management.Image = Properties.Resources.network_lock_64;
            vSelectableSubject_Management["選修科目"].Enable = UserAcl.Current["Button_SelectableSubject_Management"].Executable;
            vSelectableSubject_Management["選修科目"].Click += delegate
            {
                (new Forms.frmSelectableSubject_Management()).ShowDialog();
            };

            #endregion

            #region 選課時間設定

            Catalog button_OpeningTime_Management = RoleAclSource.Instance["教務作業"]["功能按鈕"];
            button_OpeningTime_Management.Add(new RibbonFeature("Button_OpeningTime_Management", "選課時間設定"));

            var vOpeningTime_Management = MotherForm.RibbonBarItems["教務作業", "選課作業"]["設定"];
            vOpeningTime_Management.Size = RibbonBarButton.MenuButtonSize.Large;
            vOpeningTime_Management["選課時間"].Enable = UserAcl.Current["Button_OpeningTime_Management"].Executable;
            vOpeningTime_Management["選課時間"].Click += delegate
            {
                (new Forms.frmOpeningTime()).ShowDialog();
            };

            #endregion

            #region 學生選修科目設定

            Catalog button_SSAttend_Management = RoleAclSource.Instance["教務作業"]["功能按鈕"];
            button_SSAttend_Management.Add(new RibbonFeature("Button_SSAttend_Management", "學生選修科目設定"));

            var vSSAttend_Management = MotherForm.RibbonBarItems["教務作業", "選課作業"]["設定"];
            vSSAttend_Management.Size = RibbonBarButton.MenuButtonSize.Large;
            vSSAttend_Management["學生選修科目"].Enable = UserAcl.Current["Button_SSAttend_Management"].Executable;
            vSSAttend_Management["學生選修科目"].Click += delegate
            {
                (new Forms.frmSSAttend_Management()).ShowDialog();
            };

            #endregion

            #region 科目管理

            Catalog button_Subject_Management = RoleAclSource.Instance["教務作業"]["功能按鈕"];
            button_Subject_Management.Add(new RibbonFeature("Button_Subject_Management", "科目管理"));

            var vSubject_Management = MotherForm.RibbonBarItems["教務作業", "選課作業"]["管理"];
            vSubject_Management.Size = RibbonBarButton.MenuButtonSize.Large;
            vSubject_Management.Image = Properties.Resources.sandglass_unlock_64;
            vSubject_Management["科目"].Enable = UserAcl.Current["Button_Subject_Management"].Executable;
            vSubject_Management["科目"].Click += delegate
            {
                (new Forms.frmSubject_Management()).ShowDialog();
            };

            #endregion

            #region 匯出科目

            MotherForm.RibbonBarItems["教務作業", "選課作業"]["匯出"].Image = Properties.Resources.Export_Image;
            MotherForm.RibbonBarItems["教務作業", "選課作業"]["匯出"].Size = RibbonBarButton.MenuButtonSize.Large;

            Catalog button_exportSubject = RoleAclSource.Instance["教務作業"]["功能按鈕"];
            button_exportSubject.Add(new RibbonFeature("Button_Subject_Export", "匯出科目資料"));
            MotherForm.RibbonBarItems["教務作業", "選課作業"]["匯出"]["匯出科目資料"].Enable = UserAcl.Current["Button_Subject_Export"].Executable;

            MotherForm.RibbonBarItems["教務作業", "選課作業"]["匯出"]["匯出科目資料"].Click += delegate
            {
                (new Export.Subject_Export()).ShowDialog();
            };

            #endregion

            #region 匯出學生選修科目

            //Catalog button_exportSSAttend_Student = RoleAclSource.Instance["教務作業"]["功能按鈕"];
            //button_exportSSAttend_Student.Add(new RibbonFeature("Button_SSAttend_Student_Export", "匯出學生選修科目"));
            //MotherForm.RibbonBarItems["教務作業", "選課作業"]["匯出"]["匯出學生選修科目"].Enable = UserAcl.Current["Button_SSAttend_Student_Export"].Executable;

            //MotherForm.RibbonBarItems["教務作業", "選課作業"]["匯出"]["匯出學生選修科目"].Click += delegate
            //{
            //    (new Forms.frmSSAttend_Student()).ShowDialog();
            //};

            #endregion

            #region 匯出尚未選課學生

            Catalog button_exportSSAttend_Student_SelectNone = RoleAclSource.Instance["教務作業"]["功能按鈕"];
            button_exportSSAttend_Student_SelectNone.Add(new RibbonFeature("Button_SSAttend_Student_SelectNone_Export", "匯出尚未選課學生"));
            MotherForm.RibbonBarItems["教務作業", "選課作業"]["匯出"]["匯出尚未選課學生"].Enable = UserAcl.Current["Button_SSAttend_Student_SelectNone_Export"].Executable;

            MotherForm.RibbonBarItems["教務作業", "選課作業"]["匯出"]["匯出尚未選課學生"].Click += delegate
            {
                (new Export.SSAttend_NoneSelectStudent_Export()).ShowDialog();
            };

            #endregion

            #region 匯出科目選課學生

            Catalog button_exportSSAttend_Subject = RoleAclSource.Instance["教務作業"]["功能按鈕"];
            button_exportSSAttend_Subject.Add(new RibbonFeature("Button_SSAttend_Subject_Export", "匯出科目選課學生"));
            MotherForm.RibbonBarItems["教務作業", "選課作業"]["匯出"]["匯出科目選課學生"].Enable = UserAcl.Current["Button_SSAttend_Subject_Export"].Executable;

            MotherForm.RibbonBarItems["教務作業", "選課作業"]["匯出"]["匯出科目選課學生"].Click += delegate
            {
                (new Export.SSAttend_Student_Export()).ShowDialog();
            };

            #endregion

            #region 匯入科目

            MotherForm.RibbonBarItems["教務作業", "選課作業"]["匯入"].Image = Properties.Resources.Import_Image;
            MotherForm.RibbonBarItems["教務作業", "選課作業"]["匯入"].Size = RibbonBarButton.MenuButtonSize.Large;

            Catalog button_importSubject = RoleAclSource.Instance["教務作業"]["功能按鈕"];
            button_importSubject.Add(new RibbonFeature("Button_Subject_Import", "匯入科目資料"));
            MotherForm.RibbonBarItems["教務作業", "選課作業"]["匯入"]["匯入科目資料"].Enable = UserAcl.Current["Button_Subject_Import"].Executable;

            MotherForm.RibbonBarItems["教務作業", "選課作業"]["匯入"]["匯入科目資料"].Click += delegate
            {
                (new Import.Subject_Import()).Execute();
            };

            #endregion

            #region 查詢科目選課學生

            MotherForm.RibbonBarItems["教務作業", "選課作業"]["查詢"].Image = Properties.Resources.searchHistory;
            MotherForm.RibbonBarItems["教務作業", "選課作業"]["查詢"].Size = RibbonBarButton.MenuButtonSize.Large;

            Catalog button_Query_SSAttend_Subject = RoleAclSource.Instance["教務作業"]["功能按鈕"];
            button_Query_SSAttend_Subject.Add(new RibbonFeature("Button_SSAttend_Subject_Query", "查詢科目選課學生"));
            MotherForm.RibbonBarItems["教務作業", "選課作業"]["查詢"]["科目選課學生"].Enable = UserAcl.Current["Button_SSAttend_Subject_Query"].Executable;

            MotherForm.RibbonBarItems["教務作業", "選課作業"]["查詢"]["科目選課學生"].Click += delegate
            {
                (new Forms.frmSSAttend_Subject()).ShowDialog();
            };

            #endregion

            #region 列印班級學生選修科目清單

            MotherForm.RibbonBarItems["班級", "選課"]["報表"].Image = Properties.Resources.paste_64;
            MotherForm.RibbonBarItems["班級", "選課"]["報表"].Size = RibbonBarButton.MenuButtonSize.Large;

            Catalog button_Report_SSAttend_Student = RoleAclSource.Instance["班級"]["功能按鈕"];
            button_Report_SSAttend_Student.Add(new RibbonFeature("Button_SSAttend_Student_Report", "列印班級學生選修科目清單"));
            MotherForm.RibbonBarItems["班級", "選課"]["報表"]["學生選修科目清單"].Enable = UserAcl.Current["Button_SSAttend_Student_Report"].Executable;

            MotherForm.RibbonBarItems["班級", "選課"]["報表"]["學生選修科目清單"].Click += delegate
            {
                (new Report.Class_SSAttend()).Execute();
            };

            #endregion

            #region 列印科目選修學生名單

            MotherForm.RibbonBarItems["教務作業", "選課作業"]["報表"].Image = Properties.Resources.paste_64;
            MotherForm.RibbonBarItems["教務作業", "選課作業"]["報表"].Size = RibbonBarButton.MenuButtonSize.Large;

            Catalog button_Report_SSAttend_Subject = RoleAclSource.Instance["教務作業"]["功能按鈕"];
            button_Report_SSAttend_Subject.Add(new RibbonFeature("Button_SSAttend_Subject_Report", "列印科目選修學生名單"));
            MotherForm.RibbonBarItems["教務作業", "選課作業"]["報表"]["科目選修學生名單"].Enable = UserAcl.Current["Button_SSAttend_Subject_Report"].Executable;

            MotherForm.RibbonBarItems["教務作業", "選課作業"]["報表"]["科目選修學生名單"].Click += delegate
            {
                (new Report.Subject_SSAttend()).Execute();
            };

            #endregion

            #endregion
        }
    }
}
