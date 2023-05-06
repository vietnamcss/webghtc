using Constracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.administrator
{
    public class getAuthenModel
    {
        public SignInfo SingInData(string connString, string planguage, string pUserName, string pPassWord,decimal ? p_Org_ID, string p_Org_Type, string p_DEVICE_ID, string p_DEVICE_TOKEN, string pSOURCE, string pExtension)
        {
            List<SignInfo> ListsingIn = new List<SignInfo>();
            SignInfo _singInInfo = new SignInfo();
            OracleConnection conn1 = new OracleConnection(connString);
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = conn1;
                conn1.Open();
                oracleCommand.CommandType = CommandType.StoredProcedure;
                oracleCommand.CommandText = "LOGIN_PROCESS.GET_DATA_SINGIN";
                oracleCommand.Parameters.Add("p_UserName", OracleType.VarChar).Value = pUserName;
                oracleCommand.Parameters.Add("p_PassWord", OracleType.VarChar).Value = pPassWord;
                oracleCommand.Parameters.Add("p_Org_ID", OracleType.Number).Value = p_Org_ID;
                oracleCommand.Parameters.Add("p_Org_Type", OracleType.VarChar).Value = p_Org_Type; 
                oracleCommand.Parameters.Add("p_DEVICE_ID", OracleType.VarChar).Value = p_DEVICE_ID;
                oracleCommand.Parameters.Add("p_DEVICE_TOKEN", OracleType.VarChar).Value = p_DEVICE_TOKEN;
                oracleCommand.Parameters.Add("p_SOURCE", OracleType.VarChar).Value = pSOURCE;
                oracleCommand.Parameters.Add("p_Extension", OracleType.VarChar).Value = pExtension;
                oracleCommand.Parameters.Add("p_language", OracleType.VarChar).Value = planguage; 
                oracleCommand.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataReader reader = oracleCommand.ExecuteReader(); 
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SignInfo obj = new SignInfo();
                        obj.userid = (reader["USER_ID"].ToString() == "") ? 0 : Convert.ToDecimal(reader["USER_ID"].ToString());
                        obj.username = reader["USER_NAME"].ToString();
                        obj.code = reader["CODE"].ToString();
                        obj.orgid = (reader["ORG_ID"].ToString() == "") ? 0 : Convert.ToDecimal(reader["ORG_ID"].ToString());
                        obj.orgtype = reader["ORG_TYPE"].ToString();  
                        obj.telephone = reader["TELE_PHONE"].ToString();
                        obj.email = reader["EMAIL"].ToString();
                        obj.displayname = reader["DISPLAY_NAME"].ToString();
                        obj.firstname = reader["FIRST_NAME"].ToString();
                        obj.lastname = reader["LAST_NAME"].ToString();
                        obj.middllename = reader["MIDDLLE_NAME"].ToString();
                        obj.tokenkey = reader["TOKEN_KEY"].ToString();
                        obj.salt = reader["SALT"].ToString();
                        obj.createby = reader["CREATEDBY"].ToString(); 
                        obj.created = reader["CREATED"].ToString();  
                        obj.language = planguage;
                        obj.avatar = reader["AVATAR_SRC"].ToString();
                        obj.position = reader["POSITION_NAME"].ToString();
                        ListsingIn.Add(obj);
                    }
                    _singInInfo = ListsingIn[0];
                }
                reader.Close();
                oracleCommand.Parameters.Clear();
                conn1.Close(); 
                conn1.Dispose(); 
            }
            catch (Exception ex)
            {
                _singInInfo.tokenkey = ex.Message;
                conn1.Close();
                conn1.Dispose();
            }
            return _singInInfo;
        }
        public List<TabRoles> list_TABsByUserID(string connString, string p_TokenKey, string p_LANGUAGE)
        {
            List<TabRoles> TabRolesInfo = new List<TabRoles>();
            OracleConnection conn1 = new OracleConnection(connString);
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = conn1;
                conn1.Open();
                oracleCommand.CommandType = CommandType.StoredProcedure;
                oracleCommand.CommandText = "LOGIN_PROCESS.get_TABsByUserID";
                oracleCommand.Parameters.Add("p_TokenKey", OracleType.VarChar).Value = p_TokenKey;
                oracleCommand.Parameters.Add("p_LANGUAGE", OracleType.VarChar).Value = p_LANGUAGE;
                oracleCommand.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataReader reader = oracleCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TabRoles obj = new TabRoles();
                        obj.tabid = (reader["TAB_ID"].ToString() == "") ? 0 : Convert.ToDecimal(reader["TAB_ID"].ToString());
                        obj.taborder = (reader["TAB_ORDER"].ToString() == "") ? 0 : Convert.ToDecimal(reader["TAB_ORDER"].ToString());
                        obj.tabname = reader["TAB_NAME"].ToString();
                        obj.parentid = (reader["PARENT_ID"].ToString() == "") ? 0 : Convert.ToDecimal(reader["PARENT_ID"].ToString());
                        obj.isvisible = (reader["IS_VISIBLE"].ToString() == "") ? 0 : Convert.ToDecimal(reader["IS_VISIBLE"].ToString());
                        obj.iconfile = reader["ICON_FILE"].ToString();
                        obj.disablelink = (reader["DISABLE_LINK"].ToString() == "") ? 0 : Convert.ToDecimal(reader["DISABLE_LINK"].ToString());
                        obj.title = reader["TITLE"].ToString();
                        obj.description = reader["DESCRIPTION"].ToString();
                        obj.keywords = reader["KEYWORDS"].ToString();
                        obj.skinsrc = reader["SKIN_SRC"].ToString();
                        obj.startdate = reader["START_DATE"].ToString();
                        obj.enddate = reader["END_DATE"].ToString();
                        obj.levelno = (reader["LEVEL_NO"].ToString() == "") ? 0 : Convert.ToDecimal(reader["LEVEL_NO"].ToString());
                        obj.tabpath = reader["TAB_PATH"].ToString();
                        obj.issystem = (reader["IS_SYSTEM"].ToString() == "") ? 0 : Convert.ToDecimal(reader["IS_SYSTEM"].ToString()); 
                        TabRolesInfo.Add(obj);
                    }  
                }
                reader.Close();
                oracleCommand.Parameters.Clear();
                conn1.Close();
                conn1.Dispose();
            }
            catch (Exception ex)
            {
                conn1.Close();
                conn1.Dispose();
            }
            return TabRolesInfo;
        }

    }
}
