using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constracts
{
    public class Constracts
    { 
        private object _Constract = null; public object Constract { get { return _Constract; } set { _Constract = value; } } 
    }
    public class infoBody
    {
        private string _Link = ""; public string Link { get { return _Link; } set { _Link = value; } }
        private List<infoHeaders> _Headers = null; public List<infoHeaders> Headers { get { return _Headers; } set { _Headers = value; } }
        private string _Body = ""; public string Body { get { return _Body; } set { _Body = value; } }
        private string _Type = null; public string Type { get { return _Type; } set { _Type = value; } }
        private string _Status = null; public string Status { get { return _Status; } set { _Status = value; } } 
        private string _Partner = null; public string Partner { get { return _Partner; } set { _Partner = value; } }
        private string _TableName = ""; public string TableName { get { return _TableName; } set { _TableName = value; } }
        private decimal? _Records_ID = null; public decimal? Records_ID { get { return _Records_ID; } set { _Records_ID = value; } }
        private string _Ref = ""; public string Ref { get { return _Ref; } set { _Ref = value; } }
        private string _Note = ""; public string Note { get { return _Note; } set { _Note = value; } }
    }
    public class infoHeaders
    {
        private string _Code = ""; public string Code { get { return _Code; } set { _Code = value; } }
        private string _Values = ""; public string Values { get { return _Values; } set { _Values = value; } }
    }
}
