using Orderly.Models.Comman;

namespace Orderly.Models.Investment
{
    public partial record DistributionTypeModel : BaseEntityModel
    {
        public int TGE { get; set; }
        public int? Peroid { get; set; }
        public int? Lockup { get; set; }
        public int? LockupDuration { get; set; }
        public int? TokenPercentage { get; set; }
    }
}
