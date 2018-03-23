using System.Collections.Generic;

namespace CoreCourse.StateMgmt.Web.Models.SessionState
{
    public class IndexVm
    {
        //form 
        public List<BeerVm> Beers { get; set; }
        public string SelectedBeerName { get; set; }

        //beers already in shopping cart
        public List<BeerVm> ShoppingCart { get; set; }
    }
}

