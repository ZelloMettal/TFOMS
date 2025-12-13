using System.Data.SqlTypes;
using System.Xml.Linq;
using System.Xml.Schema;

namespace ClinicalExamination.Classes
{
    internal class ValidatorXML
    {
        private string error = "";
        public ValidatorXML() { }

        public string Error
        { 
            get { return error; }
        }
        public bool Validator(string xml_patch, string xsd_patch) 
        {
            bool isValid = true;
            XmlSchemaSet schemaSet = new XmlSchemaSet();

            schemaSet.Add("", xsd_patch);
            XDocument xmlDocument = XDocument.Load(xml_patch);

            xmlDocument.Validate(schemaSet, (o, e) =>
            {
                error = e.Message;
                isValid = false;
            });

            return isValid;
        }
    }
}
