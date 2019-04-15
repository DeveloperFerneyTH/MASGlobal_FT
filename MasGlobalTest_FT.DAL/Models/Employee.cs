using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasGlobalTest_FT.DAL.Models
{
    public class Employee
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

        #endregion
    }
}
