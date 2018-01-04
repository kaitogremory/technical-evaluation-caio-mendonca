//using Business.Base;
using Business.Entities;
using Common.Entities;
using Common.Enums;
using Common.Interfaces;
using DataAccess.Entities;
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
        private EmployeeBusinessFacade _EmployeeBusinessFacade = new EmployeeBusinessFacade(new EmployeeDataAccess());

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEmployeeTable()
        {
            List<Employee> model = _EmployeeBusinessFacade.GetEmployeeList();

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
            _EmployeeBusinessFacade.Delete(idEmployee);

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