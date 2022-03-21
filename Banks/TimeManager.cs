using System;
using System.Collections.Generic;
using System.Text;

namespace Banks
{
    public class TimeManager
    {
        private static TimeManager instance;
        private DateTime? currentDate;

        private TimeManager() { }

        public static TimeManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new TimeManager();
                return instance;
            }
        }

        public DateTime CurrentDate
        {
            get
            {
                if (currentDate.HasValue)
                    return currentDate.Value;
                return DateTime.Now;
            }
            set
            {
                currentDate = value;
            }
        }
    }
}
