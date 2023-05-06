using System.Web.Script.Serialization;

namespace Models.System
{
   public class DataLists
    {
        public string jsonToText(object inputData)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            return javaScriptSerializer.Serialize(inputData);
        }
    }
}
