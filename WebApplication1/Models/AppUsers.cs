using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public partial class AppUsers
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public int State { get; set; }
        public int City { get; set; }
        public string Mob { get; set; }
        public string Email { get; set; }
        public string Savedate { get; set; }
        public string Savetime { get; set; }
        public string Year { get; set; }
        public string Mounth { get; set; }
        public string Day { get; set; }
        public bool Confirm { get; set; }
        public int NumberDevice { get; set; }
        public string LocationX { get; set; }
        public string LocationY { get; set; }
        public bool Active { get; set; }
        public int Country { get; set; }
        public int ForgetPassword { get; set; }
        public decimal ForgetPassDatetime { get; set; }
    }
}
