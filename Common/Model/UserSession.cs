using System.Collections.Generic;

namespace Common.Model
{
    public class UserSession
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<string> LstPermission { get; set; } 
        public string IpAddress { get; set; }
        public string BrowserName { get; set; }
    }
}
