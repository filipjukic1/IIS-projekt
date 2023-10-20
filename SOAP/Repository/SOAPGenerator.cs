using SOAP.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace SOAP
{
    public static class SOAPGenerator
    {

        public static XElement GenerateXML()
        {
            XElement xElement = new XElement("Beers");

            List<Beer> beers = GetBeer();

            foreach (var item in beers)
            {
                xElement.Add(
                    new XElement("Beer",
                    new XElement("Title", item.title),
                    new XElement("Description", item.description),
                    new XElement("Alcohol", item.alchool)
                    
                ));
            }

            return xElement;
        }


        public static List<Beer> GetBeer()
        {
            List<Beer> beers = new List<Beer>
            {
                new Beer
                {
                    title="Blank",
                    description="Hmeljcina",
                    alchool="3"
                },
                new Beer
                {
                    title="Blank 2",
                    description="Hmeljcina 2",
                    alchool="7"
                },
                new Beer
                {
                   title="Blank 3",
                    description="Hmeljcina 3",
                    alchool="6"
                }
            };


            return beers;
        }
    }
}
