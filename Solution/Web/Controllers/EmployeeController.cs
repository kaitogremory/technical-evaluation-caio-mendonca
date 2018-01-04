using Common.Entities;
using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers
{
    public class EmployeeController : ApplicationController
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEmployeeTable()
        {
            List<Employee> model = base.GetEmployeeList();

            string tableHtml = base.RenderRazorViewToString("Employee/EmployeeTable", model);

            return new JsonResult
            {
                Data =
                    new
                    {                        
                        register = new
                        {                            
                            tableHtml = tableHtml
                        }
                    },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public JsonResult Delete(int idEmployee)
        {
            //to-do excluir o empregado

            return new JsonResult
            {
                Data =
                    new
                    {
                        register = new
                        {
                            message = "Empregado excluído com sucesso!"
                        }
                    },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}