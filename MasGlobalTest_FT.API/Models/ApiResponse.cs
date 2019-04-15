using MasGlobalTest_FT.BL.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasGlobalTest_FT.API.Models
{
    public class ApiResponse
    {
        #region Properties

        public bool Success { get; set; }
        public string Message { get; set; }

        #endregion
    }

    public class ApiResponseSingle : ApiResponse
    {
        #region Properties

        public EmployeeBM Data { get; set; }

        #endregion
    }

    public class ApiResponseList : ApiResponse
    {
        #region Properties

        public IEnumerable<EmployeeBM> Data { get; set; }

        #endregion
    }

    public class ApiResponseOperations : ApiResponse
    {
        #region Properties

        public decimal Data { get; set; }

        #endregion
    }
}