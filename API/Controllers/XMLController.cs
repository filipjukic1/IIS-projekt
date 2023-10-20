using API.Model;
using API.Repositories;
using Commons.Xml.Relaxng;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace API.Controllers
{
   
        [ApiController]
        [Route("api/[controller]")]
        public class XMLController : ControllerBase
        {
            string filePathXML = "../Beer.xml";
            string filePathXSD = "../Beer.xsd";
            string filePathRNG = "../Beer.rng";



            [HttpGet("XSD")]
            public string ValidateAgainstXSD()
            {
                //GenerateXML();
                string valid = "XML valid";



                XmlSchemaSet schemaSet = new XmlSchemaSet();
                schemaSet.Add("", filePathXSD);



                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                settings.Schemas = schemaSet;
                settings.ValidationEventHandler += (sender, e) => { valid = "XML not valid"; };




                using (XmlReader reader = XmlReader.Create(filePathXML, settings))
                {
                    while (reader.Read()) { }
                }



                return valid;
            }



            [HttpGet("RELAX")]
            public string ValidateAgainstRNG()
            {
                //GenerateXML();



                try
                {
                    using (XmlReader xml = XmlReader.Create(filePathXML))
                    using (XmlReader relax = XmlReader.Create(filePathRNG))
                    using (var validator = new RelaxngValidatingReader(xml, relax))
                    {
                        XDocument doc = XDocument.Load(validator);
                        return "XML valid";
                    }
                }
                catch (Exception e)
                {
                    return "XML not valid";
                }
            }



            [HttpGet("soap")]
            public async Task<string> PriceChecker(string price)
            {
                var url = "http://localhost:55112/WebServis.asmx/Pretrazi";
                var postData = $"query={price}";



                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded");



                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        response.EnsureSuccessStatusCode();
                        var soapResult = await response.Content.ReadAsStringAsync();
                        return soapResult;
                    }
                }
            }





            public void GenerateXML()
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Beer));
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Encoding = Encoding.UTF8;



                using (XmlWriter writer = XmlWriter.Create(filePathXML, settings))
                {
                    serializer.Serialize(writer, Repository.GetBeer());
                }
            }
        }
    }

