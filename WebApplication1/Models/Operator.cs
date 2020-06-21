using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Operator
    {
        public int OperatorId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string Accessible { get; set; }
    }
}
