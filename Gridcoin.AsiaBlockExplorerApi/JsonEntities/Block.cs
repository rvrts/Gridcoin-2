using System;
using Newtonsoft.Json;

namespace Gridcoin.BlockExplorerApiClient.JsonEntities
{
    public class Block : IBlock
    {
        [JsonProperty("hash")]
        public String Hash { get; set; }
        [JsonProperty("height")]
        public Int64 Height { get; set; }
        [JsonProperty("tx")]
        public String[] Transactions { get; set; }
    }
}