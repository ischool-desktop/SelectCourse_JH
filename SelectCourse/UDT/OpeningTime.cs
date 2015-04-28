using System;
using FISCA.UDT;

namespace SelectCourse_JH.UDT
{
    [FISCA.UDT.TableName("ischool.course_selection.opening_time")]
    public class OpeningTime : ActiveRecord
    {
        internal static void RaiseAfterUpdateEvent()
        {
            if (OpeningTime.AfterUpdate != null)
                OpeningTime.AfterUpdate(null, EventArgs.Empty);
        }

        internal static event EventHandler AfterUpdate;
        /// <summary>
        /// 開放選課開始時間
        /// </summary>
        [FISCA.UDT.Field(Field = "start_time", Indexed = true)]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 開放選課結束時間
        /// </summary>
        [FISCA.UDT.Field(Field = "end_time", Indexed = true)]
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 開放選課學年度
        /// </summary>
        [FISCA.UDT.Field(Field = "school_year", Indexed = true)]
        public int SchoolYear { get; set; }

        /// <summary>
        /// 開放選課學期
        /// </summary>
        [FISCA.UDT.Field(Field = "semester", Indexed = true)]
        public int Semester { get; set; }
    }
}