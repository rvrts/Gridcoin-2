using System;
using Newtonsoft.Json;

namespace Gridcoin.BlockExplorer.Web.Asia.Rest.Entities
{
    public class AsiaTransaction : IAsiaTransaction
    {
        [JsonProperty("txid")]
        public String TransactionId { get; set; }
        [JsonProperty("version")]
        public Int32 Version { get; set; }
        [JsonProperty("time")]
        public Int64 Time { get; set; }
        [JsonProperty("blockhash")]
        public String BlockHash { get; set; }

        [JsonProperty("vin")]
        public AsiaTransactionSender[] Senders { get; set; }
        [JsonProperty("vout")]
        public AsiaTransactionRecipient[] Recipients { get; set; }
    }
}