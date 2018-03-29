using System;
using System.Collections.Generic;
using CoreCourse.StateMgmt.Web.Models.SessionState;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Linq;

namespace CoreCourse.StateMgmt.Web.Controllers
{
    public class SessionStateController : Controller
    {
        const string STATEKEY = "SessionBeers";

        List<BeerVm> AllBeers = new List<BeerVm> {
            new BeerVm { Name = "Brugse Zot", ImageName = "brugsezot" },
            new BeerVm { Name = "Duvel", ImageName = "duvel" },
            new BeerVm { Name = "Grimbergen", ImageName = "grimbergen" },
            new BeerVm { Name = "La Chouffe", ImageName = "lachouffe" },
            new BeerVm { Name = "Leffe", ImageName = "leffe" }
        };

        public IActionResult Index()
        {
            var vm = new IndexVm();
            vm.Beers = AllBeers;
            vm.ShoppingCart = new List<BeerVm>();

            string serializedBeers = HttpContext.Session.GetString(STATEKEY);
            if (serializedBeers != null)
            {
                vm.ShoppingCart = JsonConvert.DeserializeObject<List<BeerVm>>(serializedBeers);
            }
            return View("Index", vm);
        }

        [HttpPost]
        public IActionResult AddBeer(IndexVm model)
        {
            //get the selected beer from form
            BeerVm selectedBeer = AllBeers.FirstOrDefault(b => b.Name == model.SelectedBeerName);
            if(selectedBeer == null)
            {
                return RedirectToAction("Index");
            }

            //retrieve serialized collection from session
            string serializedBeers = HttpContext.Session.GetString(STATEKEY);
            List<BeerVm> beersInShoppingList = new List<BeerVm>();
            if(serializedBeers != null)
            {
                //deserialize JSON string to it's original form
                beersInShoppingList = JsonConvert.DeserializeObject<List<BeerVm>>(serializedBeers);
            }
            //add beer to the List
            beersInShoppingList.Add(selectedBeer);
            //seriaize List to JSON string
            serializedBeers = JsonConvert.SerializeObject(beersInShoppingList);
            //store JSON string in Session State
            HttpContext.Session.SetString(STATEKEY, serializedBeers);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ClearCart()
        {
            HttpContext.Session.Remove(STATEKEY);
            return RedirectToAction("Index");
        }
    }
}