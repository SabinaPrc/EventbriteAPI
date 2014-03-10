using EventbriteNET.Entities;
using EventbriteNET.Xml;

namespace EventbriteNET.HttpApi
{
    class OrganizerEventsRequest : RequestBase
    {
        //const string PATH = "organizer_list_events";
        const string PATH = "user_list_events";

        //public OrganizerEventsRequest(long organiserId, EventbriteContext context)
        //    : base(PATH, context)
        //{
        //    this.AddGet("id", organiserId.ToString());
        //}

        public OrganizerEventsRequest(EventbriteContext context)
            : base(PATH, context)
        {
            //this.AddGet("id", organiserId.ToString());
        }

        public Event[] GetResponse()
        {
            return new OrganizerEventsBuilder(this.Context).Build(base.GetResponse());
        }
    }
}
