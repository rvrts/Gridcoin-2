using System;
using Newtonsoft.Json;

namespace Gridcoin.BlockExplorer.Web.Asia.Rest.Entities
{
    public class AsiaTransactionRecipient
    {
        [JsonProperty("value")]
        public Decimal Value { get; set; }

        [JsonProperty("scriptPubKey")]
        public AsiaScriptPubKey Key { get; set; }
    }
}