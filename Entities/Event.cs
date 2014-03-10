using System;
using System.Collections.Generic;
using EventbriteNET.HttpApi;

namespace EventbriteNET.Entities
{
    public class Event : EntityBase
    {
        public long Id;
        public string Title;
        public string Category;
        public string Description;
        public string Privacy;
        public DateTime StartDateTime;
        public DateTime EndDateTime;
        public DateTime Created;
        public DateTime Modified;
        public string Url;
        public string Status;
        public string Repeats;
        public string RepeatSchedule;
        public EventOrganizer Organizer;

        public Dictionary<long, Venue> Venues = new Dictionary<long, Venue>();
        public Dictionary<long, Ticket> Tickets = new Dictionary<long, Ticket>();

        private List<Attendee> attendees;
        public List<Attendee> Attendees
        {
            get
            {
                if (this.attendees == null)
                {
                    this.attendees = new List<Attendee>();
                    this.attendees.AddRange(new EventAttendeesRequest(this.Id, Context).GetResponse());
                }
                return attendees;
            }
        }

        public Event(EventbriteContext context) : base(context) { }
    }
}
