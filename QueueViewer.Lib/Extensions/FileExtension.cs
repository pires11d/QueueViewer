using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace QueueViewer.Lib.Extensions
{
    public static class FileExtension
    {
        public static void SaveXML(object obj, string path)
        {
            try
            {
                var folder = Path.GetDirectoryName(path);
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
                XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
                xmlns.Add(string.Empty, string.Empty);
                TextWriter writer = new StreamWriter(path);
                xmlSerializer.Serialize(writer, obj, xmlns);
            }
            catch (Exception)
            {
            }
        }

        public static object LoadXML(string path, object obj)
        {
            try
            {
                if (!File.Exists(path))
                    return obj;

                XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
                using (Stream reader = new FileStream(path, FileMode.Open))
                {
                    return xmlSerializer.Deserialize(reader);
                }
            }
            catch (Exception)
            {
                return obj;
            }
        }
    }
}
