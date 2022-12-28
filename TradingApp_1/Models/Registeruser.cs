using System;
using System.Collections.Generic;

namespace TradingApp_1.Models
{
    public partial class Registeruser
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? UserPasword { get; set; }
        public string? Photo { get; set; }
        public bool? EmailVerified { get; set; }
    }
}
