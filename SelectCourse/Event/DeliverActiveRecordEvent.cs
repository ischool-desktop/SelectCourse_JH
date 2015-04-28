using System;
using System.Collections.Generic;
using FISCA.UDT;

namespace SelectCourse.Event
{
    public class DeliverActiveRecordEventArgs : EventArgs
    {
        private IEnumerable<ActiveRecord> records;
        public IEnumerable<ActiveRecord> ActiveRecords
        {
            get
            {
                return records;
            }
        }
        public DeliverActiveRecordEventArgs(IEnumerable<ActiveRecord> records)
        {
            this.records = records;
        }
    }
}
