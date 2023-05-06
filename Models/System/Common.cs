using Constracts;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace Models.System
{
    public class Common
    {
        public static string VSEKey = "ZXCpoi%^&";
        public static string Decrypt(string cipherString, bool useHashing)
        {
            byte[] array = Convert.FromBase64String(cipherString);
            string vSEKey = VSEKey;
            byte[] key;
            if (useHashing)
            {
                MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
                key = mD5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(vSEKey));
                mD5CryptoServiceProvider.Clear();
            }
            else
            {
                key = Encoding.UTF8.GetBytes(vSEKey);
            }
            TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
            tripleDESCryptoServiceProvider.Key = key;
            tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
            tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
            ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateDecryptor();
            byte[] bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
            tripleDESCryptoServiceProvider.Clear();
            return Encoding.UTF8.GetString(bytes);
        }
        public void LogWrite(string exePath, string logMessage, string filename)
        {
            string m_exePath = exePath;
            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + filename))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
            }
        }
        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :{0}", logMessage);
            }
            catch (Exception ex)
            {
            }
        }
        public string _integration(infoBody _DATA)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(_DATA.Link);
                if ( _DATA.Headers != null )
                {
                    for (var i = 0; i < _DATA.Headers.Count; i++)
                    {
                        httpWebRequest.Headers[_DATA.Headers[i].Code] = _DATA.Headers[i].Values;
                    }
                }
                httpWebRequest.ContentType = "application/json; charset=UTF-8";
                httpWebRequest.Method = WebRequestMethods.Http.Post;
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(_DATA.Body);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                HttpWebResponse response;
                try
                {
                    response = httpWebRequest.GetResponse() as HttpWebResponse;
                }
                catch (WebException ex)
                {
                    response = ex.Response as HttpWebResponse;
                }
                var streamReader = new StreamReader(response.GetResponseStream());
                var responseString = streamReader.ReadToEnd();
                return responseString;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        } 
        public string integrationApi(
                  string connString
                , decimal? p_REQUEST_ID
                , string p_PARTNER_ID
                , string p_TYPE
                , string p_STATUS
                , string p_REQUEST
                , string p_RESPONSE
                , string p_TABLE_NAME
                , decimal? p_RECORDS_ID
                , string p_REF_VALUE
                , string p_NOTE
       )
        {
            DataTable dt = new DataReturn().CreateTableParameter(1); 
            dt.Rows.Add("IN", "p_REQUEST_ID", "Number", p_REQUEST_ID, 0); 
            dt.Rows.Add("IN", "p_PARTNER_ID", "VarChar", p_PARTNER_ID, 0);
            dt.Rows.Add("IN", "p_TYPE", "VarChar", p_TYPE, 0);
            dt.Rows.Add("IN", "p_STATUS", "VarChar", p_STATUS, 0);
            dt.Rows.Add("IN", "p_REQUEST", "Clob", p_REQUEST, 0);
            dt.Rows.Add("IN", "p_RESPONSE", "Clob", p_RESPONSE, 0);
            dt.Rows.Add("IN", "p_TABLE_NAME", "VarChar", p_TABLE_NAME, 0); 
            dt.Rows.Add("IN", "p_RECORDS_ID", "Number", p_RECORDS_ID, 0);
            dt.Rows.Add("IN", "p_REF_VALUE", "VarChar", p_REF_VALUE, 0);
            dt.Rows.Add("IN", "p_NOTE", "VarChar", p_NOTE, 0);
            dt.Rows.Add("OUT", "p_ERR", "Char", "", 3000);
            return new DataReturn().DataReturnText(connString, "INTEGRATION_PKG.INTEGRATION_UI", dt);
        } 
    }
}