using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCourse.StateMgmt.Web.Models.Cache
{
    public class ViewPiVm
    {
        /// <summary>
        /// holds the result of the PI calculation
        /// </summary>
        public PIResult Result { get; set; }

        public int CacheDuration { get; set; }
        public TimeSpan ElapsedTime { get; set; }
    }
}
