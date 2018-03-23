using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCourse.StateMgmt.Web.Models.Cache
{
    public class PIResult
    {
        public List<int> PiDecimals { get; set; }
        public TimeSpan ElapsedTime { get; set; }
        public int Digits { get; set; }
        public DateTime CacheTime { get; set; }
    }
}
