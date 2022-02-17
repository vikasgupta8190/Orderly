using Orderly.Models.Comman;

namespace Orderly.Models.Dashboard
{
    public record TokenSearchModel : BaseSearchModel
    {
        public int NextDays { get; set; }
        public int PrevDays { get; set; }
        public string NetworkId { get; set; }
    }
}
