using Common.Entities;
using Newtonsoft.Json;
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
            if(id.HasValue)
            {
                ViewBag.Title = "Editar Empregado";
                ViewBag.Employee = base.GetEmployeeById(id.Value);
            }
            else
            {
                ViewBag.Title = "Novo Empregado";
                ViewBag.Employee = new Employee();
            }
            
            ViewBag.RoleList = base.GetRoleList();
            
            return View();
        }

        public JsonResult Save(string jsonString)
        {
            var register = JsonConvert.DeserializeObject<Employee>(jsonString);

            //salvar o registro

            string errorMessage = Validate(register);
            bool error = errorMessage != String.Empty;


            return new JsonResult
            {
                Data =
                    new
                    {
                        success = !error,
                        register = new
                        {
                            message = error ? errorMessage : "Empregado salvo com sucesso!"
                        }
                    },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public string Validate(Employee register)
        {
            string errorMessage = String.Empty;
            List<string> errorList = new List<string>();

            if (register.Name == String.Empty || register.Name.Length < 3)
            {
                errorList.Add("O campo nome deve conter pelo menos 4 caracteres");
            }

            if (register.Email == String.Empty || register.Email.Length < 3)
            {
                errorList.Add("O campo e-mail deve conter pelo menos 4 caracteres");
            }

            if (!register.Genre.HasValue)
            {
                errorList.Add("O campo gênero deve ser preenchido");
            }

            if(!register.Birth.HasValue)
            {
                errorList.Add("O campo data de nascimento deve ser preenchido");
            }

            if (register.Role.Id == 0)
            {
                errorList.Add("O campo cargo deve ser preenchido");
            }

            foreach (var err in errorList)
            {
                errorMessage += err + ", ";
            }

            if (errorList.Count > 0)
            {
                errorMessage = errorMessage.Remove(errorMessage.Length - 2);
            }

            return errorMessage;
        }
    }
}