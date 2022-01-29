using System;

namespace Braveior.MentoringPlatform.DTO
{
    public class MessageDTO
    {
        public long MessageId { get; set; }
        public string MessageContent { get; set; }
        public long UserId { get; set; }

        public long UserName { get; set; }

        public long ChannelId { get; set; }

        public bool BraveiorLike { get; set; }

        public long MessageLike { get; set; }

    }
}
