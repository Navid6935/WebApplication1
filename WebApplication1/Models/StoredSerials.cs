using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class StoredSerials
    {
        public int StoredSerialsId { get; set; }
        public string Serial { get; set; }
        public string Vaziat { get; set; }
        public string SaveTime { get; set; }
        public string SaveDate { get; set; }
        public int NumberofApp { get; set; }
        public bool DataRead { get; set; }
        public int IntervalSec { get; set; }
    }
}
