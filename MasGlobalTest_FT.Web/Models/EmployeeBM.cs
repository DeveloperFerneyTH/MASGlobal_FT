using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasGlobalTest_FT.Web.Models
{
    public class EmployeeBM
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public decimal HourlySalary { get; set; }
        public decimal monthlySalary { get; set; }
        public string AnualSalary { get; set; }

        #endregion
    }
}