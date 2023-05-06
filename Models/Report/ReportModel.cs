using Constracts;
using Librarys;
using Models.System;
using Newtonsoft.Json.Linq;
using System;
using System.Data;

namespace Models.Report
{
    public class ReportModel
    {
        public returnDataPlan getReturnPlan(string p_publicKey, string p_Token)
        {
            returnDataPlan _returnDataPlan = new returnDataPlan();
            try
            {
                string _json = new Library().DecodeToken(p_Token.Replace("minus", "--"), p_publicKey);
                var obj = JObject.Parse(_json);
                _returnDataPlan.language = obj["language"].ToString();
                _returnDataPlan.tokenkey = obj["tokenkey"].ToString();
                _returnDataPlan.planid = (obj["planid"].ToString() == "") ? 0 : Convert.ToDecimal(obj["planid"].ToString());
                _returnDataPlan.planhisid = (obj["planhisid"].ToString() == "") ? 0 : Convert.ToDecimal(obj["planhisid"].ToString());
                _returnDataPlan.note = obj["note"].ToString();
            }
            catch (Exception ex)
            {
                _returnDataPlan.note = ex.Message;
            }
            return _returnDataPlan;
        }
        public ListOutTable Report_Excel(string OracleConnectionString, decimal p_report_id, decimal p_user_id)
        {
            DataTable dt = new DataReturn().CreateTableParameter(2);
            dt.Rows.Add("p_REPORT_ID", "Number", p_report_id);
            dt.Rows.Add("p_user_id", "Number", p_user_id);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "cur", "PKG_Report.EXCEL_REPORT", dt);
        }
        public returnDataReport getReturnReport(string p_publicKey, string p_Token)
        {
            returnDataReport _returnDataReport = new returnDataReport();
            try
            {
                string _json = new Library().DecodeToken(p_Token.Replace("--", "minus"), p_publicKey);
                var obj = JObject.Parse(_json);
                _returnDataReport.report_id = (obj["report_id"].ToString() == "") ? 0 : Convert.ToDecimal(obj["report_id"].ToString());
                _returnDataReport.user_id = (obj["user_id"].ToString() == "") ? 0 : Convert.ToDecimal(obj["user_id"].ToString());
                _returnDataReport.template = obj["template"].ToString();
                _returnDataReport.report_name = obj["report_name"].ToString();
                _returnDataReport.report_value = obj["report_value"].ToString();
                _returnDataReport.parameter_text = obj["parameter_text"].ToString();
                _returnDataReport.language = obj["language"].ToString();
                _returnDataReport.note = obj["note"].ToString();
            }
            catch (Exception ex)
            {
                _returnDataReport.note = ex.Message;
            }
            return _returnDataReport;
        }
        public returnDatas getReturnData(string p_publicKey, string p_Token)
        {
            returnDatas _returnDatas = new returnDatas();
            try
            {
                string _json = new Library().DecodeToken(p_Token.Replace("minus", "--"), p_publicKey);
                var obj = JObject.Parse(_json);
                _returnDatas.language = obj["language"].ToString();
                _returnDatas.tokenkey = obj["tokenkey"].ToString();
                _returnDatas.dataid = (obj["dataid"].ToString() == "") ? 0 : Convert.ToDecimal(obj["dataid"].ToString());
                _returnDatas.tabid = (obj["tabid"].ToString() == "") ? 0 : Convert.ToDecimal(obj["tabid"].ToString());
                _returnDatas.note = obj["note"].ToString();
            }
            catch (Exception ex)
            {
                _returnDatas.note = ex.Message;
            }
            return _returnDatas;
        }
        public returnDataCase getReturnProduct(string p_publicKey, string p_Token)
        {
            returnDataCase _returnDataCase = new returnDataCase();
            try
            {
                string _json = new Library().DecodeToken(p_Token.Replace("minus", "--"), p_publicKey);
                var obj = JObject.Parse(_json);
                _returnDataCase.language = obj["language"].ToString();
                _returnDataCase.tokenkey = obj["tokenkey"].ToString();
                _returnDataCase.productid = (obj["productid"].ToString() == "") ? 0 : Convert.ToDecimal(obj["productid"].ToString());
                _returnDataCase.tabid = (obj["tabid"].ToString() == "") ? 0 : Convert.ToDecimal(obj["tabid"].ToString());
                _returnDataCase.note = obj["note"].ToString();
            }
            catch (Exception ex)
            {
                _returnDataCase.note = ex.Message;
            }
            return _returnDataCase;
        }
        public ListOutTable Insert_Report(string OracleConnectionString, string p_language, decimal p_user_id, string p_REPORT_NAME, string p_REPORT_VALUE, string p_PARAMETER_TEXT)
        {
            DataTable dt = new DataReturn().CreateTableParameter(2);
            dt.Rows.Add("p_language", "VarChar", p_language);
            dt.Rows.Add("p_user_id", "Number", p_user_id);
            dt.Rows.Add("p_REPORT_NAME", "VarChar", p_REPORT_NAME);
            dt.Rows.Add("p_REPORT_VALUE", "VarChar", p_REPORT_VALUE);
            dt.Rows.Add("p_PARAMETER_TEXT", "VarChar", p_PARAMETER_TEXT);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "cur", "PKG_Report.Insert_REPORT", dt);
        }
    }
}
