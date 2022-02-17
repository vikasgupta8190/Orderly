using System.Collections.Generic;

namespace Orderly.Models.ViewModels
{
    public class Price
    {
        public double rate { get; set; }
        public double diff { get; set; }
        public double diff7d { get; set; }
        public int ts { get; set; }
        public double marketCapUsd { get; set; }
        public double availableSupply { get; set; }
        public double volume24h { get; set; }
        public double diff30d { get; set; }
        public double volDiff1 { get; set; }
        public double volDiff7 { get; set; }
        public double volDiff30 { get; set; }
    }

    public class ETH
    {
        public Price price { get; set; }
        public decimal balance { get; set; }
        public string rawBalance { get; set; }
    }

    public class ContractInfo
    {
        public string creatorAddress { get; set; }
        public string transactionHash { get; set; }
        public int timestamp { get; set; }
    }

    public class TokenInfo
    {
        public string address { get; set; }
        public string decimals { get; set; }
        public string name { get; set; }
        public string owner { get; set; }
        public string symbol { get; set; }
        public string totalSupply { get; set; }
        public int lastUpdated { get; set; }
        public int slot { get; set; }
        public string storageTotalSupply { get; set; }
        public int issuancesCount { get; set; }
        public int holdersCount { get; set; }
        public int ethTransfersCount { get; set; }
        public object price { get; set; }
        public string image { get; set; }
        public string website { get; set; }
        public string facebook { get; set; }
        public string telegram { get; set; }
        public string twitter { get; set; }
        public string reddit { get; set; }
        public string coingecko { get; set; }
    }

    public class Token
    {
        public TokenInfo tokenInfo { get; set; }
        public object balance { get; set; }
        public int totalIn { get; set; }
        public int totalOut { get; set; }
        public string rawBalance { get; set; }
    }

    public class AddressDetailsResponse
    {
        public string address { get; set; }
        public ETH ETH { get; set; }
        public int countTxs { get; set; }
        public ContractInfo contractInfo { get; set; }
        public TokenInfo tokenInfo { get; set; }
        public List<Token> tokens { get; set; }
    }

    public class PriceDetail
    {
        public double rate { get; set; }
        public double diff { get; set; }
        public double diff7d { get; set; }
        public int ts { get; set; }
        public double marketCapUsd { get; set; }
        public double availableSupply { get; set; }
        public double volume24h { get; set; }
        public double diff30d { get; set; }
        public double volDiff1 { get; set; }
        public double volDiff7 { get; set; }
        public double volDiff30 { get; set; }
        public string currency { get; set; }
    }

}
