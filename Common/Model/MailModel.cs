using System.Collections.Generic;

namespace Common.Model
{
    public class MailModel
    {
        public string SenderAccount { get; set; }
        public string SenderPassword { get; set; }
        public string SenderName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<string> LstReceiver { get; set; }
        public List<string> LstAttachment { get; set; }
    }
}
