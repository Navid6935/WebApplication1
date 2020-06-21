using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class AppUpdate
    {
        public int AppUpdateId { get; set; }
        public long AppVer { get; set; }
        public string AppLink { get; set; }
        public string AppMode { get; set; }
    }
}
