using Newtonsoft.Json;
using System;
using System.Data;
using System.Runtime.InteropServices;

namespace Constracts
{
    [Serializable]
    public class returnData
    {
        private decimal _id = -1; public decimal id { get { return _id; } set { _id = value; } }
        private string _ERR = ""; public string ERR { get { return _ERR; } set { _ERR = value; } }
    }
    [Serializable]
    public class returnDataPlan
    {
        private string _language = ""; public string language { get { return _language; } set { _language = value; } }
        private string _tokenkey = ""; public string tokenkey { get { return _tokenkey; } set { _tokenkey = value; } }
        private decimal _planid = 0; public decimal planid { get { return _planid; } set { _planid = value; } }
        private decimal _planhisid = 0; public decimal planhisid { get { return _planhisid; } set { _planhisid = value; } }
        private string _note = ""; public string note { get { return _note; } set { _note = value; } }
    }
    [Serializable]
    public class returnDataReport
    {
        private string _language = ""; public string language { get { return _language; } set { _language = value; } }
        private decimal _report_id = 0; public decimal report_id { get { return _report_id; } set { _report_id = value; } }
        private decimal _user_id = 0; public decimal user_id { get { return _user_id; } set { _user_id = value; } }
        private decimal _buu_cuc_id = 0; public decimal buu_cuc_id { get { return _buu_cuc_id; } set { _buu_cuc_id = value; } }
        private string _template = ""; public string template { get { return _template; } set { _template = value; } }
        private string _report_name = ""; public string report_name { get { return _report_name; } set { _report_name = value; } }
        private string _report_value = ""; public string report_value { get { return _report_value; } set { _report_value = value; } }
        private string _quyen = ""; public string quyen { get { return _quyen; } set { _quyen = value; } }
        private string _report_url = ""; public string report_url { get { return _report_url; } set { _report_url = value; } }
        private string _parameter_text = ""; public string parameter_text { get { return _parameter_text; } set { _parameter_text = value; } }
        private string _note = ""; public string note { get { return _note; } set { _note = value; } }
    }
    [Serializable]
    public class returnDataCase
    {
        private string _language = ""; public string language { get { return _language; } set { _language = value; } }
        private string _tokenkey = ""; public string tokenkey { get { return _tokenkey; } set { _tokenkey = value; } }
        private decimal _productid = 0; public decimal productid { get { return _productid; } set { _productid = value; } }
        private decimal _tabid = 0; public decimal tabid { get { return _tabid; } set { _tabid = value; } }
        private string _note = ""; public string note { get { return _note; } set { _note = value; } }
    }

    [Serializable]
    public class returnDatas
    {
        private string _language = ""; public string language { get { return _language; } set { _language = value; } }
        private string _tokenkey = ""; public string tokenkey { get { return _tokenkey; } set { _tokenkey = value; } }
        private decimal _dataid = 0; public decimal dataid { get { return _dataid; } set { _dataid = value; } }
        private decimal _tabid = 0; public decimal tabid { get { return _tabid; } set { _tabid = value; } }
        private string _note = ""; public string note { get { return _note; } set { _note = value; } }
    }
    [Serializable]
    public class InputFilter
    {
        private string _CursorName = ""; public string CursorName { get { return _CursorName; } set { _CursorName = value; } }
        private string _OracleConnectionString = ""; public string OracleConnectionString { get { return _OracleConnectionString; } set { _OracleConnectionString = value; } }
        private string _StoredProcedureName = ""; public string StoredProcedureName { get { return _StoredProcedureName; } set { _StoredProcedureName = value; } }
        private string _OutName = ""; public string OutName { get { return _OutName; } set { _OutName = value; } }
    }
    [Serializable]
    public class ListOutFilter
    {
        private string _OutError = "OK"; public string OutError { get { return _OutError; } set { _OutError = value; } }
        private int _OutTotal = 0; public int OutTotal { get { return _OutTotal; } set { _OutTotal = value; } }
        private DataTable _OutDataTable = null; public DataTable OutDataTable { get { return _OutDataTable; } set { _OutDataTable = value; } }
    }
    [Serializable]
    public class ListOutTable
    {
        private string _OutError = "OK"; public string OutError { get { return _OutError; } set { _OutError = value; } }
        private DataTable _OutDataTable = null; public DataTable OutDataTable { get { return _OutDataTable; } set { _OutDataTable = value; } }
    }
    [Serializable]
    public class ListOutTableText
    {
        private string _OutError = "OK"; public string OutError { get { return _OutError; } set { _OutError = value; } }
        private string _OutText = "OK"; public string OutText { get { return _OutText; } set { _OutText = value; } }
        private DataTable _OutDataTable = null; public DataTable OutDataTable { get { return _OutDataTable; } set { _OutDataTable = value; } }
    }
    [Serializable]
    public class ListOutDataSet
    {
        private string _OutError = "OK"; public string OutError { get { return _OutError; } set { _OutError = value; } }
        private DataSet _OutDataDataSet = null; public DataSet OutDataDataSet { get { return _OutDataDataSet; } set { _OutDataDataSet = value; } }
    }
    [Serializable]
    public class ListBoSungTT
    {
        private decimal _DOCTYPE_ID = 0; public decimal DOCTYPE_ID { get { return _DOCTYPE_ID; } set { _DOCTYPE_ID = value; } }
        private string _DOCTYPE_NAME = ""; public string DOCTYPE_NAME { get { return _DOCTYPE_NAME; } set { _DOCTYPE_NAME = value; } }
    }
    [Serializable]
    public class SignInfo
    {
        
        private decimal _userid = 0; [JsonProperty(PropertyName = "userid")] public decimal userid { get { return _userid; } set { _userid = value; } }
        private decimal _orgid = 0; [JsonProperty(PropertyName = "orgid")] public decimal orgid { get { return _orgid; } set { _orgid = value; } }
        private string _orgtype = null; [JsonProperty(PropertyName = "orgtype")] public string orgtype { get { return _orgtype; } set { _orgtype = value; } }
        private string _username = null; [JsonProperty(PropertyName = "username")] public string username { get { return _username; } set { _username = value; } }
        private string _code = null; [JsonProperty(PropertyName = "code")] public string code { get { return _code; } set { _code = value; } }
        private string _telephone = null; [JsonProperty(PropertyName = "telephone")] public string telephone { get { return _telephone; } set { _telephone = value; } }
        private string _email = null; [JsonProperty(PropertyName = "email")] public string email { get { return _email; } set { _email = value; } }
        private string _displayname = null; [JsonProperty(PropertyName = "displayname")] public string displayname { get { return _displayname; } set { _displayname = value; } }
        private string _firstname = null; [JsonProperty(PropertyName = "firstname")] public string firstname { get { return _firstname; } set { _firstname = value; } }
        private string _lastname = null; [JsonProperty(PropertyName = "lastname")] public string lastname { get { return _lastname; } set { _lastname = value; } }
        private string _middllename = null; [JsonProperty(PropertyName = "middllename")] public string middllename { get { return _middllename; } set { _middllename = value; } }
        private string _tokenkey = null; [JsonProperty(PropertyName = "tokenkey")] public string tokenkey { get { return _tokenkey; } set { _tokenkey = value; } }
        private string _salt = null; [JsonProperty(PropertyName = "salt")] public string salt { get { return _salt; } set { _salt = value; } }
        private string _createby = null; [JsonProperty(PropertyName = "createby")] public string createby { get { return _createby; } set { _createby = value; } }
        private string _created = null; [JsonProperty(PropertyName = "created")] public string created { get { return _created; } set { _created = value; } }
        private string _language = null; [JsonProperty(PropertyName = "language")] public string language { get { return _language; } set { _language = value; } }
        private string _avatar = null; [JsonProperty(PropertyName = "avatar")] public string avatar { get { return _avatar; } set { _avatar = value; } }
        private string _position = null; [JsonProperty(PropertyName = "position")] public string position { get { return _position; } set { _position = value; } }

    }
    [Serializable]
    public class TabRoles
    {
        private decimal _tabid = 0; [JsonProperty(PropertyName = "tab_id")] public decimal tabid { get { return _tabid; } set { _tabid = value; } }
        private decimal _taborder = 0; [JsonProperty(PropertyName = "tab_order")] public decimal taborder { get { return _taborder; } set { _taborder = value; } }
        private string _tabname = null; [JsonProperty(PropertyName = "tab_name")] public string tabname { get { return _tabname; } set { _tabname = value; } }
        private decimal _parentid = 0; [JsonProperty(PropertyName = "parent_id")] public decimal parentid { get { return _parentid; } set { _parentid = value; } }
        private decimal _isvisible = 0; [JsonProperty(PropertyName = "is_visible")] public decimal isvisible { get { return _isvisible; } set { _isvisible = value; } }
        private string _iconfile = null; [JsonProperty(PropertyName = "icon_file")] public string iconfile { get { return _iconfile; } set { _iconfile = value; } }
        private decimal _disablelink = 0; [JsonProperty(PropertyName = "disable_link")] public decimal disablelink { get { return _disablelink; } set { _disablelink = value; } }
        private string _title = null; [JsonProperty(PropertyName = "title")] public string title { get { return _title; } set { _title = value; } }
        private string _description = null; [JsonProperty(PropertyName = "description")] public string description { get { return _description; } set { _description = value; } }
        private string _keywords = null; [JsonProperty(PropertyName = "key_words")] public string keywords { get { return _keywords; } set { _keywords = value; } }
        private string _skinsrc = null; [JsonProperty(PropertyName = "skin_src")] public string skinsrc { get { return _skinsrc; } set { _skinsrc = value; } }
        private string _startdate = null; [JsonProperty(PropertyName = "start_date")] public string startdate { get { return _startdate; } set { _startdate = value; } }
        private string _enddate = null; [JsonProperty(PropertyName = "end_date")] public string enddate { get { return _enddate; } set { _enddate = value; } }
        private decimal _levelno = 0; [JsonProperty(PropertyName = "level_no")] public decimal levelno { get { return _levelno; } set { _levelno = value; } }
        private string _tabpath = null; [JsonProperty(PropertyName = "tab_path")] public string tabpath { get { return _tabpath; } set { _tabpath = value; } }
        private decimal _issystem = 0; [JsonProperty(PropertyName = "is_system")] public decimal issystem { get { return _issystem; } set { _issystem = value; } }

    }
    public class msgSuccessInfo
    {
        private decimal _status = 0; public decimal status { get { return _status; } set { _status = value; } }
        private bool _error = true; public bool error { get { return _error; } set { _error = value; } }
        private string _message = ""; public string message { get { return _message; } set { _message = value; } }
        public object data { get; set; }
    }

    public class requestInfo
    {
        private string _Token = ""; public string Token { get { return _Token; } set { _Token = value; } }
        private string _Body = ""; public string Body { get { return _Body; } set { _Body = value; } }
        private decimal? _RequestId = null; public decimal? RequestId { get { return _RequestId; } set { _RequestId = value; } }
        private string _Request = ""; public string Request { get { return _Request; } set { _Request = value; } }
        private string _Response = ""; public string Response { get { return _Response; } set { _Response = value; } }
        private string _TableName = ""; public string TableName { get { return _TableName; } set { _TableName = value; } }
        private string _RecordsId = ""; public string RecordsId { get { return _RecordsId; } set { _RecordsId = value; } }
        private string _RefId = ""; public string RefId { get { return _RefId; } set { _RefId = value; } }
        private string _Type = ""; public string Type { get { return _Type; } set { _Type = value; } }
        private string _Status = ""; public string Status { get { return _Status; } set { _Status = value; } }
        private string _Msg = ""; public string Msg { get { return _Msg; } set { _Msg = value; } }
    }
}
