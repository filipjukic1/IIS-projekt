using SOAP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Services;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace SOAP
{
    /// <summary>
    /// Summary description for SOAP
    /// </summary>
    /// //Deklaracija web servisa
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SOAP : System.Web.Services.WebService
    {
        private List<Beer> beerList = SOAPGenerator.GetBeer();

        




        [WebMethod]

        public string Pretrazi(string query)
        {




            XElement xElement = SOAPGenerator.GenerateXML();



            string filePath = "C:\\BeerGenPath.xml";



            IEnumerable<XElement> result = xElement.XPathSelectElements($"//Beer[Title='{query}']");



            XElement recipes = new XElement("Beer", result);
            recipes.Save(filePath);



            StringBuilder sb = new StringBuilder();
            result.ToList().ForEach(e => sb.Append(e));



            return sb.ToString();
        }
    }
}

