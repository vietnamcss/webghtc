using Constracts;
using Models.System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.news
{
    public class newsModels : DataContexBase
    {
        public ListOutFilter NEWS_Find(
                 string OracleConnectionString
               , string p_TokenKey
               , string p_language
               , decimal? p_USER_ID
               , decimal? p_CATEGORIES_ID
               , string p_SEARCH 
               , string p_STATUS
               , string p_START_DATE
               , string p_END_DATE
               , decimal? p_row_start
               , decimal? p_row_end)
        {
            InputFilter _InputFilter = new InputFilter();
            _InputFilter.OracleConnectionString = OracleConnectionString;
            _InputFilter.CursorName = "p_cur";
            _InputFilter.OutName = "p_OutTotal";
            _InputFilter.StoredProcedureName = "PKG_news.NEWS_Find"; 
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "VarChar", p_language, 0);
            dt.Rows.Add("IN", "p_USER_ID", "Number", p_USER_ID, 0);
            dt.Rows.Add("IN", "p_CATEGORIES_ID", "Number", p_CATEGORIES_ID, 0);
            dt.Rows.Add("IN", "p_SEARCH", "VarChar", p_SEARCH, 0); 
            dt.Rows.Add("IN", "p_STATUS", "VarChar", p_STATUS, 0);
            dt.Rows.Add("IN", "p_START_DATE", "DateTime", p_START_DATE, 0); 
            dt.Rows.Add("IN", "p_END_DATE", "DateTime", p_END_DATE, 0); 
            dt.Rows.Add("IN", "p_row_start", "Number", p_row_start, 0);
            dt.Rows.Add("IN", "p_row_end", "Number", p_row_end, 0);
            dt.Rows.Add("OUT", "p_OutTotal", "Number", "", 0);
            return new DataReturn().DataReturnFilter(_InputFilter, dt);
        }
        public ListOutTable get_NEWS_BY_ID(
              string OracleConnectionString
            , string p_TokenKey
            , string p_language
            , decimal? p_NEWS_GUID)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "Varchar", p_language, 0);
            dt.Rows.Add("IN", "p_NEWS_ID", "Number", p_NEWS_GUID, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "p_cur", "PKG_news.get_NEWS_BY_ID", dt);
        }
        public string NEWS_Status(string OracleConnectionString, string p_TokenKey, string p_language, string p_STATUS, string p_NEWS_GUID)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "VarChar", p_language, 0);
            dt.Rows.Add("IN", "p_NEWS_GUID", "VarChar", p_NEWS_GUID, 0);
            dt.Rows.Add("IN", "p_STATUS", "VarChar", p_STATUS, 0);
            dt.Rows.Add("OUT", "p_ERR", "Char", "", 3000);
            return new DataReturn().DataReturnText(OracleConnectionString, "PKG_news.NEWS_Status", dt);
        }

        public string NEWS_UI(
              string OracleConnectionString 
            , string p_TokenKey
            , string p_language
            , decimal? p_NEWS_ID
            , string p_NEWS_GUID
            , string p_BATCH_NO
            , string p_TITLE
            , string p_SLUG
            , string p_SHORT_DESCRIPTION
            , string p_CREATED_AT
            , string p_PUBLISH_AT
            , string p_FEATURE_IMG
            , string p_STATUS
            , string p_VIEWS_COUNT
            , decimal? p_CATEGORIES_ID
            , string p_NOTE
            , string p_ADS_KEYWORDS
            , string p_ADS_DESCRIPTION
            , string p_ADS_TAGS
            )
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "VarChar", p_language, 0);
            dt.Rows.Add("IN", "p_NEWS_ID", "Number", p_NEWS_ID, 0);
            dt.Rows.Add("IN", "p_NEWS_GUID", "VarChar", p_NEWS_GUID, 0);
            dt.Rows.Add("IN", "p_BATCH_NO", "VarChar", p_BATCH_NO, 0); 
            dt.Rows.Add("IN", "p_TITLE", "VarChar", p_TITLE, 0);
            dt.Rows.Add("IN", "p_SLUG", "VarChar", p_SLUG, 0);
            dt.Rows.Add("IN", "p_SHORT_DESCRIPTION", "VarChar", p_SHORT_DESCRIPTION, 0);
            dt.Rows.Add("IN", "p_CREATED_AT", "DateTime", p_CREATED_AT, 1);
            dt.Rows.Add("IN", "p_PUBLISH_AT", "DateTime", p_PUBLISH_AT, 1);
            dt.Rows.Add("IN", "p_FEATURE_IMG", "VarChar", p_FEATURE_IMG, 0);
            dt.Rows.Add("IN", "p_STATUS", "VarChar", p_STATUS, 0);
            dt.Rows.Add("IN", "p_VIEWS_COUNT", "Number", p_VIEWS_COUNT, 0);
            dt.Rows.Add("IN", "p_CATEGORIES_ID", "Number", p_CATEGORIES_ID, 0);
            dt.Rows.Add("IN", "p_NOTE", "VarChar", p_NOTE, 0);
            dt.Rows.Add("IN", "p_ADS_KEYWORDS", "VarChar", p_ADS_KEYWORDS, 0);
            dt.Rows.Add("IN", "p_ADS_DESCRIPTION", "VarChar", p_ADS_DESCRIPTION, 0);
            dt.Rows.Add("IN", "p_ADS_TAGS", "VarChar", p_ADS_TAGS, 0); 
            dt.Rows.Add("OUT", "p_ERR", "Char", "", 3000);
            return new DataReturn().DataReturnText(OracleConnectionString, "PKG_news.NEWS_UI", dt);
        }

        public string NEWS_UI_ADD(
              string OracleConnectionString
            , string p_TokenKey
            , string p_language
            , decimal? p_NEWS_ID 
            , string p_BATCH_NO
            , string p_TITLE
            , string p_SLUG
            , string p_SHORT_DESCRIPTION
            , string p_CREATED_AT
            , string p_PUBLISH_AT
            , string p_FEATURE_IMG
            , string p_STATUS
            , string p_VIEWS_COUNT
            , decimal? p_CATEGORIES_ID
            , string p_NOTE
            , string p_ADS_KEYWORDS
            , string p_ADS_DESCRIPTION
            , string p_ADS_TAGS
            ,string p_DESCRIPTION)
        {
            string _err = "";
            string guid = Guid.NewGuid().ToString();
            _err = NEWS_UI(  OracleConnectionString
            ,   p_TokenKey
            ,   p_language
            ,   p_NEWS_ID
            ,   guid
            ,   p_BATCH_NO
            ,   p_TITLE
            ,   p_SLUG
            ,   p_SHORT_DESCRIPTION
            ,   p_CREATED_AT
            ,   p_PUBLISH_AT
            ,   p_FEATURE_IMG
            ,   p_STATUS
            ,   p_VIEWS_COUNT
            ,   p_CATEGORIES_ID
            ,   p_NOTE
            ,   p_ADS_KEYWORDS
            ,   p_ADS_DESCRIPTION
            ,   p_ADS_TAGS);
            if (_err == "OK")
            {
                clsOracle db = new clsOracle(OracleConnectionString);
                try
                {
                    string _DESCRIPTION = "SELECT DESCRIPTION FROM NEWS WHERE NEWS_GUID='" + guid + "' FOR UPDATE";
                    db.InsertCLOB(_DESCRIPTION, p_DESCRIPTION);
                    db.CloseDatabase();
                }
                catch (Exception ex)
                {
                    _err = ex.Message;
                    db.CloseDatabase();
                }

            }
            return _err;
        }

        //
        public ListOutFilter NEWS_CATEGORIES_Find(
                 string OracleConnectionString
               , string p_TokenKey
               , string p_language 
               , string p_SEARCH
               , string p_STATUS
               , decimal? p_row_start
               , decimal? p_row_end)
        {
            InputFilter _InputFilter = new InputFilter();
            _InputFilter.OracleConnectionString = OracleConnectionString;
            _InputFilter.CursorName = "p_cur";
            _InputFilter.OutName = "p_OutTotal";
            _InputFilter.StoredProcedureName = "PKG_news.NEWS_CATEGORIES_Find";
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "VarChar", p_language, 0); 
            dt.Rows.Add("IN", "p_SEARCH", "VarChar", p_SEARCH, 0);
            dt.Rows.Add("IN", "p_STATUS", "VarChar", p_STATUS, 0);
            dt.Rows.Add("IN", "p_row_start", "Number", p_row_start, 0);
            dt.Rows.Add("IN", "p_row_end", "Number", p_row_end, 0);
            dt.Rows.Add("OUT", "p_OutTotal", "Number", "", 0);
            return new DataReturn().DataReturnFilter(_InputFilter, dt);
        }
        public ListOutTable get_NEWS_CATEGORIES_BY_ID(
              string OracleConnectionString
            , string p_TokenKey
            , string p_language
            , decimal ? p_ID)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "Varchar", p_language, 0);
            dt.Rows.Add("IN", "p_ID", "Number", p_ID, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "p_cur", "PKG_news.get_NEWS_CATEGORIES_BY_ID", dt);
        }
        public string NEWS_CATEGORIES_Status(string OracleConnectionString, string p_TokenKey, string p_language, string p_STATUS, decimal ? p_ID)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "VarChar", p_language, 0);
            dt.Rows.Add("IN", "p_ID", "Number", p_ID, 0);
            dt.Rows.Add("IN", "p_STATUS", "VarChar", p_STATUS, 0);
            dt.Rows.Add("OUT", "p_ERR", "Char", "", 3000);
            return new DataReturn().DataReturnText(OracleConnectionString, "PKG_news.NEWS_CATEGORIES_Status", dt);
        }

        public string NEWS_CATEGORIES_UI(
            string OracleConnectionString
            , string p_TokenKey
            , string p_language
            , decimal? p_ID
            , string p_NAME 
            , string p_SLUG
            , int p_SORT_ORDER 
            , string p_STATUS 
            , decimal? p_PARENT_CATEGORY_ID
            , string p_NOTE 
            )
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "VarChar", p_language, 0);
            dt.Rows.Add("IN", "p_ID", "Number", p_ID, 0); 
            dt.Rows.Add("IN", "p_NAME", "VarChar", p_NAME, 0);
            dt.Rows.Add("IN", "p_SLUG", "VarChar", p_SLUG, 0);
            dt.Rows.Add("IN", "p_SORT_ORDER", "Number", p_SORT_ORDER, 0); 
            dt.Rows.Add("IN", "p_STATUS", "VarChar", p_STATUS, 0);
            dt.Rows.Add("IN", "p_PARENT_CATEGORY_ID", "Number", p_PARENT_CATEGORY_ID, 0); 
            dt.Rows.Add("IN", "p_NOTE", "VarChar", p_NOTE, 0); 
            dt.Rows.Add("OUT", "p_ERR", "Char", "", 3000);
            return new DataReturn().DataReturnText(OracleConnectionString, "PKG_news.NEWS_CATEGORIES_UI", dt);
        }
        public ListOutTable get_NEWS_TYPE(
            string OracleConnectionString
          , string p_TokenKey
          , string p_language
          , string p_TYPE)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "Varchar", p_language, 0);
            dt.Rows.Add("IN", "p_TYPE", "Varchar", p_TYPE, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "p_cur", "PKG_news.get_NEWS_TYPE", dt);
        } 
        public ListOutFilter SELL_NEWS_Find(string OracleConnectionString, string p_TokenKey, string p_language, decimal? p_ORG_ID, decimal? p_WAREHOUSE_ID, string p_CATEGORY, string p_SEARCH,  decimal? p_row_start, decimal p_row_end)
        {
            InputFilter _InputFilter = new InputFilter();
            _InputFilter.OracleConnectionString = OracleConnectionString;
            _InputFilter.CursorName = "p_cur";
            _InputFilter.OutName = "p_OutTotal";
            _InputFilter.StoredProcedureName = "PKG_news.SELL_NEWS_Find";
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "VarChar", p_language, 0);
            dt.Rows.Add("IN", "p_ORG_ID", "Number", p_ORG_ID, 0);
            dt.Rows.Add("IN", "p_WAREHOUSE_ID", "Number", p_WAREHOUSE_ID, 0);
            dt.Rows.Add("IN", "p_CATEGORY", "VarChar", p_CATEGORY, 0);
            dt.Rows.Add("IN", "p_SEARCH", "VarChar", p_SEARCH, 0); 
            dt.Rows.Add("IN", "p_row_start", "Number", p_row_start, 0);
            dt.Rows.Add("IN", "p_row_end", "Number", p_row_end, 0);
            dt.Rows.Add("OUT", "p_OutTotal", "Number", "", 0);
            return new DataReturn().DataReturnFilter(_InputFilter, dt);
        }

        public ListOutTable get_SELL_NEWS_DETAIL(
            string OracleConnectionString
          , string p_TokenKey
          , string p_language
          , string p_KEY)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "Varchar", p_language, 0);
            dt.Rows.Add("IN", "p_KEY", "Varchar", p_KEY, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "p_NEWS", "PKG_news.get_SELL_NEWS_DETAIL", dt);
        } 
        public ListOutTable get_NEWS_DETAIL(
           string OracleConnectionString
         , string p_TokenKey
         , string p_language
         , string p_TYPE
         , decimal ? p_CATEGORIES_ID)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "Varchar", p_language, 0);
            dt.Rows.Add("IN", "p_TYPE", "Varchar", p_TYPE, 0);
            dt.Rows.Add("IN", "p_CATEGORIES_ID", "Number", p_CATEGORIES_ID, 0); 
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "p_NEWS", "PKG_news.get_NEWS_DETAIL", dt);
        }

    }
}
