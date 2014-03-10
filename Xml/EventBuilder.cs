using System;
using System.Xml;
using EventbriteNET.Entities;

namespace EventbriteNET.Xml
{
    class EventBuilder : BuilderBase
    {
        public EventBuilder(EventbriteContext context) : base(context) { }

        public Event Build(string xmlString)
        {
            this.Validate(xmlString);

            var toReturn = new Event(this.Context);

            var doc = new XmlDocument();
            doc.LoadXml(xmlString);

            toReturn.Id = long.Parse(doc.GetElementsByTagName("id")[0].InnerText);
            toReturn.Title = doc.GetElementsByTagName("title")[0].InnerText;
            toReturn.Category = doc.GetElementsByTagName("category")[0].InnerText;
            toReturn.Description = doc.GetElementsByTagName("description")[0].InnerText;
            toReturn.Privacy = doc.GetElementsByTagName("privacy")[0].InnerText;
            toReturn.StartDateTime = DateTime.Parse(doc.GetElementsByTagName("start_date")[0].InnerText);
            toReturn.EndDateTime = DateTime.Parse(doc.GetElementsByTagName("end_date")[0].InnerText);
            toReturn.Created = DateTime.Parse(doc.GetElementsByTagName("created")[0].InnerText);
            toReturn.Modified = DateTime.Parse(doc.GetElementsByTagName("modified")[0].InnerText);

            toReturn.Url = doc.GetElementsByTagName("url")[1].InnerText;
            toReturn.Status = doc.GetElementsByTagName("status")[0].InnerText;
            toReturn.Repeats = doc.GetElementsByTagName("repeats")[0].InnerText;
            toReturn.RepeatSchedule = "yes" == toReturn.Repeats ? doc.GetElementsByTagName("repeat_schedule")[0].InnerText : string.Empty;

            var venues = doc.GetElementsByTagName("venue");
            var venueBuilder = new VenueBuilder(this.Context);
            foreach (XmlNode venueNode in venues)
            {
                var venue = venueBuilder.Build(venueNode.OuterXml);
                toReturn.Venues.Add(venue.Id, venue);
            }


            var tickets = doc.GetElementsByTagName("ticket");
            var builder = new TicketBuilder(this.Context);
            foreach (XmlNode ticketNode in tickets)
            {
                var ticket = builder.Build(ticketNode.OuterXml);
                toReturn.Tickets.Add(ticket.Id, ticket);
            }

            var organizer = doc.GetElementsByTagName("organizer");
            var organizerBuilder = new EventOrganizerBuilder(this.Context);
            toReturn.Organizer = organizerBuilder.Build(organizer[0].OuterXml);

            return toReturn;
        }
    }
}
