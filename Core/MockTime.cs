using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class MockTime
    {
        private DateTime _dateTime;

        public MockTime()
        {
            _dateTime = DateTime.Today;

        }

        public DateTime TodayDate
        {
            get
            {
                return _dateTime;
            }
        }

        public void SetDateTo(DateTime newDate)
        {
            _dateTime = newDate;
        }
    }
}
