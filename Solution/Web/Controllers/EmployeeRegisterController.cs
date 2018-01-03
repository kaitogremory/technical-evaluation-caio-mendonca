using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class EmployeeRegisterController : Controller
    {
        public ActionResult Index(int? id)
        {
            ViewBag.Title = id.HasValue ? "Editar" : "Novo";
            return View();
        }       
    }
}