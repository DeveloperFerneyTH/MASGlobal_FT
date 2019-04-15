using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using MasGlobalTest_FT.Web.Models;

namespace MasGlobalTest_FT.Web
{
    public class EmplooyeeAPI : IEmplooyeeAPI
    {
        private string urlApi = ConfigurationManager.AppSettings["UrlApi"];

        public ApiResponseList GetAllEmployees()
        {
            string api = $"{urlApi}/GetAllEMployees";

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
            ApiResponseList con = js.Deserialize<ApiResponseList>(content);

            return con;
        }

        public ApiResponseSingle GetEmployeeByName(string name)
        {
            string api = $"{urlApi}/GetEmployeeByName/{name}";

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
            ApiResponseSingle con = js.Deserialize<ApiResponseSingle>(content);

            return con;
        }
    }
}