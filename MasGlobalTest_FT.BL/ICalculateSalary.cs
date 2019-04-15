using MasGlobalTest_FT.BL.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasGlobalTest_FT.BL
{
    public interface ICalculateSalary
    {
        decimal Calculate(decimal salary);
    }
}
