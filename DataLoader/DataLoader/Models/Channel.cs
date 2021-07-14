using System;
using System.Collections.Generic;

#nullable disable

namespace DataLoader.Models
{
    public partial class Channel
    {
        public Channel()
        {
            Messages = new HashSet<Message>();
        }

        public long ChannelId { get; set; }
        public string Name { get; set; }
        public long GroupId { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Group Group { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
