using Constracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Globalization; 

namespace Models.System
{
    public class DataReturn : DataContexBase
    {
        public DataTable DataReturnTable(string connString, string CursorName, string CommandText, DataTable p_Parameter)
        {
            List<OracleParameter> list = new List<OracleParameter>();
            for (int i = p_Parameter.Rows.Count - 1; i >= 0; i--)
            {
                if (true)
                {
                    list.Add(AddInputParameter(p_Parameter.Rows[i]["Parameter"].ToString(), InTextOutOracleType(p_Parameter.Rows[i]["OracleType"].ToString()), p_Parameter.Rows[i]["Value"].ToString()));
                }
            }
            return ExecuteDatatable(connString, CursorName, CommandText, list.ToArray());
        }
        public string DataReturnText(string connString, string CommandText, DataTable Parameter)
        {
            string error = "OK";
            try
            {
                List<OracleParameter> list = new List<OracleParameter>();
                for (int i = Parameter.Rows.Count - 1; i >= 0; i--)
                {
                    if (true)
                    {
                        if (Parameter.Rows[i]["Type"].ToString() == "OUT")
                        {
                            list.Add(AddOutputParameter(Parameter.Rows[i]["Parameter"].ToString(), InTextOutOracleType(Parameter.Rows[i]["OracleType"].ToString()), Convert.ToInt32(Parameter.Rows[i]["Size"])));
                            error = Parameter.Rows[i]["Parameter"].ToString();
                        }
                        else
                        {
                            if (Parameter.Rows[i]["OracleType"].ToString() == "DateTime" && Convert.ToInt32(Parameter.Rows[i]["Size"]) == 2 && !string.IsNullOrEmpty(Parameter.Rows[i]["Value"].ToString()))
                            {
                                list.Add(AddInputParameter(
                                Parameter.Rows[i]["Parameter"].ToString(),
                                InTextOutOracleType(Parameter.Rows[i]["OracleType"].ToString()),
                                DateTime.ParseExact(Parameter.Rows[i]["Value"].ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture)));
                            }
                            else if (Parameter.Rows[i]["OracleType"].ToString() == "DateTime" && Convert.ToInt32(Parameter.Rows[i]["Size"]) != 2 && !string.IsNullOrEmpty(Parameter.Rows[i]["Value"].ToString()))
                            {
                                list.Add(AddInputParameter(
                                Parameter.Rows[i]["Parameter"].ToString(),
                                InTextOutOracleType(Parameter.Rows[i]["OracleType"].ToString()),
                                DateTime.ParseExact(Parameter.Rows[i]["Value"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture)));
                            }
                            else
                            {
                                list.Add(AddInputParameter(Parameter.Rows[i]["Parameter"].ToString(), InTextOutOracleType(Parameter.Rows[i]["OracleType"].ToString()), Parameter.Rows[i]["Value"].ToString()));
                            }
                        }
                    }
                }
                return ExecuteReaderOuputText(connString, error, CommandText, list.ToArray());
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return error;
            }

        }
        public ListOutTable DataReturnOutTable(string connString, string CursorName, string CommandText, DataTable p_Parameter)
        {
            List<OracleParameter> list = new List<OracleParameter>();
            for (int i = p_Parameter.Rows.Count - 1; i >= 0; i--)
            {
                if (true)
                {
                    if (p_Parameter.Rows[i]["OracleType"].ToString() == "DateTime" && Convert.ToInt32(p_Parameter.Rows[i]["Size"]) == 2 && !string.IsNullOrEmpty(p_Parameter.Rows[i]["Value"].ToString()))
                    {
                        list.Add(AddInputParameter(
                        p_Parameter.Rows[i]["Parameter"].ToString(),
                        InTextOutOracleType(p_Parameter.Rows[i]["OracleType"].ToString()),
                        DateTime.ParseExact(p_Parameter.Rows[i]["Value"].ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture)));
                    }
                    else if (p_Parameter.Rows[i]["OracleType"].ToString() == "DateTime" && Convert.ToInt32(p_Parameter.Rows[i]["Size"]) != 2 && !string.IsNullOrEmpty(p_Parameter.Rows[i]["Value"].ToString()))
                    {
                        list.Add(AddInputParameter(
                        p_Parameter.Rows[i]["Parameter"].ToString(),
                        InTextOutOracleType(p_Parameter.Rows[i]["OracleType"].ToString()),
                        DateTime.ParseExact(p_Parameter.Rows[i]["Value"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture)));
                    }
                    else
                    {
                        list.Add(AddInputParameter(
                        p_Parameter.Rows[i]["Parameter"].ToString(),
                        InTextOutOracleType(p_Parameter.Rows[i]["OracleType"].ToString()),
                        p_Parameter.Rows[i]["Value"].ToString()));
                    }
                }
            }
            return ExecuteDataList(connString, CursorName, CommandText, list.ToArray());
        }
        public ListOutTableText DataReturnOutTableText(string connString, string CursorName, string CommandText, DataTable Parameter)
        {
            List<OracleParameter> list = new List<OracleParameter>();
            string error = "";
            for (int i = Parameter.Rows.Count - 1; i >= 0; i--)
            {
                if (true)
                {
                    if (Parameter.Rows[i]["Type"].ToString() == "OUT")
                    {
                        list.Add(AddOutputParameter(Parameter.Rows[i]["Parameter"].ToString(), InTextOutOracleType(Parameter.Rows[i]["OracleType"].ToString()), Convert.ToInt32(Parameter.Rows[i]["Size"])));
                        error = Parameter.Rows[i]["Parameter"].ToString();
                    }
                    else
                    {
                        if (Parameter.Rows[i]["OracleType"].ToString() == "DateTime" && Convert.ToInt32(Parameter.Rows[i]["Size"]) == 2 && !string.IsNullOrEmpty(Parameter.Rows[i]["Value"].ToString()))
                        {
                            list.Add(AddInputParameter(
                            Parameter.Rows[i]["Parameter"].ToString(),
                            InTextOutOracleType(Parameter.Rows[i]["OracleType"].ToString()),
                            DateTime.ParseExact(Parameter.Rows[i]["Value"].ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture)));
                        }
                        else if (Parameter.Rows[i]["OracleType"].ToString() == "DateTime" && Convert.ToInt32(Parameter.Rows[i]["Size"]) != 2 && !string.IsNullOrEmpty(Parameter.Rows[i]["Value"].ToString()))
                        {
                            list.Add(AddInputParameter(
                            Parameter.Rows[i]["Parameter"].ToString(),
                            InTextOutOracleType(Parameter.Rows[i]["OracleType"].ToString()),
                            DateTime.ParseExact(Parameter.Rows[i]["Value"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture)));
                        }
                        else
                        {
                            list.Add(AddInputParameter(Parameter.Rows[i]["Parameter"].ToString(), InTextOutOracleType(Parameter.Rows[i]["OracleType"].ToString()), Parameter.Rows[i]["Value"].ToString()));
                        }
                    }
                }
            }
            return ExecuteDataText(connString, CursorName, error, CommandText, list.ToArray());
        }
        public ListOutDataSet DataReturnDataSet(string connString, string CommandText, DataTable p_Parameter)
        {
            List<OracleParameter> list = new List<OracleParameter>();
            for (int i = p_Parameter.Rows.Count - 1; i >= 0; i--)
            {
                if (true)
                {
                    if (p_Parameter.Rows[i]["OracleType"].ToString() == "DateTime" && !string.IsNullOrEmpty(p_Parameter.Rows[i]["Value"].ToString()))
                    {
                        list.Add(AddInputParameter(
                        p_Parameter.Rows[i]["Parameter"].ToString(),
                        InTextOutOracleType(p_Parameter.Rows[i]["OracleType"].ToString()),
                        DateTime.ParseExact(p_Parameter.Rows[i]["Value"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture)));
                    }
                    else if (p_Parameter.Rows[i]["OracleType"].ToString() == "Cursor")
                    {
                        list.Add(
                           AddOutputParameter(p_Parameter.Rows[i]["Parameter"].ToString())
                           );
                    }
                    else
                    {
                        list.Add(AddInputParameter(
                        p_Parameter.Rows[i]["Parameter"].ToString(),
                        InTextOutOracleType(p_Parameter.Rows[i]["OracleType"].ToString()),
                        p_Parameter.Rows[i]["Value"].ToString()));
                    }
                }
            }
            return ExecuteDataSet(connString, CommandText, list.ToArray());
        }
        public ListOutFilter DataReturnFilter(InputFilter _InputFilter, DataTable Parameter)
        {
            List<OracleParameter> list = new List<OracleParameter>();
            for (int i = Parameter.Rows.Count - 1; i >= 0; i--)
            {
                if (true)
                {
                    if (Parameter.Rows[i]["Type"].ToString() == "OUT")
                    {
                        list.Add(AddOutputNumberParameter(Parameter.Rows[i]["Parameter"].ToString()));
                    }
                    else
                    {
                        if (Parameter.Rows[i]["OracleType"].ToString() == "DateTime" && !string.IsNullOrEmpty(Parameter.Rows[i]["Value"].ToString()))
                        {
                            list.Add(AddInputParameter(
                            Parameter.Rows[i]["Parameter"].ToString(),
                            InTextOutOracleType(Parameter.Rows[i]["OracleType"].ToString()),
                            DateTime.ParseExact(Parameter.Rows[i]["Value"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture)));
                        }
                        else
                        {
                            list.Add(AddInputParameter(Parameter.Rows[i]["Parameter"].ToString(), InTextOutOracleType(Parameter.Rows[i]["OracleType"].ToString()), Parameter.Rows[i]["Value"].ToString()));
                        }
                    }
                }
            }
            return ExecuteDataListFilter(_InputFilter, list.ToArray());
        }
        public DataTable CreateTableParameter(int type)
        {
            DataTable DT = new DataTable();
            switch (type)
            {
                case 1:
                    DT = new DataTable
                    {
                        Columns =
                        {
                            { "Type",typeof(string)},
                            { "Parameter",typeof(string)},
                            { "OracleType",typeof(string)},
                            { "Value",typeof(string)},
                            { "Size",typeof(string)}
                        }
                    };
                    break;
                case 2:
                    DT = new DataTable
                    {
                        Columns ={
                             {"Parameter",typeof(string)},
                             {"OracleType",typeof(string)},
                             {"Value",typeof(string)}
                         }
                    };
                    break;
                default:
                    DT = new DataTable
                    {
                        Columns ={
                             {"Parameter",typeof(string)},
                             {"OracleType",typeof(string)},
                             {"Value",typeof(string)}
                         }
                    };
                    break;
            }
            return DT;
        }

    }

}
