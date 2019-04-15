using MasGlobalTest_FT.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasGlobalTest_FT.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmplooyeeAPI employeeAPI;
        private ICalculateAnualSalaryAPI calculateAnualSalaryAPI;

        // Dependicy inyection
        public EmployeeController(IEmplooyeeAPI _employeeAPI, ICalculateAnualSalaryAPI _calculateAnualSalaryAPI)
        {
            employeeAPI = _employeeAPI;
            calculateAnualSalaryAPI = _calculateAnualSalaryAPI;
        }

        // GET: Employee
        public ActionResult Index()
        {            
            return View();
        }

        public JsonResult GetEmployee(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                var result = employeeAPI.GetAllEmployees();

                if (result.Success)
                {
                    foreach (var emp in result.Data)
                    {
                        string anual = calculateAnualSalaryAPI.Calculate(emp.ContractTypeName, 
                                                    emp.ContractTypeName == "HourlySalaryEmployee" ? emp.HourlySalary.ToString()
                                                    : emp.monthlySalary.ToString()).Data.ToString();

                        emp.AnualSalary = anual;
                    }
                }

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = employeeAPI.GetEmployeeByName(name);                

                if (result.Success)
                {
                    var emp = result.Data;

                    emp.AnualSalary = calculateAnualSalaryAPI.Calculate(emp.ContractTypeName,
                                                    emp.ContractTypeName == "HourlySalaryEmployee" ? emp.HourlySalary.ToString()
                                                    : emp.monthlySalary.ToString()).Data.ToString();
                }

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}