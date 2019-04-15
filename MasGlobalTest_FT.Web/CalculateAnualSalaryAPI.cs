using MasGlobalTest_FT.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace MasGlobalTest_FT.Web
{
    public class CalculateAnualSalaryAPI : ICalculateAnualSalaryAPI
    {
        private string urlApi = ConfigurationManager.AppSettings["UrlApi"];

        public ApiResponseOperations Calculate(string contractType, string salary)
        {
            string api = $"{urlApi}/GetSalary/{contractType}/{salary}";

            var request = (HttpWebRequest)WebRequest.Create(api);

            request.Method = "GET";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            var response = (HttpWebResponse)request.GetResponse();

            string content = string.Empty;
            using (var stream = response.GetResponseStream())
            {
                using (var sr = new StreamReader(stream))
                {
                    content = sr.ReadToEnd();
                }
            }

            string result = string.Empty;
            JavaScriptSerializer js = new JavaScriptSerializer();
            ApiResponseOperations con = js.Deserialize<ApiResponseOperations>(content);

            return con;
        }
    }
}