using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventbriteNET.HttpApi;

namespace EventbriteNET.Entities
{
    public class EventCollection : EntityBase
    {
        private Dictionary<long, Event> events;
        public Dictionary<long, Event> Events
        {
            get
            {
                if (events == null)
                {
                    events = new Dictionary<long, Event>();
                    var eventArray = new EventCollectionRequest(Context).GetResponse();
                    foreach (var eventEntity in eventArray)
                    {
                        events.Add(eventEntity.Id, eventEntity);
                    }
                }
                return events;
            }
        }

         public EventCollection(EventbriteContext context) : base(context) { }
    }
}
