using System.Collections.Generic;

namespace Orderly.Models.Portfolio
{
    public class TransactionDetailResult
    {
        public string blockHash { get; set; }
        public string blockNumber { get; set; }
        public string from { get; set; }
        public string gas { get; set; }
        public string gasPrice { get; set; }
        public string maxFeePerGas { get; set; }
        public string maxPriorityFeePerGas { get; set; }
        public string hash { get; set; }
        public string input { get; set; }
        public string nonce { get; set; }
        public string to { get; set; }
        public string transactionIndex { get; set; }
        public string value { get; set; }
        public string type { get; set; }
        public List<object> accessList { get; set; }
        public string chainId { get; set; }
        public string v { get; set; }
        public string r { get; set; }
        public string s { get; set; }
    }

    public class Error
    {
        public int code { get; set; }
        public string message { get; set; }
    }

    public class TransactionDetailModel
    {
        public string jsonrpc { get; set; }
        public int id { get; set; }
        public TransactionDetailResult result { get; set; }
        public Error error { get; set; }
    }

}
