using Constracts;
using Librarys.Ui;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient; 
using System.Reflection; 

namespace Models
{
    public class DataContexBase
    {
        public virtual OracleParameter AddInputParameter(string paramName, OracleType paramType, object paramValue)
        {
            return new OracleParameter(paramName, paramType)
            {
                Value = string.IsNullOrEmpty(paramValue.ToString()) ? DBNull.Value : paramValue,
                Direction = ParameterDirection.Input
            };
        }
        public virtual OracleParameter AddInputParameter(string paramName, OracleType paramType, int size, string columnName)
        {
            return new OracleParameter(paramName, paramType, size, columnName);
        }
        public virtual OracleParameter AddOutputParameter(string cursorName)
        {
            return new OracleParameter(cursorName, OracleType.Cursor)
            {
                Direction = ParameterDirection.Output
            };
        }
        public virtual OracleParameter AddOutputParameter(string paramName, OracleType paramType, int paramSize)
        {
            return new OracleParameter(paramName, paramType, paramSize)
            {
                Size = paramSize,
                Direction = ParameterDirection.Output
            };
        }
        public virtual OracleParameter AddOutputNumberParameter(string name)
        {
            return new OracleParameter(name, OracleType.Number)
            {
                Direction = ParameterDirection.Output
            };
        }
        public virtual OracleParameter AddOutputTextParameter(string name)
        {
            return new OracleParameter(name, OracleType.Char)
            {
                Direction = ParameterDirection.Output
            };
        }
        public virtual ListOutFilter ExecuteDataListFilter(InputFilter _InputFilter, params OracleParameter[] commandParameters)
        {
            ListOutFilter _ListOutFilter = new ListOutFilter();
            DataTable dataTable = new DataTable();
            try
            {
                using (OracleConnection oracleConnection = new OracleConnection(_InputFilter.OracleConnectionString))
                {
                    oracleConnection.Open();
                    try
                    {
                        OracleCommand oracleCommand = new OracleCommand(_InputFilter.StoredProcedureName, oracleConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        oracleCommand.Parameters.Clear();
                        oracleCommand.Parameters.AddRange(commandParameters);
                        oracleCommand.Parameters.Add(AddOutputParameter(_InputFilter.CursorName));
                        OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(oracleCommand);
                        oracleDataAdapter.Fill(dataTable);
                        _ListOutFilter.OutTotal = Convert.ToInt32(oracleCommand.Parameters[_InputFilter.OutName].Value.ToString());
                        _ListOutFilter.OutDataTable = dataTable; 
                        oracleCommand.Parameters.Clear();
                        oracleConnection.Close();
                        oracleConnection.Dispose();
                    }
                    catch (Exception ex)
                    {
                        oracleConnection.Close();
                        oracleConnection.Dispose();
                        _ListOutFilter.OutError = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                _ListOutFilter.OutError = ex.Message;
            }
            return _ListOutFilter;
        }
        public virtual ListOutTable ExecuteDataList(string OracleConnectionString, string CursorName, string storedProcedureName, params OracleParameter[] commandParameters)
        {
            ListOutTable _ListOutTable = new ListOutTable();
            DataTable dataTable = new DataTable();
            try
            {
                using (OracleConnection oracleConnection = new OracleConnection(OracleConnectionString))
                {
                    oracleConnection.Open();
                    try
                    {
                        OracleCommand oracleCommand = new OracleCommand(storedProcedureName, oracleConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        oracleCommand.Parameters.Clear();
                        oracleCommand.Parameters.AddRange(commandParameters);
                        oracleCommand.Parameters.Add(AddOutputParameter(CursorName));
                        OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(oracleCommand);
                        oracleDataAdapter.Fill(dataTable);
                        oracleCommand.Parameters.Clear();
                        oracleConnection.Close();
                        oracleConnection.Dispose();
                        _ListOutTable.OutDataTable = dataTable;
                        _ListOutTable.OutError = "OK";
                    }
                    catch (Exception ex)
                    {
                        oracleConnection.Close();
                        oracleConnection.Dispose();
                        _ListOutTable.OutError = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                _ListOutTable.OutError = ex.Message;
            }
            return _ListOutTable;
        }
        public virtual ListOutTableText ExecuteDataText(string OracleConnectionString, string CursorName, string OutText, string storedProcedureName, params OracleParameter[] commandParameters)
        {
            ListOutTableText _ListOutTable = new ListOutTableText();
            DataTable dataTable = new DataTable();
            try
            {
                using (OracleConnection oracleConnection = new OracleConnection(OracleConnectionString))
                {
                    oracleConnection.Open();
                    try
                    {
                        OracleCommand oracleCommand = new OracleCommand(storedProcedureName, oracleConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        oracleCommand.Parameters.Clear();
                        oracleCommand.Parameters.AddRange(commandParameters);
                        oracleCommand.Parameters.Add(AddOutputParameter(CursorName));
                        OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(oracleCommand);
                        oracleDataAdapter.Fill(dataTable);
                        _ListOutTable.OutText = oracleCommand.Parameters[OutText].Value.ToString().Trim();
                        oracleCommand.Parameters.Clear();
                        oracleConnection.Close();
                        oracleConnection.Dispose();
                        _ListOutTable.OutDataTable = dataTable;
                        _ListOutTable.OutError = "OK";
                    }
                    catch (Exception ex)
                    {
                        oracleConnection.Close();
                        oracleConnection.Dispose();
                        _ListOutTable.OutError = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                _ListOutTable.OutError = ex.Message;
            }
            return _ListOutTable;
        }
        public virtual ListOutDataSet ExecuteDataSet(string OracleConnectionString, string storedProcedureName, params OracleParameter[] commandParameters)
        {
            ListOutDataSet _ListOutDataSet = new ListOutDataSet();
            DataSet _DataSet = new DataSet();
            try
            {
                using (OracleConnection oracleConnection = new OracleConnection(OracleConnectionString))
                {
                    oracleConnection.Open();
                    try
                    {
                        OracleCommand oracleCommand = new OracleCommand(storedProcedureName, oracleConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        oracleCommand.Parameters.Clear();
                        oracleCommand.Parameters.AddRange(commandParameters);
                        OracleDataAdapter da = new OracleDataAdapter();
                        da.SelectCommand = oracleCommand;
                        da.Fill(_DataSet);
                        oracleCommand.Parameters.Clear();
                        oracleConnection.Close();
                        oracleConnection.Dispose();
                        _ListOutDataSet.OutDataDataSet = _DataSet;
                    }
                    catch (Exception ex)
                    {
                        oracleConnection.Close();
                        oracleConnection.Dispose();
                        _ListOutDataSet.OutError = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                _ListOutDataSet.OutError = ex.Message;
            }
            return _ListOutDataSet;
        }
        public virtual List<T> ExecuteReader<T>(string OracleConnectionString, string CursorName, string commandText)
        {
            List<T> list = new List<T>();
            using (OracleConnection oracleConnection = new OracleConnection(OracleConnectionString))
            {
                oracleConnection.Open();
                try
                {
                    OracleCommand oracleCommand = new OracleCommand
                    {
                        Connection = oracleConnection,
                        CommandType = CommandType.Text,
                        CommandText = commandText
                    };
                    oracleCommand.Parameters.Add(AddOutputParameter(CursorName));
                    OracleDataReader oracleDataReader = oracleCommand.ExecuteReader();
                    while (oracleDataReader.Read())
                    {
                        T t = Activator.CreateInstance<T>();
                        PropertyInfo[] properties = t.GetType().GetProperties();
                        for (int i = 0; i < properties.Length; i++)
                        {
                            PropertyInfo propertyInfo = properties[i];
                            try
                            {
                                string attributeDisplayName = ReflectionExtensions.GetAttributeDisplayName(propertyInfo);
                                if (!object.Equals(oracleDataReader[attributeDisplayName], DBNull.Value))
                                {
                                    propertyInfo.SetValue(t, oracleDataReader[attributeDisplayName], null);
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                        list.Add(t);
                    } 
                    oracleDataReader.Close();
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                }
                catch (Exception ex)
                {
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                    throw ex;
                }
            }
            return list;
        }
        public virtual List<T> ExecuteStoredProcedure<T>(string OracleConnectionString, string CursorName, string storedProcedureName)
        {
            List<T> result;
            using (OracleConnection oracleConnection = new OracleConnection(OracleConnectionString))
            {
                oracleConnection.Open();
                OracleCommand oracleCommand = new OracleCommand(storedProcedureName, oracleConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                oracleCommand.Parameters.Add(AddOutputParameter("cur"));
                OracleDataReader oracleDataReader = oracleCommand.ExecuteReader();
                List<T> list = new List<T>();
                while (oracleDataReader.Read())
                {
                    T t = Activator.CreateInstance<T>();
                    PropertyInfo[] properties = t.GetType().GetProperties();
                    for (int i = 0; i < properties.Length; i++)
                    {
                        PropertyInfo propertyInfo = properties[i];
                        try
                        {
                            string attributeDisplayName = ReflectionExtensions.GetAttributeDisplayName(propertyInfo);
                            if (!object.Equals(oracleDataReader[attributeDisplayName], DBNull.Value))
                            {
                                propertyInfo.SetValue(t, oracleDataReader[attributeDisplayName], null);
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                    list.Add(t);
                }
                oracleDataReader.Close();
                oracleConnection.Close();
                oracleConnection.Dispose();
                result = list;
            }
            return result;
        }
        public virtual List<T> ExecuteReader<T>(string OracleConnectionString, string CursorName, string storedProcedureName, params OracleParameter[] commandParameters)
        {
            List<T> list = new List<T>();
            using (OracleConnection oracleConnection = new OracleConnection(OracleConnectionString))
            {
                oracleConnection.Open();
                try
                {
                    OracleCommand oracleCommand = new OracleCommand
                    {
                        Connection = oracleConnection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = storedProcedureName
                    };
                    oracleCommand.Parameters.AddRange(commandParameters);
                    oracleCommand.Parameters.Add(AddOutputParameter(CursorName));
                    OracleDataReader oracleDataReader = oracleCommand.ExecuteReader();
                    while (oracleDataReader.Read())
                    {
                        T t = Activator.CreateInstance<T>();
                        PropertyInfo[] properties = t.GetType().GetProperties();
                        for (int i = 0; i < properties.Length; i++)
                        {
                            PropertyInfo propertyInfo = properties[i];
                            try
                            {
                                string attributeDisplayName = ReflectionExtensions.GetAttributeDisplayName(propertyInfo);
                                if (!object.Equals(oracleDataReader[attributeDisplayName], DBNull.Value))
                                {
                                    propertyInfo.SetValue(t, oracleDataReader[attributeDisplayName], null);
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                        list.Add(t);
                    }
                    oracleDataReader.Close();
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                }
                catch (Exception ex)
                {
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                    throw ex;
                }
            }
            return list;
        }
        public virtual List<T> ExecuteReaderPager<T>(string OracleConnectionString, string CursorName, string storedProcedureName, out int outTotal, params OracleParameter[] commandParameters)
        {
            List<T> list = new List<T>();
            using (OracleConnection oracleConnection = new OracleConnection(OracleConnectionString))
            {
                oracleConnection.Open();
                try
                {
                    OracleCommand oracleCommand = new OracleCommand
                    {
                        Connection = oracleConnection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = storedProcedureName
                    };
                    oracleCommand.Parameters.AddRange(commandParameters);
                    oracleCommand.Parameters.Add(AddOutputParameter(CursorName));
                    OracleDataReader oracleDataReader = oracleCommand.ExecuteReader();
                    while (oracleDataReader.Read())
                    {
                        T t = Activator.CreateInstance<T>();
                        PropertyInfo[] properties = t.GetType().GetProperties();
                        for (int i = 0; i < properties.Length; i++)
                        {
                            PropertyInfo propertyInfo = properties[i];
                            try
                            {
                                string attributeDisplayName = ReflectionExtensions.GetAttributeDisplayName(propertyInfo);
                                if (!object.Equals(oracleDataReader[attributeDisplayName], DBNull.Value))
                                {
                                    propertyInfo.SetValue(t, oracleDataReader[attributeDisplayName], null);
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                        list.Add(t);
                    }
                    outTotal = Convert.ToInt32(oracleCommand.Parameters["total"].Value);
                    oracleDataReader.Close();
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                }
                catch (Exception ex)
                {
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                    throw ex;
                }
            }
            return list;
        }
        public virtual DataTable ExecuteReaderPager(string OracleConnectionString, string CursorName, string storedProcedureName, out int outTotal, params OracleParameter[] commandParameters)
        {
            DataTable dataTable = new DataTable();
            using (OracleConnection oracleConnection = new OracleConnection(OracleConnectionString))
            {
                oracleConnection.Open();
                try
                {
                    OracleCommand oracleCommand = new OracleCommand
                    {
                        Connection = oracleConnection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = storedProcedureName
                    };
                    oracleCommand.Parameters.AddRange(commandParameters);
                    oracleCommand.Parameters.Add(AddOutputParameter(CursorName));
                    OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(oracleCommand);
                    oracleDataAdapter.Fill(dataTable);
                    outTotal = Convert.ToInt32(oracleCommand.Parameters["total"].Value);
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                }
                catch (Exception ex)
                {
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                    throw ex;
                }
            }
            return dataTable;
        }
        public virtual T ExecuteStoredProcedureOutput<T>(string OracleConnectionString, string CursorName, string storedProcedureName, params OracleParameter[] commandParameters)
        {
            if (string.IsNullOrEmpty(OracleConnectionString))
            {
                throw new ArgumentNullException("connectionString");
            }
            T t = default(T);
            using (OracleConnection oracleConnection = new OracleConnection(OracleConnectionString))
            {
                oracleConnection.Open();
                try
                {
                    OracleCommand oracleCommand = new OracleCommand
                    {
                        Connection = oracleConnection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = storedProcedureName
                    };
                    oracleCommand.Parameters.AddRange(commandParameters);
                    oracleCommand.Parameters.Add(AddOutputParameter(CursorName));
                    OracleDataReader oracleDataReader = oracleCommand.ExecuteReader();
                    if (oracleDataReader.Read())
                    {
                        t = Activator.CreateInstance<T>();
                        PropertyInfo[] properties = t.GetType().GetProperties();
                        for (int i = 0; i < properties.Length; i++)
                        {
                            PropertyInfo propertyInfo = properties[i];
                            try
                            {
                                string attributeDisplayName = ReflectionExtensions.GetAttributeDisplayName(propertyInfo);
                                if (!object.Equals(oracleDataReader[attributeDisplayName], DBNull.Value))
                                {
                                    propertyInfo.SetValue(t, oracleDataReader[attributeDisplayName], null);
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    oracleDataReader.Close();
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                }
                catch (Exception ex)
                {
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                    throw ex;
                }
            }
            return t;
        }
        public virtual string ExecuteReaderOuputText(string connString, string Parameter, string storedProcedureName, params OracleParameter[] commandParameters)
        {
            string result = "OK";
            using (OracleConnection oracleConnection = new OracleConnection(connString))
            {
                oracleConnection.Open();
                try
                {
                    OracleCommand oracleCommand = new OracleCommand
                    {
                        Connection = oracleConnection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = storedProcedureName
                    };
                    oracleCommand.Parameters.AddRange(commandParameters);
                    OracleDataReader oracleDataReader = oracleCommand.ExecuteReader();
                    result = oracleCommand.Parameters[Parameter].Value.ToString().Trim();
                    oracleCommand.Parameters.Clear();
                    oracleDataReader.Close();
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                }
                catch (Exception ex)
                {
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                    result = ex.Message;
                }
            }
            return result;
        }
        public virtual string ExecuteReaderOuput(string OracleConnectionString, string CursorName, string storedProcedureName, string columnName, params OracleParameter[] commandParameters)
        {
            string result = "OK";
            using (OracleConnection oracleConnection = new OracleConnection(OracleConnectionString))
            {
                oracleConnection.Open();
                try
                {
                    OracleCommand oracleCommand = new OracleCommand
                    {
                        Connection = oracleConnection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = storedProcedureName
                    };
                    oracleCommand.Parameters.AddRange(commandParameters);
                    oracleCommand.Parameters.Add(AddOutputParameter(CursorName));
                    OracleDataReader oracleDataReader = oracleCommand.ExecuteReader();
                    if (oracleDataReader.Read())
                    {
                        result = oracleDataReader[columnName].ToString();
                    }
                    oracleDataReader.Close();
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                }
                catch (Exception ex)
                {
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                    throw ex;
                }
            }
            return result;
        }
        public int ExecuteNonQuery(string OracleConnectionString, string CursorName, string storedProcedureName, DataTable listDetails, params OracleParameter[] commandParameters)
        {
            if (string.IsNullOrEmpty(OracleConnectionString))
            {
                throw new ArgumentNullException("connectionString");
            }
            int result = 0;
            using (OracleConnection oracleConnection = new OracleConnection(OracleConnectionString))
            {
                oracleConnection.Open();
                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter();
                try
                {
                    OracleCommand oracleCommand = new OracleCommand
                    {
                        Connection = oracleConnection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = storedProcedureName
                    };
                    oracleCommand.Parameters.AddRange(commandParameters);
                    oracleDataAdapter.InsertCommand = oracleCommand;
                    result = oracleDataAdapter.Update(listDetails);
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                }
                catch (Exception ex)
                {
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                    throw ex;
                }
            }
            return result;
        }

        public int ExecuteNonQuery(string con, string storedProcedureName, DataTable listDetails, params OracleParameter[] commandParameters)
        {
            if (string.IsNullOrEmpty(con))
            {
                throw new ArgumentNullException("connectionString");
            }
            int result = 0;
            using (OracleConnection oracleConnection = new OracleConnection(con))
            {
                oracleConnection.Open();
                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter();
                try
                {
                    OracleCommand oracleCommand = new OracleCommand
                    {
                        Connection = oracleConnection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = storedProcedureName
                    };
                    oracleCommand.Parameters.AddRange(commandParameters);
                    oracleDataAdapter.InsertCommand = oracleCommand;
                    result = oracleDataAdapter.Update(listDetails);
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                }
                catch (Exception ex)
                {
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                    throw ex;
                }
            }
            return result;
        }

        public virtual int ExecuteNonQuery(string OracleConnectionString, string CursorName, string storedProcedureName, params OracleParameter[] commandParameters)
        {
            if (string.IsNullOrEmpty(OracleConnectionString))
            {
                throw new ArgumentNullException("connectionString");
            }
            int result = 0;
            using (OracleConnection oracleConnection = new OracleConnection(OracleConnectionString))
            {
                oracleConnection.Open();
                try
                {
                    OracleCommand oracleCommand = new OracleCommand
                    {
                        Connection = oracleConnection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = storedProcedureName
                    };
                    oracleCommand.Parameters.AddRange(commandParameters);
                    result = oracleCommand.ExecuteNonQuery();
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                }
                catch (Exception ex)
                {
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                    throw ex;
                }
            }
            return result;
        }
        public virtual int ExecuteNonQuery(string OracleConnectionString, string CursorName, string storedProcedureName, OracleParameter commandParameter)
        {
            if (string.IsNullOrEmpty(OracleConnectionString))
            {
                throw new ArgumentNullException("connectionString");
            }
            int result = 0;
            using (OracleConnection oracleConnection = new OracleConnection(OracleConnectionString))
            {
                oracleConnection.Open();
                try
                {
                    OracleCommand oracleCommand = new OracleCommand
                    {
                        Connection = oracleConnection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = storedProcedureName
                    };
                    oracleCommand.Parameters.Add(commandParameter);
                    result = oracleCommand.ExecuteNonQuery();
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                }
                catch (Exception ex)
                {
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                    throw ex;
                }
            }
            return result;
        }
        public virtual DataSet ExecuteReader(string OracleConnectionString, string CursorName, string storedProcedureName, params OracleParameter[] commandParameters)
        {
            DataSet dataSet = new DataSet();
            using (OracleConnection oracleConnection = new OracleConnection(OracleConnectionString))
            {
                oracleConnection.Open();
                try
                {
                    OracleCommand oracleCommand = new OracleCommand(storedProcedureName, oracleConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    oracleCommand.Parameters.AddRange(commandParameters);
                    oracleCommand.Parameters.Add(AddOutputParameter(CursorName));
                    OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(oracleCommand);
                    oracleDataAdapter.Fill(dataSet);
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                }
                catch (Exception ex)
                {
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                    throw ex;
                }
            }
            return dataSet;
        }
        public virtual DataSet ExecuteDatasetNoCurse(string OracleConnectionString, string CursorName, string storedProcedureName, params OracleParameter[] commandParameters)
        {
            if (string.IsNullOrEmpty(OracleConnectionString))
            {
                throw new ArgumentNullException("connectionString");
            }
            DataSet dataSet = new DataSet();
            using (OracleConnection oracleConnection = new OracleConnection(OracleConnectionString))
            {
                oracleConnection.Open();
                try
                {
                    OracleCommand oracleCommand = new OracleCommand(storedProcedureName, oracleConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    oracleCommand.Parameters.AddRange(commandParameters);
                    OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(oracleCommand);
                    oracleDataAdapter.Fill(dataSet);
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                }
                catch (Exception ex)
                {
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                    throw ex;
                }
            }
            return dataSet;
        }
        public virtual string ExecuteReaderOuput(string OracleConnectionString, string CursorName, string storedProcedureName, params OracleParameter[] commandParameters)
        {
            if (string.IsNullOrEmpty(OracleConnectionString))
            {
                throw new ArgumentNullException("connectionString");
            }
            string result = "0";
            using (OracleConnection oracleConnection = new OracleConnection(OracleConnectionString))
            {
                oracleConnection.Open();
                try
                {
                    OracleCommand oracleCommand = new OracleCommand
                    {
                        Connection = oracleConnection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = storedProcedureName
                    };
                    oracleCommand.Parameters.AddRange(commandParameters);
                    oracleCommand.Parameters.Add(AddOutputParameter(CursorName));
                    OracleDataReader oracleDataReader = oracleCommand.ExecuteReader();
                    if (oracleDataReader.Read())
                    {
                        result = oracleDataReader[0].ToString();
                    }
                    oracleDataReader.Close();
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                }
                catch (Exception ex)
                {
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                    throw ex;
                }
            }
            return result;
        }
        public virtual DataSet ExecuteReader(string OracleConnectionString, string CursorName, string storedProcedureName)
        {
            if (string.IsNullOrEmpty(OracleConnectionString))
            {
                throw new ArgumentNullException("connectionString");
            }
            DataSet dataSet = new DataSet();
            using (OracleConnection oracleConnection = new OracleConnection(OracleConnectionString))
            {
                oracleConnection.Open();
                try
                {
                    OracleCommand oracleCommand = new OracleCommand(storedProcedureName, oracleConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    oracleCommand.Parameters.Add(AddOutputParameter(CursorName));
                    OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(oracleCommand);
                    oracleDataAdapter.Fill(dataSet);
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                }
                catch (Exception ex)
                {
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                    throw ex;
                }
            }
            return dataSet;
        }
        /// <summary>
        /// Trường hợp biến đầu vào là Cursor
        /// </summary>
        /// <param name="OracleConnectionString"></param>
        /// <param name="CursorName"></param>
        /// <param name="storedProcedureName"></param>
        /// <returns>DataTable</returns>
        public virtual DataTable ExecuteDatatable(string OracleConnectionString, string CursorName, string storedProcedureName)
        {
            DataTable dataTable = new DataTable();
            using (OracleConnection oracleConnection = new OracleConnection(OracleConnectionString))
            {
                oracleConnection.Open();
                try
                {
                    OracleCommand oracleCommand = new OracleCommand(storedProcedureName, oracleConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    oracleCommand.Parameters.Add(AddOutputParameter(CursorName));
                    OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(oracleCommand);
                    oracleDataAdapter.Fill(dataTable);
                    oracleCommand.Parameters.Clear();
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                }
                catch (Exception ex)
                {
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                    throw ex;
                }
            }
            return dataTable;
        }
        /// <summary>
        /// Trường hợp biến đầu vào là nhiều tham số và 1 Cursor
        /// </summary>
        /// <param name="OracleConnectionString"></param>
        /// <param name="CursorName"></param>
        /// <param name="storedProcedureName"></param>
        /// <param name="commandParameters"></param>
        /// <returns>DataTable</returns>
        public virtual DataTable ExecuteDatatable(string OracleConnectionString, string CursorName, string storedProcedureName, params OracleParameter[] commandParameters)
        {
            DataTable dataTable = new DataTable();
            using (OracleConnection oracleConnection = new OracleConnection(OracleConnectionString))
            {
                oracleConnection.Open();
                try
                {
                    OracleCommand oracleCommand = new OracleCommand(storedProcedureName, oracleConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    oracleCommand.Parameters.Clear();
                    oracleCommand.Parameters.AddRange(commandParameters);
                    oracleCommand.Parameters.Add(AddOutputParameter(CursorName));
                    OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(oracleCommand);
                    oracleDataAdapter.Fill(dataTable);
                    oracleCommand.Parameters.Clear();
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                }
                catch (Exception ex)
                {
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                    throw ex;
                }
            }
            return dataTable;
        }
        public virtual List<T> ExecuteReaderOutParameter<T>(string OracleConnectionString, string CursorName, string storedProcedureName)
        {
            if (string.IsNullOrEmpty(OracleConnectionString))
            {
                throw new ArgumentNullException("connectionString");
            }
            List<T> list = new List<T>();
            using (OracleConnection oracleConnection = new OracleConnection(OracleConnectionString))
            {
                oracleConnection.Open();
                try
                {
                    OracleCommand oracleCommand = new OracleCommand
                    {
                        Connection = oracleConnection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = storedProcedureName
                    };
                    oracleCommand.Parameters.Add(AddOutputParameter(CursorName));
                    OracleDataReader oracleDataReader = oracleCommand.ExecuteReader();
                    while (oracleDataReader.Read())
                    {
                        T t = Activator.CreateInstance<T>();
                        PropertyInfo[] properties = t.GetType().GetProperties();
                        for (int i = 0; i < properties.Length; i++)
                        {
                            PropertyInfo propertyInfo = properties[i];
                            try
                            {
                                string attributeDisplayName = ReflectionExtensions.GetAttributeDisplayName(propertyInfo);
                                if (!object.Equals(oracleDataReader[attributeDisplayName], DBNull.Value))
                                {
                                    propertyInfo.SetValue(t, oracleDataReader[attributeDisplayName], null);
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                        list.Add(t);
                    }
                    oracleDataReader.Close();
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                }
                catch (Exception ex)
                {
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                    throw ex;
                }
            }
            return list;
        }
        public virtual int ExecuteScalar(string OracleConnectionString, string CursorName, string commandText)
        {
            if (string.IsNullOrEmpty(OracleConnectionString))
            {
                throw new ArgumentNullException("connectionString");
            }
            int result = 0;
            using (OracleConnection oracleConnection = new OracleConnection(OracleConnectionString))
            {
                oracleConnection.Open();
                try
                {
                    OracleCommand oracleCommand = new OracleCommand
                    {
                        Connection = oracleConnection,
                        CommandType = CommandType.Text,
                        CommandText = commandText
                    };
                    result = (int)oracleCommand.ExecuteOracleScalar();
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                }
                catch (Exception ex)
                {
                    oracleConnection.Close();
                    oracleConnection.Dispose();
                    throw ex;
                }
            }
            return result;
        }
        public OracleType InTextOutOracleType(string Fields)
        {
            switch (Fields)
            {
                case "BFile": return OracleType.BFile;
                case "Blob": return OracleType.Blob;
                case "Byte": return OracleType.Byte;
                case "Char": return OracleType.Char;
                case "Clob": return OracleType.Clob;
                case "Cursor": return OracleType.Cursor;
                case "DateTime": return OracleType.DateTime;
                case "Double": return OracleType.Double;
                case "Float": return OracleType.Float;
                case "Int16": return OracleType.Int16;
                case "Int32": return OracleType.Int32;
                case "IntervalDayToSecond": return OracleType.IntervalDayToSecond;
                case "IntervalYearToMonth": return OracleType.IntervalYearToMonth;
                case "LongRaw": return OracleType.LongRaw;
                case "LongVarChar": return OracleType.LongVarChar;
                case "NChar": return OracleType.NChar;
                case "NClob": return OracleType.NClob;
                case "Number": return OracleType.Number;
                case "NVarChar": return OracleType.NVarChar;
                case "Raw": return OracleType.Raw;
                case "RowId": return OracleType.RowId;
                case "SByte": return OracleType.SByte;
                case "Timestamp": return OracleType.Timestamp;
                case "TimestampLocal": return OracleType.TimestampLocal;
                case "TimestampWithTZ": return OracleType.TimestampWithTZ;
                case "UInt16": return OracleType.UInt16;
                case "UInt32": return OracleType.UInt32;
                case "VarChar": return OracleType.VarChar;
                default: return OracleType.Char;
            }
        }
    }
}
