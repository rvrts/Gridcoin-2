using System;
using Newtonsoft.Json;

namespace Gridcoin.BlockExplorer.Web.Asia.Rest.Entities
{
    public class AsiaScriptPubKey
    {
        [JsonProperty("addresses")]
        public String[] Addresses { get; set; }
    }
}