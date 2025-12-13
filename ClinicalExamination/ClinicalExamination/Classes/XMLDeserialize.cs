using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ClinicalExamination.Classes
{
    internal class XMLDeserialize
    {
        private ZL_LIST _XML;

        public XMLDeserialize() { }

        public ZL_LIST GetXML
        {
            get {return _XML;}
        }

        public ZL_LIST XmlDeserializer(string patch_file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ZL_LIST));
            using (FileStream fs = new FileStream(patch_file, FileMode.OpenOrCreate))
            {
                _XML = (ZL_LIST)serializer.Deserialize(fs);
            }
            return _XML;
        }

    }
}
