using CoreCourse.StateMgmt.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreCourse.StateMgmt.Web.Controllers
{
    public class ClientStateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PickDestinationQuery([FromQuery]string[] inventory)
        {
            ElmoStatusVm vm = new ElmoStatusVm();
            vm.Inventory = inventory;
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PickDestinationPost([FromForm]string[] inventory)
        {
            ElmoStatusVm vm = new ElmoStatusVm();
            vm.Inventory = inventory;
            return View(vm);
        }

        public IActionResult FreezingMountains(string[] inventory)
        {
            ElmoStatusVm vm = new ElmoStatusVm();
            vm.Location = "the freezing mountains";
            vm.Inventory = inventory;

            if (inventory.Contains("coat"))
                vm.Status = GenerateStatusText(vm.Location, "coat", true);
            else
                vm.Status = GenerateStatusText(vm.Location, "coat", false);
            return View("ArriveAtDestination", vm);
        }


        public IActionResult ScorchingDesert(string[] inventory)
        {
            ElmoStatusVm vm = new ElmoStatusVm();
            vm.Location = "the scorching desert";
            vm.Inventory = inventory;

            if (inventory.Contains("parasol"))
                vm.Status = GenerateStatusText(vm.Location, "parasol", true);
            else
                vm.Status = GenerateStatusText(vm.Location, "parasol", false);
            return View("ArriveAtDestination", vm);
        }

        private string GenerateStatusText(string location, string item, bool survives)
        {
            if(survives)
                return $"Elmo comes to {location}. Luckily he's got a {item} and survives!";
            else
                return $"Elmo comes to {location}. Unfortunately he didn't bring a {item} and dies...";
        }

    }
}