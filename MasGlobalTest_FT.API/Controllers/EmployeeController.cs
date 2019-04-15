using MasGlobalTest_FT.API.Models;
using MasGlobalTest_FT.BL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MasGlobalTest_FT.API.Controllers
{
    public class EmployeeController : ApiController
    {
        private IEmployee employee;

        // Dependancy inyection
        public EmployeeController(IEmployee _employee)
        {
            employee = _employee;
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/GetAllEMployees")]
        public ApiResponseList GetAllEMployees()
        {
            ApiResponseList response = new ApiResponseList();

            try
            {
                var result = employee.GetEmployees();
                response.Data = result;
                response.Message = "OK";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = $"Error: {ex.Message}";
                response.Success = false;
            }

            return response;
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/GetEmployeeByName/{name}")]
        public ApiResponseSingle GetEmployeeByName(string name)
        {
            ApiResponseSingle response = new ApiResponseSingle();

            try
            {
                var result = employee.GetEmployees().FirstOrDefault(e => e.Name.ToLower().Contains(name.ToLower()));
                response.Data = result;
                response.Message = "OK";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = $"Error: {ex.Message}";
                response.Success = false;
            }

            return response;
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/GetSalary/{contractTypeName}/{salary}")]
        public ApiResponseOperations GetSalary(string contractTypeName, string salary)
        {
            ApiResponseOperations response = new ApiResponseOperations();

            try
            {
                decimal result = 0;
                decimal sa = Convert.ToDecimal(salary);
                const string contractHour = "HourlySalaryEmployee";
                const string contractMonth = "MonthlySalaryEmployee";

                switch (contractTypeName)
                {
                    case contractHour:
                        var calH = new CalculateHourlySalary();
                        result = calH.Calculate(sa);
                        break;

                    case contractMonth:
                        var calM = new CalculateMonthlySalary();
                        result = calM.Calculate(sa);
                        break;
                }

                response.Data = result;
                response.Message = "OK";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = $"Error: {ex.Message}";
                response.Success = false;
            }

            return response;
        }
    }
}