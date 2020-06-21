using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class EspSerialActive
    {
        public int EsId { get; set; }
        public string UserName { get; set; }
        public string Serial { get; set; }
        public string Qr { get; set; }
        public string SaveDate { get; set; }
        public string SaveTime { get; set; }
    }
}
