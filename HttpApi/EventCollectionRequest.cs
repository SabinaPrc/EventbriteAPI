using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventbriteNET.Entities;
using EventbriteNET.Xml;

namespace EventbriteNET.HttpApi
{
    class EventCollectionRequest : RequestBase
    {
        const string PATH = "user_list_events";

        public EventCollectionRequest(EventbriteContext context)
            : base(PATH, context)
        {
        }

        public Event[] GetResponse()
        {
            return new EventCollectionBuilder(this.Context).Build(base.GetResponse());
        }
    }
}
