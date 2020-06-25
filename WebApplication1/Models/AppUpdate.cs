using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public partial class AppUpdate
    {
        [Key]
        public int AppUpdateId { get; set; }
        public long AppVer { get; set; }
        public string AppLink { get; set; }
        public string AppMode { get; set; }
    }
}
