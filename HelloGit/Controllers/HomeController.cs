using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary1;
using HelloGit.Models;

namespace HelloGit.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Manager mgr = new Manager(Properties.Settings.Default.ConStr);
            ViewModel vm = new ViewModel();
            vm.People = mgr.GetAllPeople();
            return View(vm);
        }

        public ActionResult AddForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPeople(List<Person> people)
        {
            Manager mgr = new Manager(Properties.Settings.Default.ConStr);
            mgr.AddPeople(people);
            return RedirectToAction("Index", "Home");
        }
    }
}