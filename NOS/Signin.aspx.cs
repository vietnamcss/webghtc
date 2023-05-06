using Constracts;
using Librarys;
using Librarys.Ui;
using Models.administrator;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NOS
{
    public partial class Signin : System.Web.UI.Page
    { 
        #region Declarations 
        private static string connString = ConfigurationManager.AppSettings["OracleConnectionString"];
        private static string Language = ConfigurationManager.AppSettings["defaultLanguage"];
        private static string _orgtype = ConfigurationManager.AppSettings["orgtype"];
        private static string _org_id = ConfigurationManager.AppSettings["orgid"];
        private static readonly string PasswordHash = "@v@905e2f031832cbe87e6d93344ecfFE85!0";
        private static readonly string SaltKey = "@aa1df3194fb61c48d14ae095ec580480";
        private static readonly string VIKey = "@ewrwer3D4e5F6g7H8";
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
                txt_user.Text = "";
                txt_pass.Text = "";
                if (Request.Cookies["_asp_authorize_https"] != null)
                {
                    Response.Redirect(ConfigurationManager.AppSettings["getHome"].ToString());
                }
                else
                {
                    Session["_asp_session_tab_roles"] = null;
                }
            }
        }
        #region Process 
        protected void bt_sumit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_user.Text != "" || txt_pass.Text != "")
                {
                    if (hf_aspHttpsguid.Value == "1")
                    {
                        SignInfo _SignInfo = CheckLogin(txt_user.Text, txt_pass.Text);
                        if (_SignInfo.userid != 0)
                        {
                            string v_hash = Library.GetMD5Hash((Library.Encrypt(txt_pass.Text + _SignInfo.telephone, Library.GenerateHash(PasswordHash), Library.GenerateHash(SaltKey), VIKey)) + _SignInfo.createby + _SignInfo.created);
                            if (v_hash.ToUpper() == _SignInfo.salt.ToUpper())
                            {
                                AddSessionUser(_SignInfo);
                                AspSessionPerson(_SignInfo.userid.ToString());
                                Response.Redirect(ConfigurationManager.AppSettings["getHome"]);
                            }
                            else
                            {
                                lbl_error.Text = "Tài khoản hoặc mật khẩu không đúng!";
                            }
                        }
                        else
                        {
                            lbl_error.Text = "Tài khoản hoặc mật khẩu không đúng!";
                        }
                    }
                    else
                    {
                        lbl_error.Text = "Tài khoản hoặc mật khẩu không đúng!";
                    }

                }
                else
                {
                    lbl_error.Text = "Yêu cầu nhập đủ thông tin!";
                }
            }
            catch (Exception ex)
            {
                lbl_error.Text = ex.Message;
            }
        }
        private SignInfo CheckLogin(string taikhoan, string matkhau)
        {
            SignInfo result = new SignInfo();
            HttpBrowserCapabilities browserCapabilities = Request.Browser;
            var obj = new
            {
                ipAddress = HttpContext.Current.Request.UserHostAddress,
                browserName = browserCapabilities.Browser,
                browserVersion = browserCapabilities.Version,
                operatingSystem = getOperatinSystemDetails(Request.UserAgent)
            };
            JavaScriptSerializer objbw = new JavaScriptSerializer();
            string dataBrowser = objbw.Serialize(obj);
            result = new getAuthenModel().SingInData(
                  connString
                , Language
                , taikhoan.ToLower() 
                , Library.GetMD5Hash(Library.GetMD5Hash(matkhau + VIKey))
                , Convert.ToDecimal(_org_id)
                , _orgtype
                , obj.ipAddress
                , Guid.NewGuid().ToString()
                , browserCapabilities.Browser
                , dataBrowser);
            return result;
        }
        private void AspSessionPerson(string p_User_Id)
        {
            if (Request.Cookies["_asp_session_person"] != null)
            {
                Response.Cookies["_asp_session_person"].Expires = DateTime.Now.AddDays(-1.0);
            }
            HttpCookie httpCookie = new HttpCookie("_asp_session_person");
            httpCookie.Value = p_User_Id;
            httpCookie.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(httpCookie);
        }
        private void AddSessionUser(SignInfo _UserInfo)
        {
            if (Request.Cookies["_asp_authorize_https"] != null)
            {
                Response.Cookies["_asp_authorize_https"].Expires = DateTime.Now.AddDays(-1.0);
            }
            JavaScriptSerializer objbw = new JavaScriptSerializer();
            string dataUser = Library.Base64Encode(objbw.Serialize(_UserInfo));
            HttpCookie httpCookie = new HttpCookie("_asp_authorize_https");
            httpCookie.Value = dataUser;
            httpCookie.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(httpCookie);
        }
        public static string getOperatinSystemDetails(string browserDetails)
        {
            try
            {
                switch (browserDetails.Substring(browserDetails.LastIndexOf("Windows NT") + 11, 3).Trim())
                {
                    case "6.2":
                        return "Windows 8";
                    case "6.1":
                        return "Windows 7";
                    case "6.0":
                        return "Windows Vista";
                    case "5.2":
                        return "Windows XP 64-Bit Edition";
                    case "5.1":
                        return "Windows XP";
                    case "5.0":
                        return "Windows 2000";
                    default:
                        return browserDetails.Substring(browserDetails.LastIndexOf("Windows NT"), 14);
                }
            }
            catch
            {
                if (browserDetails.Length > 149)
                    return browserDetails.Substring(0, 149);
                else
                    return browserDetails;
            }
        }
        #endregion

    }
}