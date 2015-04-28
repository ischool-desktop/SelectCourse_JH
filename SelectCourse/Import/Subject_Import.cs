using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using EMBA.DocumentValidator;
using EMBA.Import;
using EMBA.Validator;
using FISCA.Data;
using FISCA.UDT;

namespace SelectCourse_JH.Import
{
    class Subject_Import : ImportWizard
    {
        ImportOption mOption;
        string keyField;
        AccessHelper Access;
        QueryHelper queryHelper;
        public Subject_Import()
        {
            this.IsSplit = false;
            this.ShowAdvancedForm = false;
            this.ValidateRuleFormater = XDocument.Parse(Properties.Resources.format);
            //this.CustomValidate = null;
            //this.SplitThreadCount = 5;
            //this.SplitSize = 3000;

            keyField = string.Empty;
            Access = new AccessHelper();
            queryHelper = new QueryHelper();

            this.CustomValidate = (Rows, Messages) =>
            {
                CustomValidator(Rows, Messages);
            };
        }

        public void CustomValidator(List<IRowStream> Rows, RowMessages Messages)
        {
            #  region 驗證流程
            if (this.SelectedKeyFields.Contains("科目系統編號"))
                keyField = "科目系統編號";
            else
                keyField = "學年度+學期+科目名稱+級別";

            //  若「科目系統編號」不為空白，則必須存在於資料庫中。
            DataTable dataTableSubjects = queryHelper.Select("select uid, subject_name, level, school_year, semester from $ischool.course_selection.subject");
            IEnumerable<DataRow> subjects = dataTableSubjects.Rows.Cast<DataRow>();

            Rows.ForEach((x) =>
            {
                string subject_uid = x.GetValue("科目系統編號").Trim();
                string school_year = x.GetValue("學年度").Trim();
                string semester = x.GetValue("學期").Trim();
                string subject_name = x.GetValue("科目名稱").Trim();
                string level = x.GetValue("級別").Trim();

                //  若鍵值為「科目系統編號」，則必須存在於系統中，且「學年度+學期+科目名稱+級別」不可重覆
                if (keyField == "科目系統編號")
                {
                    if (!string.IsNullOrEmpty(subject_uid))
                    {
                        //  「科目系統編號」必須存在。
                        if (subjects.Where(y => (y["uid"] + "").Trim() == subject_uid).Count() == 0)
                            Messages[x.Position].MessageItems.Add(new MessageItem(EMBA.Validator.ErrorType.Error, EMBA.Validator.ValidatorType.Row, "系統無此科目系統編號。"));
                    }
                    //if (!string.IsNullOrEmpty(school_year) && !string.IsNullOrEmpty(semester) && !string.IsNullOrEmpty(subject_name) && !string.IsNullOrEmpty(level))
                    //{
                    //    if (Rows.Where(y => (y.GetValue("學年度").Trim() == school_year)).Where(y => (y.GetValue("學期").Trim() == semester)).Where(y => (y.GetValue("科目名稱").Trim() == subject_name)).Where(y => (y.GetValue("級別").Trim() == level)).Count() > 1)
                    //        Messages[x.Position].MessageItems.Add(new MessageItem(EMBA.Validator.ErrorType.Error, EMBA.Validator.ValidatorType.Row, "「學年度+學期+科目名稱+級別」重覆。"));
                    //}
                }
                else
                {
                    if (string.IsNullOrEmpty(school_year))
                        Messages[x.Position].MessageItems.Add(new MessageItem(EMBA.Validator.ErrorType.Error, EMBA.Validator.ValidatorType.Row, "學年度不可空白。"));
                    if (string.IsNullOrEmpty(semester))
                        Messages[x.Position].MessageItems.Add(new MessageItem(EMBA.Validator.ErrorType.Error, EMBA.Validator.ValidatorType.Row, "學期不可空白。"));
                    if (string.IsNullOrEmpty(subject_name))
                        Messages[x.Position].MessageItems.Add(new MessageItem(EMBA.Validator.ErrorType.Error, EMBA.Validator.ValidatorType.Row, "科目名稱不可空白。"));
                }
            });

            #endregion
        }

        public override XDocument GetValidateRule()
        {
            return XDocument.Parse(Properties.Resources.Subject_Import);
        }

        public override ImportAction GetSupportActions()
        {
            return ImportAction.InsertOrUpdate;
        }

        public override void Prepare(ImportOption Option)
        {
            mOption = Option;
        }

        public override string Import(List<EMBA.DocumentValidator.IRowStream> Rows)
        {
            List<UDT.Subject> ExistingSubjectRecords = Access.Select<UDT.Subject>();

            //  要新增的 CourseRecord 
            List<UDT.Subject> insertSubjectRecords = new List<UDT.Subject>();
            //  要更新的 CourseRecord
            List<UDT.Subject> updateSubjectRecords = new List<UDT.Subject>();
            foreach (IRowStream row in Rows)
            {
                string subject_uid = row.GetValue("科目系統編號").Trim();
                string school_year = row.GetValue("學年度").Trim();
                string semester = row.GetValue("學期").Trim();
                string subject_name = row.GetValue("科目名稱").Trim();
                string level = row.GetValue("級別").Trim();

                UDT.Subject subjectRecord = new UDT.Subject();
                IEnumerable<UDT.Subject> filterSubjectRecords = new List<UDT.Subject>();
                //  若鍵值不為「科目系統編號」，則查出哪些課程是要新增的
                if (keyField != "科目系統編號")
                {
                    filterSubjectRecords = ExistingSubjectRecords.Where(x => (x.SchoolYear.ToString() == school_year)).Where(x => (x.Semester.ToString() == semester)).Where(x => (x.SubjectName.ToString().Trim() == subject_name)).Where(x => ((x.Level.HasValue ? x.Level.Value.ToString() : "") == level));     
                }
                else
                    filterSubjectRecords = ExistingSubjectRecords.Where(x => x.UID == subject_uid);

                if (filterSubjectRecords.Count() > 0)
                    subjectRecord = filterSubjectRecords.ElementAt(0);

                //  寫入： 學年度, 學期, 科目名稱, 級別, 學分, 課程類別, 修課人數上限, 教學目標, 教學內容, 備註    
                if (keyField != "科目系統編號")
                {
                    subjectRecord.SchoolYear = int.Parse(school_year);
                    subjectRecord.Semester = int.Parse(semester);
                    subjectRecord.SubjectName = subject_name;
                    if (!string.IsNullOrEmpty(level))
                        subjectRecord.Level = int.Parse(level);
                }
                else
                {
                    if (mOption.SelectedFields.Contains("學年度") && !string.IsNullOrEmpty(school_year))
                        subjectRecord.SchoolYear = int.Parse(school_year);
                    if (mOption.SelectedFields.Contains("學期") && !string.IsNullOrEmpty(semester))
                        subjectRecord.Semester = int.Parse(semester);
                    if (mOption.SelectedFields.Contains("科目名稱") && !string.IsNullOrEmpty(subject_name))
                        subjectRecord.SubjectName = subject_name;
                    if (mOption.SelectedFields.Contains("級別"))
                    {
                        if (string.IsNullOrEmpty(level))
                            subjectRecord.Level = null;
                        else
                            subjectRecord.Level = int.Parse(level);
                    }
                }
                if (mOption.SelectedFields.Contains("學分數"))
                {
                    if (string.IsNullOrEmpty(row.GetValue("學分數")))
                        subjectRecord.Credit = null;
                    else
                        subjectRecord.Credit = int.Parse(row.GetValue("學分數").Trim());
                }
                if (mOption.SelectedFields.Contains("課程類別") && !string.IsNullOrWhiteSpace(row.GetValue("課程類別")))
                    subjectRecord.Type = row.GetValue("課程類別").Trim();

                if (mOption.SelectedFields.Contains("修課人數上限") && !string.IsNullOrWhiteSpace(row.GetValue("修課人數上限")))
                    subjectRecord.Limit = int.Parse(row.GetValue("修課人數上限").Trim());

                if (mOption.SelectedFields.Contains("教學目標") && !string.IsNullOrWhiteSpace(row.GetValue("教學目標")))
                    subjectRecord.Goal = row.GetValue("教學目標").Trim();

                if (mOption.SelectedFields.Contains("教學內容") && !string.IsNullOrWhiteSpace(row.GetValue("教學內容")))
                    subjectRecord.Content = row.GetValue("教學內容").Trim();

                if (mOption.SelectedFields.Contains("備註") && !string.IsNullOrWhiteSpace(row.GetValue("備註")))
                    subjectRecord.Memo = row.GetValue("備註").Trim();

                if (subjectRecord.RecordStatus == RecordStatus.Insert)
                    insertSubjectRecords.Add(subjectRecord);
                else
                    updateSubjectRecords.Add(subjectRecord);
            }
            //  新增科目
            List<string> insertedSubjectIDs = insertSubjectRecords.SaveAll();
            //  更新科目
            List<string> updatedSubjectIDs = updateSubjectRecords.SaveAll();

            //  RaiseEvent
            if (insertedSubjectIDs.Count > 0 || updatedSubjectIDs.Count > 0)
            {
                IEnumerable<string> uids = insertedSubjectIDs.Union(updatedSubjectIDs);
                UDT.Subject.RaiseAfterUpdateEvent();
            }
            return string.Empty;
        }
    }
}