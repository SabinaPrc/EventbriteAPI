using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventbriteNET.Entities;
using System.IO;
using System.Xml;

namespace EventbriteNET.Xml
{
    class EventOrganizerBuilder : BuilderBase
    {
        public EventOrganizerBuilder(EventbriteContext context) : base(context) { }

        public EventOrganizer Build(string xmlString)
        {
            this.Validate(xmlString);

            var stringReader = new StringReader(xmlString);

            var toReturn = new EventOrganizer(this.Context);

            var doc = new XmlDocument();
            doc.LoadXml(xmlString);

            toReturn.Id = long.Parse(doc.GetElementsByTagName("id")[0].InnerText);
            toReturn.Name = doc.GetElementsByTagName("name")[0].InnerText;
            toReturn.Description = doc.GetElementsByTagName("description")[0].InnerText;
            toReturn.LongDescription = doc.GetElementsByTagName("long_description")[0].InnerText;
            toReturn.Url = doc.GetElementsByTagName("url")[0].InnerText;

            return toReturn;
        }
    }
}
