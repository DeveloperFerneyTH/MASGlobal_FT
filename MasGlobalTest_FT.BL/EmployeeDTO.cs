using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasGlobalTest_FT.DAL;
using MasGlobalTest_FT.DAL.Models;
using AutoMapper;
using MasGlobalTest_FT.BL.BindingModels;

namespace MasGlobalTest_FT.BL
{
    public class EmployeeDTO : IEmployee
    {
        private EmployeeDAO employeeDAO = new EmployeeDAO();
        private MapperConfiguration cfgMapper;

        public EmployeeDTO()
        {
            // DTO's configuration
            cfgMapper = new MapperConfiguration(conf =>
            {
                conf.CreateMap<Employee, EmployeeBM>();
            });
        }

        /// <summary>
        /// Get all employees from MASGlobal's API
        /// </summary>
        /// <returns>List of employees</returns>
        public IEnumerable<EmployeeBM> GetEmployees()
        {
            var employees = employeeDAO.GetEmployees();

            // Automaper
            IMapper iMapper = cfgMapper.CreateMapper();
            var result = iMapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeBM>>(employees);
            
            return result;
        }
    }

    /// <summary>
    /// Class that implements interface for calcule of Annual Salary by Hour
    /// </summary>
    public class CalculateHourlySalary : ICalculateSalary
    {
        public decimal Calculate(decimal _salary)
        {
            decimal result = 120 * _salary * 12;
            return result;
        }
    }

    /// <summary>
    /// Class that implements interface for calcule of Annual Salary by Month
    /// </summary>
    public class CalculateMonthlySalary : ICalculateSalary
    {
        public decimal Calculate(decimal salary)
        {
            decimal result = salary * 12;
            return result;
        }
    }
}
