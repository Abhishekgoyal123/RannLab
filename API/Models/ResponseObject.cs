namespace API.Models
{
    public class ResponseObject
    {
        public int AdsId { get; set; }
        public string? YoutubeUrl { get; set; }

        public List<string>? BusinessLocation { get; set; }
        public string? Gender { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ExpiredOn { get; set; }


    }
}
