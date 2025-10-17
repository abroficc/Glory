using System;

namespace Inspinia.Models
{
    public class MessageFormatting
    {
        public int Id { get; set; }
        public string MessageTitle { get; set; }
        public string MessageContent { get; set; }
        public string MessageType { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int Status { get; set; }
        public string Notes { get; set; }
    }
}