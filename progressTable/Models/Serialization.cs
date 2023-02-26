using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.IO;

namespace progressTable.Models
{
    public class Serialization<T>
    {
        public static void SaveData(T collection, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(stream, collection);
            }
        }
        public static T LoadData(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                return (T)(serializer.Deserialize(stream))!;
            }
        }
    }
}

