namespace TradingApp_1.Models
{
    
        public class SecureResponse
        {
            public string? UserName { get; set; }
            public string? Message { get; set; }
            public int StatusCode { get; set; }
            public string? Token { get; set; }
        }
    
}
