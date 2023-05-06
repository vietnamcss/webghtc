using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Librarys.Ui
{
    public class ReflectionExtensions
    {
        public static string GetDisplayName(object obj, string propertyName)
        {
            string result;
            if (obj == null)
            {
                result = null;
            }
            else
            {
                result = ReflectionExtensions.GetDisplayName(obj.GetType(), propertyName);
            }
            return result;
        }

        public static string GetDisplayName(Type type, string propertyName)
        {
            PropertyInfo property = type.GetProperty(propertyName);
            string result;
            if (property == null)
            {
                result = null;
            }
            else
            {
                result = ReflectionExtensions.GetDisplayName(property);
            }
            return result;
        }

        public static string GetDisplayName(PropertyInfo property)
        {
            string attributeDisplayName = ReflectionExtensions.GetAttributeDisplayName(property);
            string result;
            if (!string.IsNullOrEmpty(attributeDisplayName))
            {
                result = attributeDisplayName;
            }
            else
            {
                string metaDisplayName = ReflectionExtensions.GetMetaDisplayName(property);
                if (!string.IsNullOrEmpty(metaDisplayName))
                {
                    result = metaDisplayName;
                }
                else
                {
                    result = property.Name;
                }
            }
            return result;
        }

        public static string GetAttributeDisplayName(PropertyInfo property)
        {
            object[] customAttributes = property.GetCustomAttributes(typeof(DisplayNameAttribute), true);
            string result;
            if (customAttributes.Length == 0)
            {
                result = null;
            }
            else
            {
                result = (customAttributes[0] as DisplayNameAttribute).DisplayName;
            }
            return result;
        }

        public static string GetMetaDisplayName(PropertyInfo property)
        {
            object[] customAttributes = property.DeclaringType.GetCustomAttributes(typeof(MetadataTypeAttribute), true);
            string result;
            if (customAttributes.Length == 0)
            {
                result = null;
            }
            else
            {
                MetadataTypeAttribute metadataTypeAttribute = customAttributes[0] as MetadataTypeAttribute;
                PropertyInfo property2 = metadataTypeAttribute.MetadataClassType.GetProperty(property.Name);
                if (property2 == null)
                {
                    result = null;
                }
                else
                {
                    result = ReflectionExtensions.GetAttributeDisplayName(property2);
                }
            }
            return result;
        }

    }
}
