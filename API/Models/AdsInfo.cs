using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class AdsInfo
    {
        public AdsInfo()
        {
            AdMappings = new HashSet<AdMapping>();
            Adslocations = new HashSet<Adslocation>();
        }

        public int AdsId { get; set; }
        public string? YoutubeUrl { get; set; }
        public string? Gender { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ExpiredOn { get; set; }

        public virtual ICollection<AdMapping> AdMappings { get; set; }
        public virtual ICollection<Adslocation> Adslocations { get; set; }
    }
}
