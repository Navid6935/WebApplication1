using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public partial class AppDevices
    {
        [Key]
        public int DeviceId { get; set; }
        [Required]
        public string Imei { get; set; }
        [Required]
        public string Serial { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string DeviceName { get; set; }
        [Required]
        public decimal Id { get; set; }
        [Required]
        public string Vaziat { get; set; }
        [Required]
        public string Savetime { get; set; }
        [Required]
        public string SaveDate { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
