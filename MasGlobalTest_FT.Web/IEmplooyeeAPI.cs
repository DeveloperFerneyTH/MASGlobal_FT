using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasGlobalTest_FT.Web.Models;

namespace MasGlobalTest_FT.Web
{
    public interface IEmplooyeeAPI
    {
        ApiResponseList GetAllEmployees();
        ApiResponseSingle GetEmployeeByName(string name);
    }

    public interface ICalculateAnualSalaryAPI
    {
        ApiResponseOperations Calculate(string contractType, string salary);
    }
}
