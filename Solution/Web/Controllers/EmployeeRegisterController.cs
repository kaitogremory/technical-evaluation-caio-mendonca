using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers
{
    public class EmployeeRegisterController : ApplicationController
    {
        public ActionResult Index(int? id)
        {
            ViewBag.Title = id.HasValue ? "Editar Empregado" : "Novo Empregado";
            ViewBag.RoleList = base.GetRoleList();
            return View();
        }       
    }
}