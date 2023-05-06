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
    public class getCategory : DataContexBase
    {
        public ListOutTable get_USER(string OracleConnectionString, string p_TokenKey, string p_language, string p_TYPE, decimal? p_ORG_ID, decimal? p_WAREHOUSE_ID)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "Varchar", p_language, 0);
            dt.Rows.Add("IN", "p_TYPE", "Varchar", p_TYPE, 0);
            dt.Rows.Add("IN", "p_ORG_ID", "Number", p_ORG_ID, 0);
            dt.Rows.Add("IN", "p_WAREHOUSE_ID", "Number", p_WAREHOUSE_ID, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "Cur", "ad_Category.get_USER", dt);
        }
        public ListOutTable get_PRODUCT(string OracleConnectionString, string p_TokenKey, string p_language, string p_PRODUCTTYPE, decimal? p_ORG_ID, decimal? p_WAREHOUSE_ID)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "Varchar", p_language, 0);
            dt.Rows.Add("IN", "p_PRODUCTTYPE", "Varchar", p_PRODUCTTYPE, 0);
            dt.Rows.Add("IN", "p_ORG_ID", "Number", p_ORG_ID, 0);
            dt.Rows.Add("IN", "p_WAREHOUSE_ID", "Number", p_WAREHOUSE_ID, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "Cur", "ad_Category.get_PRODUCT", dt);
        }
        public ListOutTable get_INOUT_TYPE(string OracleConnectionString, string p_TokenKey, string p_language)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "Varchar", p_language, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "Cur", "ad_Category.get_INOUT_TYPE", dt);
        }
        public ListOutTable get_District(string OracleConnectionString, string p_TokenKey, string p_LANGUAGE)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "Varchar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_LANGUAGE", "Varchar", p_LANGUAGE, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "Cur", "ad_Category.get_District", dt);
        }
        public ListOutTable get_WARD(string OracleConnectionString, string p_TokenKey, string p_LANGUAGE, decimal? p_DISTRICT_ID)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "Varchar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_LANGUAGE", "Varchar", p_LANGUAGE, 0);
            dt.Rows.Add("IN", "p_DISTRICT_ID", "Number", p_DISTRICT_ID, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "Cur", "ad_Category.get_WARD", dt);
        }
        public ListOutTable get_ORG_BY_USER(string OracleConnectionString, string p_TokenKey, string p_language)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "Varchar", p_language, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "Cur", "ad_Category.get_ORG_BY_USER", dt);
        }
        public ListOutTable get_WAREHOUSE_BY_USER(string OracleConnectionString, string p_TokenKey, string p_language)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "Varchar", p_language, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "Cur", "ad_Category.get_WAREHOUSE_BY_USER", dt);
        }
        public ListOutTable get_WAREHOUSE_BY_USER(string OracleConnectionString, string p_TokenKey, string p_language, decimal? p_ORGID)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "Varchar", p_language, 0);
            dt.Rows.Add("IN", "p_ORGID", "Number", p_ORGID, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "Cur", "ad_Category.get_WAREHOUSE_BY_USER", dt);
        }

        public ListOutTable get_WAREHOUSE(string OracleConnectionString, string p_TokenKey, string p_language, decimal? p_ORGID)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "Varchar", p_language, 0);
            dt.Rows.Add("IN", "p_ORGID", "Number", p_ORGID, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "Cur", "ad_Category.get_WAREHOUSE", dt);
        }

        public ListOutTable get_PRODUCT_TYPE(string OracleConnectionString, string p_TokenKey, string p_LANGUAGE)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "Varchar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_LANGUAGE", "Varchar", p_LANGUAGE, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "Cur", "ad_Category.get_PRODUCT_TYPE", dt);
        }
        public ListOutTable get_IS_ACTIVE(string OracleConnectionString, string p_TokenKey, string p_LANGUAGE)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "Varchar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_LANGUAGE", "Varchar", p_LANGUAGE, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "Cur", "ad_Category.get_IS_ACTIVE", dt);
        }
        public ListOutTable get_BUY_STATUS(string OracleConnectionString, string p_TokenKey, string p_LANGUAGE, string p_TYPE)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "Varchar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_LANGUAGE", "Varchar", p_LANGUAGE, 0);
            dt.Rows.Add("IN", "p_TYPE", "Varchar", p_TYPE, 0); 
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "Cur", "ad_Category.get_BUY_STATUS", dt);
        }

        public ListOutTable get_POST(string OracleConnectionString, string p_TokenKey, string p_language)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "Varchar", p_language, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "Cur", "ad_Category.get_POST", dt);
        }
        public ListOutTable get_SERVICE(string OracleConnectionString, string p_TokenKey, string p_language)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "Varchar", p_language, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "Cur", "ad_Category.get_SERVICE", dt);
        }
        public ListOutTable get_TYPE_COD(string OracleConnectionString, string p_TokenKey, string p_language)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "Varchar", p_language, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "Cur", "ad_Category.get_TYPE_COD", dt);
        }
        public ListOutTable get_DELIVERY_NOTE(string OracleConnectionString, string p_TokenKey, string p_language)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "Varchar", p_language, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "Cur", "ad_Category.get_DELIVERY_NOTE", dt);
        }

        public ListOutTable get_SOURCE(string OracleConnectionString, string p_TokenKey, string p_language)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "Varchar", p_language, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "Cur", "ad_Category.get_SOURCE", dt);
        }
        public ListOutTable get_REMITTANCE(string OracleConnectionString, string p_TokenKey, string p_language)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "Varchar", p_language, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "Cur", "ad_Category.get_REMITTANCE", dt);
        }
        

        public ListOutTable get_NEWS_STATUS(string OracleConnectionString, string p_TokenKey, string p_LANGUAGE)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "Varchar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_LANGUAGE", "Varchar", p_LANGUAGE, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "Cur", "ad_Category.get_NEWS_STATUS", dt);
        }  
        public ListOutTable get_SUPPLIERS(string OracleConnectionString, string p_TokenKey, string p_language)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "Varchar", p_language, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "Cur", "ad_Category.get_SUPPLIERS", dt);
        }
        public ListOutTable get_NEWS_CATEGORIES(string OracleConnectionString, string p_TokenKey, string p_language, decimal? p_PARENT_CATEGORY_ID)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "Varchar", p_language, 0);
            dt.Rows.Add("IN", "p_PARENT_CATEGORY_ID", "Number", p_PARENT_CATEGORY_ID, 0); 
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "Cur", "ad_Category.get_NEWS_CATEGORIES", dt);
        }
        public ListOutTable get_UNIT(string OracleConnectionString, string p_TokenKey, string p_language)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "Varchar", p_language, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "Cur", "ad_Category.get_UNIT", dt);
        }
        public ListOutTable get_CATEGORY(string OracleConnectionString, string p_TokenKey, string p_language)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "Varchar", p_language, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "Cur", "ad_Category.get_CATEGORY", dt);
        }
        public ListOutTable get_M_INOUT_ACTIVE(string OracleConnectionString, string p_TokenKey, string p_LANGUAGE)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "Varchar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_LANGUAGE", "Varchar", p_LANGUAGE, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "Cur", "ad_Category.get_M_INOUT_ACTIVE", dt);
        }
        public ListOutFilter ORG_Find(string OracleConnectionString, string p_TokenKey, string p_language, decimal? P_PROVINCEID, string p_SEARCH, string p_IS_ACTIVE, decimal? p_row_start, decimal p_row_end)
        {
            InputFilter _InputFilter = new InputFilter();
            _InputFilter.OracleConnectionString = OracleConnectionString;
            _InputFilter.CursorName = "p_cur";
            _InputFilter.OutName = "p_OutTotal";
            _InputFilter.StoredProcedureName = "ad_Category.ORG_Find";
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "VarChar", p_language, 0);
            dt.Rows.Add("IN", "P_PROVINCEID", "Number", P_PROVINCEID, 0);
            dt.Rows.Add("IN", "p_SEARCH", "VarChar", p_SEARCH, 0);
            dt.Rows.Add("IN", "p_IS_ACTIVE", "VarChar", p_IS_ACTIVE, 0);
            dt.Rows.Add("IN", "p_row_start", "Number", p_row_start, 0);
            dt.Rows.Add("IN", "p_row_end", "Number", p_row_end, 0);
            dt.Rows.Add("OUT", "p_OutTotal", "Number", "", 0);
            return new DataReturn().DataReturnFilter(_InputFilter, dt);
        }
        public string ORG_InsUp(string OracleConnectionString
            , string p_TokenKey
            , string p_language
            , decimal? p_ORGID
            , string p_ORGVALUE
            , string p_ORGNAME
            , decimal? p_ORGTYPE
            , decimal? p_PARENTID
            , string p_PHONE
            , string p_EMAIL
            , string p_DESCRIPTION
            , string p_APARTMENTNUMBER
            , string p_STREETNAMES
            , string p_ADDRESS
            , string p_PROVINCEID
            , decimal? p_DISTRICTID
            , decimal? p_WARDID
            , string p_LATITUDE
            , string p_LONGITUDE
            , string p_EXTENSION
            , string p_ZIPCODE
            , string p_IS_ACTIVE
            )
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "VarChar", p_language, 0);
            dt.Rows.Add("IN", "p_ORGID", "Number", p_ORGID, 0);
            dt.Rows.Add("IN", "p_ORGVALUE", "VarChar", p_ORGVALUE, 0);
            dt.Rows.Add("IN", "p_ORGNAME", "VarChar", p_ORGNAME, 0);
            dt.Rows.Add("IN", "p_ORGTYPE", "Number", p_ORGTYPE, 0);
            dt.Rows.Add("IN", "p_PARENTID", "Number", p_PARENTID, 0);
            dt.Rows.Add("IN", "p_PHONE", "VarChar", p_PHONE, 0);
            dt.Rows.Add("IN", "p_EMAIL", "VarChar", p_EMAIL, 0);
            dt.Rows.Add("IN", "p_DESCRIPTION", "VarChar", p_DESCRIPTION, 0);
            dt.Rows.Add("IN", "p_APARTMENTNUMBER", "VarChar", p_APARTMENTNUMBER, 0);
            dt.Rows.Add("IN", "p_STREETNAMES", "VarChar", p_STREETNAMES, 0);
            dt.Rows.Add("IN", "p_ADDRESS", "VarChar", p_ADDRESS, 0);
            dt.Rows.Add("IN", "p_PROVINCEID", "VarChar", p_PROVINCEID, 0);
            dt.Rows.Add("IN", "p_DISTRICTID", "Number", p_DISTRICTID, 0);
            dt.Rows.Add("IN", "p_WARDID", "Number", p_WARDID, 0);
            dt.Rows.Add("IN", "p_LATITUDE", "VarChar", p_LATITUDE, 0);
            dt.Rows.Add("IN", "p_LONGITUDE", "VarChar", p_LONGITUDE, 0);
            dt.Rows.Add("IN", "p_EXTENSION", "VarChar", p_EXTENSION, 0);
            dt.Rows.Add("IN", "p_ZIPCODE", "VarChar", p_ZIPCODE, 0);
            dt.Rows.Add("IN", "p_IS_ACTIVE", "VarChar", p_IS_ACTIVE, 0);
            dt.Rows.Add("OUT", "p_ERR", "Char", "", 3000);
            return new DataReturn().DataReturnText(OracleConnectionString, "ad_Category.ORG_InsUp", dt);
        }
        public string ORG_Active(string OracleConnectionString, string p_TokenKey, string p_language, decimal? p_ORGID, string p_IS_ACTIVE)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "VarChar", p_language, 0);
            dt.Rows.Add("IN", "p_ORGID", "Number", p_ORGID, 0);
            dt.Rows.Add("IN", "p_IS_ACTIVE", "VarChar", p_IS_ACTIVE, 0);
            dt.Rows.Add("OUT", "p_ERR", "Char", "", 3000);
            return new DataReturn().DataReturnText(OracleConnectionString, "ad_Category.ORG_Active", dt);
        }
        public ListOutFilter WAREHOUSE_Find(string OracleConnectionString, string p_TokenKey, string p_language, string p_SEARCH, string p_IS_ACTIVE, decimal? p_ORGID, decimal? p_row_start, decimal p_row_end)
        {
            InputFilter _InputFilter = new InputFilter();
            _InputFilter.OracleConnectionString = OracleConnectionString;
            _InputFilter.CursorName = "p_cur";
            _InputFilter.OutName = "p_OutTotal";
            _InputFilter.StoredProcedureName = "ad_Category.WAREHOUSE_Find";
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "VarChar", p_language, 0);
            dt.Rows.Add("IN", "p_SEARCH", "VarChar", p_SEARCH, 0);
            dt.Rows.Add("IN", "p_ORGID", "Number", p_ORGID, 0);
            dt.Rows.Add("IN", "p_IS_ACTIVE", "VarChar", p_IS_ACTIVE, 0);
            dt.Rows.Add("IN", "p_row_start", "Number", p_row_start, 0);
            dt.Rows.Add("IN", "p_row_end", "Number", p_row_end, 0);
            dt.Rows.Add("OUT", "p_OutTotal", "Number", "", 0);
            return new DataReturn().DataReturnFilter(_InputFilter, dt);
        }
        public string WAREHOUSE_INSUP(string OracleConnectionString
                , string p_TokenKey
                , string p_language
                , decimal? p_WAREHOUSE_ID
                , string p_WAREHOUSE_VALUE
                , string p_WAREHOUSE_NAME
                , string p_WAREHOUSE_TYPE
                , decimal? p_ORGID
                , string p_DESCRIPTION
                , string p_PHONE
                , string p_EMAIL
                , string p_ADDRESS
                , decimal? p_PROVINCEID
                , decimal? p_DISTRICTID
                , decimal? p_WARDSID
                , string p_APARTMENTNUMBER
                , string p_STREETNAMES
                , string p_LATITUDE
                , string p_LONGITUDE
                , string p_EXTENSION
                , string p_IS_ACTIVE

            )
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "VarChar", p_language, 0);
            dt.Rows.Add("IN", "p_WAREHOUSE_ID", "Number", p_WAREHOUSE_ID, 0);
            dt.Rows.Add("IN", "p_WAREHOUSE_VALUE", "VarChar", p_WAREHOUSE_VALUE, 0);
            dt.Rows.Add("IN", "p_WAREHOUSE_NAME", "VarChar", p_WAREHOUSE_NAME, 0);
            dt.Rows.Add("IN", "p_WAREHOUSE_TYPE", "VarChar", p_WAREHOUSE_TYPE, 0);
            dt.Rows.Add("IN", "p_ORGID", "Number", p_ORGID, 0);
            dt.Rows.Add("IN", "p_DESCRIPTION", "VarChar", p_DESCRIPTION, 0);
            dt.Rows.Add("IN", "p_PHONE", "VarChar", p_PHONE, 0);
            dt.Rows.Add("IN", "p_EMAIL", "VarChar", p_EMAIL, 0);
            dt.Rows.Add("IN", "p_ADDRESS", "VarChar", p_ADDRESS, 0);
            dt.Rows.Add("IN", "p_PROVINCEID", "Number", p_PROVINCEID, 0);
            dt.Rows.Add("IN", "p_DISTRICTID", "Number", p_DISTRICTID, 0);
            dt.Rows.Add("IN", "p_WARDSID", "Number", p_WARDSID, 0);
            dt.Rows.Add("IN", "p_APARTMENTNUMBER", "VarChar", p_APARTMENTNUMBER, 0);
            dt.Rows.Add("IN", "p_STREETNAMES", "VarChar", p_STREETNAMES, 0);
            dt.Rows.Add("IN", "p_LATITUDE", "VarChar", p_LATITUDE, 0);
            dt.Rows.Add("IN", "p_LONGITUDE", "VarChar", p_LONGITUDE, 0);
            dt.Rows.Add("IN", "p_EXTENSION", "VarChar", p_EXTENSION, 0);
            dt.Rows.Add("IN", "p_IS_ACTIVE", "VarChar", p_IS_ACTIVE, 0);
            dt.Rows.Add("OUT", "p_ERR", "Char", "", 3000);
            return new DataReturn().DataReturnText(OracleConnectionString, "ad_Category.WAREHOUSE_INSUP", dt);
        }
        public string WAREHOUSE_Active(string OracleConnectionString, string p_TokenKey, string p_language, decimal? p_WAREHOUSE_ID, string p_IS_ACTIVE)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "VarChar", p_language, 0);
            dt.Rows.Add("IN", "p_WAREHOUSE_ID", "Number", p_WAREHOUSE_ID, 0);
            dt.Rows.Add("IN", "p_IS_ACTIVE", "VarChar", p_IS_ACTIVE, 0);
            dt.Rows.Add("OUT", "p_ERR", "Char", "", 3000);
            return new DataReturn().DataReturnText(OracleConnectionString, "ad_Category.WAREHOUSE_Active", dt);
        }
        public ListOutFilter CATEGORY_Find(string OracleConnectionString, string p_TokenKey, string p_language, string p_SEARCH, string p_IS_ACTIVE, decimal? p_ORGID, decimal? p_row_start, decimal p_row_end)
        {
            InputFilter _InputFilter = new InputFilter();
            _InputFilter.OracleConnectionString = OracleConnectionString;
            _InputFilter.CursorName = "p_cur";
            _InputFilter.OutName = "p_OutTotal";
            _InputFilter.StoredProcedureName = "ad_Category.CATEGORY_Find";
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "VarChar", p_language, 0);
            dt.Rows.Add("IN", "p_SEARCH", "VarChar", p_SEARCH, 0);
            dt.Rows.Add("IN", "p_ORGID", "Number", p_ORGID, 0);
            dt.Rows.Add("IN", "p_IS_ACTIVE", "VarChar", p_IS_ACTIVE, 0);
            dt.Rows.Add("IN", "p_row_start", "Number", p_row_start, 0);
            dt.Rows.Add("IN", "p_row_end", "Number", p_row_end, 0);
            dt.Rows.Add("OUT", "p_OutTotal", "Number", "", 0);
            return new DataReturn().DataReturnFilter(_InputFilter, dt);
        }
        public string CATEGORY_INSUP(string OracleConnectionString
                , string p_TokenKey
                , string p_language
                , decimal? p_CATEGORYID
                , string p_CATEGORYCODE
                , string p_CATEGORYNAME
                , decimal? p_ORG_ID
                , decimal? p_WAREHOUSE_ID
                , string p_DESCRIPTION
                , string p_PICTURE
                , string p_EXTENSION
                , string p_IS_ACTIVE
            )
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "VarChar", p_language, 0);
            dt.Rows.Add("IN", "p_CATEGORYID", "Number", p_CATEGORYID, 0);
            dt.Rows.Add("IN", "p_CATEGORYCODE", "VarChar", p_CATEGORYCODE, 0);
            dt.Rows.Add("IN", "p_CATEGORYNAME", "VarChar", p_CATEGORYNAME, 0);
            dt.Rows.Add("IN", "p_ORG_ID", "Number", p_ORG_ID, 0);
            dt.Rows.Add("IN", "p_WAREHOUSE_ID", "Number", p_WAREHOUSE_ID, 0);
            dt.Rows.Add("IN", "p_DESCRIPTION", "VarChar", p_DESCRIPTION, 0);
            dt.Rows.Add("IN", "p_PICTURE", "VarChar", p_PICTURE, 0);
            dt.Rows.Add("IN", "p_EXTENSION", "VarChar", p_EXTENSION, 0);
            dt.Rows.Add("IN", "p_IS_ACTIVE", "VarChar", p_IS_ACTIVE, 0);
            dt.Rows.Add("OUT", "p_ERR", "Char", "", 3000);
            return new DataReturn().DataReturnText(OracleConnectionString, "ad_Category.CATEGORY_INSUP", dt);
        }
        public string CATEGORY_Active(string OracleConnectionString, string p_TokenKey, string p_language, decimal? p_CATEGORYID, string p_ISACTIVE)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "VarChar", p_language, 0);
            dt.Rows.Add("IN", "p_CATEGORYID", "Number", p_CATEGORYID, 0);
            dt.Rows.Add("IN", "p_ISACTIVE", "VarChar", p_ISACTIVE, 0);
            dt.Rows.Add("OUT", "p_ERR", "Char", "", 3000);
            return new DataReturn().DataReturnText(OracleConnectionString, "ad_Category.CATEGORY_Active", dt);
        }
        public ListOutTable get_AD_LOOKUP(string OracleConnectionString, string p_TokenKey, string p_LANGUAGE)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "Varchar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_LANGUAGE", "Varchar", p_LANGUAGE, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "cur", "ad_Category.get_AD_LOOKUP", dt);
        }
        public ListOutFilter LOOKUP_Find(string OracleConnectionString, string p_TokenKey, string p_language, string p_SEARCH, string p_IS_ACTIVE, string p_LOOKUP_CODE, decimal? p_row_start, decimal p_row_end)
        {
            InputFilter _InputFilter = new InputFilter();
            _InputFilter.OracleConnectionString = OracleConnectionString;
            _InputFilter.CursorName = "p_cur";
            _InputFilter.OutName = "p_OutTotal";
            _InputFilter.StoredProcedureName = "ad_Category.LOOKUP_Find";
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "VarChar", p_language, 0);
            dt.Rows.Add("IN", "p_LOOKUP_CODE", "VarChar", p_LOOKUP_CODE, 0);
            dt.Rows.Add("IN", "p_SEARCH", "VarChar", p_SEARCH, 0);
            dt.Rows.Add("IN", "p_IS_ACTIVE", "VarChar", p_IS_ACTIVE, 0);
            dt.Rows.Add("IN", "p_row_start", "Number", p_row_start, 0);
            dt.Rows.Add("IN", "p_row_end", "Number", p_row_end, 0);
            dt.Rows.Add("OUT", "p_OutTotal", "Number", "", 0);
            return new DataReturn().DataReturnFilter(_InputFilter, dt);
        }
        public string LOOKUP_InsUp(string OracleConnectionString
                     , string p_TokenKey
                     , string p_language
                     , decimal? p_LOOKUP_ID
                     , string p_LOOKUP_CODE
                     , string p_CODE
                     , string p_NAME
                     , string p_DESCRIPTION
                     , string p_IS_ACTIVE
                 )
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "VarChar", p_language, 0);
            dt.Rows.Add("IN", "p_LOOKUP_ID", "Number", p_LOOKUP_ID, 0);
            dt.Rows.Add("IN", "p_LOOKUP_CODE", "VarChar", p_LOOKUP_CODE, 0);
            dt.Rows.Add("IN", "p_CODE", "VarChar", p_CODE, 0);
            dt.Rows.Add("IN", "p_NAME", "VarChar", p_NAME, 0);
            dt.Rows.Add("IN", "p_DESCRIPTION", "VarChar", p_DESCRIPTION, 0);
            dt.Rows.Add("IN", "p_IS_ACTIVE", "VarChar", p_IS_ACTIVE, 0);
            dt.Rows.Add("OUT", "p_ERR", "Char", "", 3000);
            return new DataReturn().DataReturnText(OracleConnectionString, "ad_Category.LOOKUP_InsUp", dt);
        }
        public string LOOKUP_active(string OracleConnectionString, string p_TokenKey, string p_language, decimal? p_CATEGORYID, string p_ISACTIVE)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "VarChar", p_language, 0);
            dt.Rows.Add("IN", "p_LOOKUP_ID", "Number", p_CATEGORYID, 0);
            dt.Rows.Add("IN", "p_IS_ACTIVE", "VarChar", p_ISACTIVE, 0);
            dt.Rows.Add("OUT", "p_ERR", "Char", "", 3000);
            return new DataReturn().DataReturnText(OracleConnectionString, "ad_Category.LOOKUP_active", dt);
        }
        public string LOOKUP_TRL_InsUp(string OracleConnectionString
              , string p_TokenKey
              , string p_language
              , string p_c_language
              , decimal? p_LOOKUP_ID
              , string p_NAME
              , string p_DESCRIPTION
          )
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "VarChar", p_language, 0);
            dt.Rows.Add("IN", "p_c_language", "VarChar", p_c_language, 0);
            dt.Rows.Add("IN", "p_LOOKUP_ID", "Number", p_LOOKUP_ID, 0);
            dt.Rows.Add("IN", "p_NAME", "VarChar", p_NAME, 0);
            dt.Rows.Add("IN", "p_DESCRIPTION", "VarChar", p_DESCRIPTION, 0);
            dt.Rows.Add("OUT", "p_ERR", "Char", "", 3000);
            return new DataReturn().DataReturnText(OracleConnectionString, "ad_Category.LOOKUP_TRL_InsUp", dt);
        }

        ///

        public ListOutFilter get_search_tab(string OracleConnectionString, string p_TokenKey, string p_LANGUAGE, string p_TAB_NAME, string p_IS_ACTIVE, decimal p_IS_VISIBLE, decimal p_IS_SYSTEM, decimal p_RowStart, decimal p_RowEnd)
        {
            InputFilter _InputFilter = new InputFilter();
            _InputFilter.OracleConnectionString = OracleConnectionString;
            _InputFilter.CursorName = "Cur";
            _InputFilter.OutName = "OutTotal";
            _InputFilter.StoredProcedureName = "ad_Category.TAB_Find";
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "VarChar", p_LANGUAGE, 0);
            dt.Rows.Add("IN", "p_TAB_NAME", "VarChar", p_TAB_NAME, 0);
            dt.Rows.Add("IN", "p_IS_ACTIVE", "VarChar", p_IS_ACTIVE, 0);
            dt.Rows.Add("IN", "p_IS_VISIBLE", "Number", p_IS_VISIBLE, 0);
            dt.Rows.Add("IN", "p_IS_SYSTEM", "Number", p_IS_SYSTEM, 0);
            dt.Rows.Add("IN", "RowStart", "Number", p_RowStart, 0);
            dt.Rows.Add("IN", "RowEnd", "Number", p_RowEnd, 0);
            dt.Rows.Add("OUT", "OutTotal", "Number", "", 0);
            return new DataReturn().DataReturnFilter(_InputFilter, dt);
        }
        public string activate_tab(string OracleConnectionString, string p_TokenKey, string p_Language, decimal p_TAB_ID, string p_IS_ACTIVE)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_Language", "VarChar", p_Language, 0);
            dt.Rows.Add("IN", "p_TAB_ID", "Number", p_TAB_ID, 0);
            dt.Rows.Add("IN", "p_IS_ACTIVE", "VarChar", p_IS_ACTIVE, 0);
            dt.Rows.Add("OUT", "p_ERR", "Char", "", 3000);

            return new DataReturn().DataReturnText(OracleConnectionString, "ad_Category.TAB_active", dt);
        }
        public ListOutTable get_tab_trl(string OracleConnectionString, string p_TokenKey, string p_Language, decimal p_TAB_ID)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_Language", "VarChar", p_Language, 0);
            dt.Rows.Add("IN", "p_TAB_ID", "Number", p_TAB_ID, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "Cur", "ad_Category.TAB_TRL_get", dt);
        }
        public ListOutTable create_update_tab(string OracleConnectionString, string p_TokenKey, string p_Language, decimal p_TAB_ID, string p_TAB_NAME, string p_DESCRIPTION, string p_IS_ACTIVE, decimal p_IS_VISIBLE, decimal p_IS_SYSTEM)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_Language", "VarChar", p_Language, 0);
            dt.Rows.Add("IN", "p_TAB_ID", "Number", p_TAB_ID, 0);
            dt.Rows.Add("IN", "p_TAB_NAME", "VarChar", p_TAB_NAME, 0);
            dt.Rows.Add("IN", "p_DESCRIPTION", "VarChar", p_DESCRIPTION, 0);
            dt.Rows.Add("IN", "p_IS_ACTIVE", "VarChar", p_IS_ACTIVE, 0);
            dt.Rows.Add("IN", "p_IS_VISIBLE", "Number", p_IS_VISIBLE, 0);
            dt.Rows.Add("IN", "p_IS_SYSTEM", "Number", p_IS_SYSTEM, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "Cur", "ad_Category.TAB_InsUp", dt);
        }
        public string update_tab_trl(string OracleConnectionString, string p_TokenKey, string p_Language, string p_C_language, decimal p_TAB_ID, string p_TAB_NAME, string p_DESCRIPTION)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_Language", "VarChar", p_Language, 0);
            dt.Rows.Add("IN", "p_C_language", "VarChar", p_C_language, 0);
            dt.Rows.Add("IN", "p_TAB_ID", "Number", p_TAB_ID, 0);
            dt.Rows.Add("IN", "p_TAB_NAME", "VarChar", p_TAB_NAME, 0);
            dt.Rows.Add("IN", "p_DESCRIPTION", "VarChar", p_DESCRIPTION, 0);
            dt.Rows.Add("OUT", "p_ERR", "Char", "", 3000);
            return new DataReturn().DataReturnText(OracleConnectionString, "ad_Category.TAB_TRL_InsUp", dt);
        } 
        public ListOutTable get_PRODUCTS(string OracleConnectionString, string p_TokenKey, string p_language, string p_PRODUCTTYPE, decimal? p_ORG_ID, decimal? p_WAREHOUSE_ID)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "Varchar", p_language, 0);
            dt.Rows.Add("IN", "p_PRODUCTTYPE", "Varchar", p_PRODUCTTYPE, 0);
            dt.Rows.Add("IN", "p_ORG_ID", "Number", p_ORG_ID, 0);
            dt.Rows.Add("IN", "p_WAREHOUSE_ID", "Number", p_WAREHOUSE_ID, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "Cur", "PKG_ORDER.get_PRODUCTS", dt);
        }
        public ListOutTable get_CUSTOMER(string OracleConnectionString, string p_TokenKey, string p_language, string p_CUSTOMER_PHONE, decimal? p_ORG_ID, decimal? p_WAREHOUSE_ID)
        {
            DataTable dt = new DataReturn().CreateTableParameter(1);
            dt.Rows.Add("IN", "p_TokenKey", "VarChar", p_TokenKey, 0);
            dt.Rows.Add("IN", "p_language", "Varchar", p_language, 0);
            dt.Rows.Add("IN", "p_CUSTOMER_PHONE", "Varchar", p_CUSTOMER_PHONE, 0);
            dt.Rows.Add("IN", "p_ORG_ID", "Number", p_ORG_ID, 0);
            dt.Rows.Add("IN", "p_WAREHOUSE_ID", "Number", p_WAREHOUSE_ID, 0);
            return new DataReturn().DataReturnOutTable(OracleConnectionString, "Cur", "PKG_ORDER.get_CUSTOMER", dt);
        }
    }
}
