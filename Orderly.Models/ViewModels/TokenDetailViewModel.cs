namespace Orderly.Models.ViewModels
{
    public class TokenDetailViewModel
    {
        public string address { get; set; }
        public string name { get; set; }
        public string decimals { get; set; }
        public string symbol { get; set; }
        public string totalSupply { get; set; }
        public string owner { get; set; }
        public int transfersCount { get; set; }
        public int lastUpdated { get; set; }
        public int issuancesCount { get; set; }
        public int holdersCount { get; set; }
        public string image { get; set; }
        public string website { get; set; }
        public string telegram { get; set; }
        public string twitter { get; set; }
        public string reddit { get; set; }
        public string coingecko { get; set; }
        public int ethTransfersCount { get; set; }
        public object price { get; set; }
        public int countOps { get; set; }
    }
}
