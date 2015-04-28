using System;
using FISCA.UDT;

namespace SelectCourse_JH.UDT
{
    [FISCA.UDT.TableName("ischool.course_selection.ss_attend")]
    public class SSAttend : ActiveRecord
    {
        internal static void RaiseAfterUpdateEvent()
        {
            if (SSAttend.AfterUpdate != null)
                SSAttend.AfterUpdate(null, EventArgs.Empty);
        }

        internal static event EventHandler AfterUpdate;
        /// <summary>
        /// 學生系統編號
        /// </summary>
        [FISCA.UDT.Field(Field = "ref_student_id", Indexed = true)]
        public int StudentID { get; set; }

        /// <summary>
        /// 科目系統編號
        /// </summary>
        [FISCA.UDT.Field(Field = "ref_subject_id", Indexed = true)]
        public int SubjectID { get; set; }
    }
}