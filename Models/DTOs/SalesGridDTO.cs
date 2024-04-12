using System.Text.Json.Serialization;

namespace QuarterlySalesApp.Models.DTOs
{
    public class SalesGridDTO : GridDTO
    {
        [JsonIgnore]
        public const string DefaultFilter = "all";

        public string Employee { get; set; } = DefaultFilter;
    }
}
