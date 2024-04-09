using EmployeeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            var repo = new EmployeeRepository(new EmployeeContext());
            var teste = repo.Get();
            return View();
        }
    }
}
