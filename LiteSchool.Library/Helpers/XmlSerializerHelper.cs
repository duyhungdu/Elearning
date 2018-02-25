using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace LiteSchool.Library.Helpers
{
    public class XmlSerializerHelper
    {
        public static string SerializeToString(Type type, object objectValue)
        {
            if (objectValue != null)
            {
                XmlSerializer serializer;
                try
                {
                    serializer = new XmlSerializer(type);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                StringWriter sw = new StringWriter();
                serializer.Serialize(sw, objectValue);
                return sw.ToString();
            }
            else
                return null;
        }

        public static object DeserializeFromString(Type type, string serializedXml)
        {
            if (serializedXml != null)
            {
                XmlSerializer serializer = new XmlSerializer(type);
                return serializer.Deserialize(new StringReader(serializedXml));
            }
            else
                return null;
        }
    }

    public class XmlSerializerHelper<T>
    {
        public static string SerializeToString(object objectValue)
        {
            return XmlSerializerHelper.SerializeToString(typeof(T), objectValue);
        }

        public static T DeserializeFromString(string serializedXml)
        {
            return (T)XmlSerializerHelper.DeserializeFromString(typeof(T), serializedXml);
        }
    }
}
