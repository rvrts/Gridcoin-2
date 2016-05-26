using System;

namespace Gridcoin.BlockExplorerApiClient
{
    public class GridcoinTransactionId
    {
        public string Hash { get; private set; }

        public GridcoinTransactionId(String hash)
        {
            Hash = hash;
        }
    }
}