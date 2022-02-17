using Orderly.Models.Comman;
using Orderly.Models.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Models.Distributor
{
    public record TransactionDetailModel : BaseEntityModel
    {
        public TransactionDetailModel()
        {

        }
        public string TansactionHashCode { get; set; }
        public DateTime Date { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Quantity { get; set; }
        public string QuantityPostfix { get; set; }
        public decimal DollarAmount { get; set; }
        public string UserAddress { get; set; }
        public bool In
        {
            get
            {
                return UserAddress == To; //if the user address is in to then it is In Transaction
            }
        }
    }
    public record TansactionResponseModel
    {
        public RequestStatus status { get; set; }
        public string message { get; set; }
        public List<TransactionsResult> result { get; set; }
    }

    public record TransactionsResult
    {
        public string blockNumber { get; set; }
        public string timeStamp { get; set; }
        public string hash { get; set; }
        public string nonce { get; set; }
        public string blockHash { get; set; }
        public string transactionIndex { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string value { get; set; }
        public string gas { get; set; }
        public string gasPrice { get; set; }
        public string isError { get; set; }
        public string txreceipt_status { get; set; }
        public string input { get; set; }
        public string contractAddress { get; set; }
        public string cumulativeGasUsed { get; set; }
        public string gasUsed { get; set; }
        public string confirmations { get; set; }
        public string userAddress { get; set; }
        public int networkId { get; set; }
        public string tokenName { get; set; }
        public string tokenSymbol { get; set; }
        public string tokenDecimal { get; set; }
    }
    public record TransactionDetailModelList : BasePagedListModel<TransactionDetailModel>
    {
        public decimal TotalDisributed { get; set; }
        public decimal TotalToBeDisributed { get; set; }
    }
}
