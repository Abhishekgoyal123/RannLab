using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class AdMapping
    {
        public int MappingId { get; set; }
        public int? AdsId { get; set; }
        public int? DeviceId { get; set; }

        public virtual AdsInfo? Ads { get; set; }
        public virtual DeviceDetail? Device { get; set; }
    }
}
