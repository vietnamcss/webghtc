using Constracts;
using Models.System;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace apiPrivate.Controllers
{
    public class integrationController : ApiController
    {
        private static string connString = ConfigurationManager.AppSettings["OracleConnectionString"];
        private static string _path = ConfigurationManager.AppSettings["LogPath"];
        [HttpPost]
        public object Post([FromBody] infoBody DATA)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            new Common().LogWrite(_path, Request.Headers.ToString() + javaScriptSerializer.Serialize(DATA), "integration_"+  System.DateTime.Now.ToString("yyyyMMdd") + "_log.txt");
            msgSuccessInfo _msgSuccessInfo = new msgSuccessInfo(); 
            string _sing = new Common()._integration(DATA); 
            string a = new Common().integrationApi(
                   connString
                 , (decimal?)null
                 , DATA.Partner
                 , DATA.Type
                 , DATA.Status
                 , javaScriptSerializer.Serialize(DATA)
                 , _sing
                 , DATA.TableName
                 , DATA.Records_ID
                 , DATA.Ref
                 , DATA.Note
                );

            if (a == "OK")
            {
                _msgSuccessInfo.status = 200;
                _msgSuccessInfo.error = false;
                _msgSuccessInfo.message = "SUCCESS";
                _msgSuccessInfo.data = null;
            }
            else
            {
                _msgSuccessInfo.status = 201;
                _msgSuccessInfo.error = false;
                _msgSuccessInfo.message = "ERROR";
                _msgSuccessInfo.data = a;
            }
            return _msgSuccessInfo;
        }
    }
}
