using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace homework7
{
    public class Logger
    {
        private string _fullPath;
        public Logger(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            _fullPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, fileName));
        }

        public void Track<T>(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("Argument must be Null");
            }

            var attr = typeof(T).GetCustomAttribute<TrackingEntityAttribute>();

            if (attr != null)
            {
                var jsonAttrProp = GetPropertiesWithAttribute<T, TrackingPropertyAttribute>();
                var jsonAttrField = GeFieldsWithAttribute<T, TrackingPropertyAttribute>();
                List<string> list = new List<string>();

                foreach (var item in jsonAttrProp)
                {
                    var propertyNameAttribute = item.GetCustomAttributes(typeof(TrackingPropertyAttribute), false);
                    var propertyName = (propertyNameAttribute[0] as TrackingPropertyAttribute).PropertyName;
                    if (propertyName == null)
                    {
                        list.Add((string)item.GetValue(obj) + " : " + item.GetValue(obj));
                    }
                    else
                    {
                        list.Add(propertyName + " : " + item.GetValue(obj));
                    }                    
                }

                foreach (var item in jsonAttrField)
                {
                    var fieldNameAttribute = item.GetCustomAttributes(typeof(TrackingPropertyAttribute), false);
                    var fieldName = (fieldNameAttribute[0] as TrackingPropertyAttribute).PropertyName;
                    if (fieldName == null)
                    {
                        list.Add((string)item.GetValue(obj) + " : " + item.GetValue(obj));
                    }
                    else
                    {
                        list.Add(fieldName + " : " + item.GetValue(obj));
                    }
                }

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                    IgnoreNullValues = true
                };

                var json = JsonSerializer.Serialize(list, options);
                File.WriteAllText(_fullPath, json);
            }

        }

        static IEnumerable<PropertyInfo> GetPropertiesWithAttribute<TType, TAttribute>()
        {
            Func<PropertyInfo, bool> matching =
                    property => property.GetCustomAttributes(typeof(TAttribute), false)
                                        .Any();

            return typeof(TType).GetProperties().Where(matching);
        }

        static IEnumerable<FieldInfo> GeFieldsWithAttribute<TType, TAttribute>()
        {
            Func<FieldInfo, bool> matching =
                    property => property.GetCustomAttributes(typeof(TAttribute), false)
                                        .Any();

            return typeof(TType).GetFields().Where(matching);
        }
    }
}
