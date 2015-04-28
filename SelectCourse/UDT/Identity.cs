using System;
using FISCA.UDT;

namespace SelectCourse.UDT
{
    [FISCA.UDT.TableName("ischool.course_selection.identity")]
    public class Identity : ActiveRecord
    {
        internal static void RaiseAfterUpdateEvent()
        {
            if (Identity.AfterUpdate != null)
                Identity.AfterUpdate(null, EventArgs.Empty);
        }

        internal static event EventHandler AfterUpdate;
        /// <summary>
        /// 學生科別代碼
        /// </summary>
        [FISCA.UDT.Field(Field = "ref_dept_id", Indexed = true)]
        public int DeptID { get; set; }

        /// <summary>
        /// 學生年級
        /// </summary>
        [FISCA.UDT.Field(Field = "grade_year", Indexed = true)]
        public int GradeYear { get; set; }
    }
}