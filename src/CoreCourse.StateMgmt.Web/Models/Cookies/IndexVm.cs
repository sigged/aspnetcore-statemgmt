using System.Collections.Generic;

namespace CoreCourse.StateMgmt.Web.Models.Cookies
{
    public class IndexVm
    {
        public List<BiscuitVm> Biscuits { get; set; }
        public string SelectedBiscuitImage { get; set; }
        public bool IsPersistent { get; set; }
    }
}

