﻿using System;
using Newtonsoft.Json;

namespace Gridcoin.BlockExplorerApiClient.JsonEntities
{
    public class Difficulty : IDifficulty
    {
        [JsonProperty("proof-of-work")]
        public Decimal ProofOfWork { get; set; }

        [JsonProperty("proof-of-stake")]
        public Decimal ProofOfStake { get; set; }

        [JsonProperty("search-interval")]
        public Decimal SearchInterval { get; set; }
    }
}
