using System;
using System.Collections.Generic;

namespace NetChan.Entities
{
    public class Thread: EntityBase
    {
        public Board Board { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Attachment> Attachments { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime BumpDate { get; set; }
    }
}