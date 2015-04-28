using System;
using FISCA.UDT;

namespace SelectCourse_JH.UDT
{
    [FISCA.UDT.TableName("ischool.course_selection.si_relation")]
    public class SIRelation : ActiveRecord
    {
        internal static void RaiseAfterUpdateEvent()
        {
            if (SIRelation.AfterUpdate != null)
                SIRelation.AfterUpdate(null, EventArgs.Empty);
        }

        internal static event EventHandler AfterUpdate;
        /// <summary>
        /// 科目系統編號
        /// </summary>
        [FISCA.UDT.Field(Field = "ref_subject_id", Indexed = true)]
        public int SubjectID { get; set; }

        /// <summary>
        /// 身分系統編號
        /// </summary>
        [FISCA.UDT.Field(Field = "ref_identity_id", Indexed = true)]
        public int IdentityID { get; set; }
        /// <summary>
        /// 群組
        /// </summary>
        [FISCA.UDT.Field(Field = "group", Indexed = false)]
        public string Group { get; set; }

        /// <summary>
        /// 選課數上限
        /// </summary>
        [FISCA.UDT.Field(Field = "count_limit", Indexed = false)]
        public int CountLimit { get; set; }
    }
}