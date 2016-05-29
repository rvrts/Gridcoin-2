using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Gridcoin.BlockExplorer.Web.Asia.Rest.Entities
{
    public class AsiaTransactionSender
    {
        [JsonProperty("txid")]
        public String TransactionId { get; set; }
    }
}