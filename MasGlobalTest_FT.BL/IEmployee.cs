using MasGlobalTest_FT.BL.BindingModels;
using MasGlobalTest_FT.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasGlobalTest_FT.BL
{
    public interface IEmployee
    {
        IEnumerable<EmployeeBM> GetEmployees();        
    }
}
