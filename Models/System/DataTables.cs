using System.Data; 
using System.Runtime.CompilerServices; 

namespace Models.System
{
    public class DataTables
    {
        public DataTable CloneTable(DataTable dt)
        {
            DataTable dataTable = new DataTable();
            dataTable = dt.Clone();
            int num = dt.Rows.Count - 1;
            for (int i = 0; i <= num; i++)
            {
                DataRow dataRow = dataTable.NewRow();
                int num2 = dt.Columns.Count - 1;
                for (int j = 0; j <= num2; j++)
                {
                    dataRow[j] = RuntimeHelpers.GetObjectValue(dt.Rows[i][j]);
                }
                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }
    }

}
