using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Adslocation
    {
        public int LocationId { get; set; }
        public int? AdsId { get; set; }
        public string? BusinessLocation { get; set; }

        public virtual AdsInfo? Ads { get; set; }
    }
}
