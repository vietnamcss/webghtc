using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models.System
{
    public class clsOracle
    {
        private OracleConnection connOracle;
        private OracleDataReader rstOracle;
        private OracleCommand sqlCommandOracle;
        private OracleTransaction txn;
        private OracleLob clob;
        public clsOracle(string Connect)
        {
            string OracleServerAkses = Connect;
            connOracle = new OracleConnection(OracleServerAkses);
            connOracle.Open();
        }
        public void InsertRecord(string SQLStatement)
        {
            if (SQLStatement.Length > 0)
            {
                if (connOracle.State.ToString().Equals("Open"))
                {
                    sqlCommandOracle =  new  OracleCommand(SQLStatement, connOracle);
                    sqlCommandOracle.ExecuteScalar();
                }
            }
        } 
        public void InsertCLOB(string SQLStatement, string str)
        {
            if (SQLStatement.Length > 0)
            {
                if (connOracle.State.ToString().Equals("Open"))
                {
                    byte[] newvalue = Encoding.Unicode.GetBytes(str);
                    sqlCommandOracle = new  OracleCommand(SQLStatement, connOracle);
                    rstOracle = sqlCommandOracle.ExecuteReader();
                    rstOracle.Read();  
                    txn = connOracle.BeginTransaction();
                    clob = rstOracle.GetOracleLob(0);
                    clob.Write(newvalue, 0, newvalue.Length);
                    txn.Commit();  
                }
            }
        }
        public void CloseDatabase()
        {
            connOracle.Close();
            connOracle.Dispose();
        }
    }
}
