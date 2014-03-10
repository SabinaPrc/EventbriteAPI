using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventbriteNET.Entities
{
    public class EventOrganizer : EntityBase
    {
        public long Id;
        public string Name;
        public string Description;
        public string LongDescription;
        public string Url;

        public EventOrganizer(EventbriteContext context) : base(context) { }
    }
}
