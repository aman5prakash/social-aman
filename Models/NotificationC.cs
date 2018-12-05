using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NotificationEngine.Model
{
    public class Notification
    {
        public string Message { get; set; }
        public string TargetUrl { get; set; }
        public List<string> Users { get; set; }
    }
}