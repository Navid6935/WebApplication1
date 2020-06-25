using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public partial class Category
    {
        [Key]
        public int CatId { get; set; }
        public string Category1 { get; set; }
        public string Serial { get; set; }
    }
}
