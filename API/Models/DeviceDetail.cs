using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class DeviceDetail
    {
        public DeviceDetail()
        {
            AdMappings = new HashSet<AdMapping>();
        }

        public int DeviceId { get; set; }
        public string? Mac { get; set; }
        public DateTime? AddedOn { get; set; }
        public string? BusinessLocation { get; set; }
        public string? GenderPrefrence { get; set; }

        public virtual ICollection<AdMapping> AdMappings { get; set; }
    }
}
