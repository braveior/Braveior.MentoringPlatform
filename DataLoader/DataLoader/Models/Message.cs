using System;
using System.Collections.Generic;

#nullable disable

namespace DataLoader.Models
{
    public partial class Message
    {
        public long MessageId { get; set; }
        public string MessageContent { get; set; }
        public long UserId { get; set; }
        public long ChannelId { get; set; }
        public int MessageLike { get; set; }
        public bool BraveiorLike { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Channel Channel { get; set; }
        public virtual User User { get; set; }
    }
}
