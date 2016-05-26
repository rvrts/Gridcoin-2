using System;

namespace Gridcoin.BlockExplorerApiClient
{
    public class GridcoinAddress
    {
        public string Hash { get; private set; }

        public GridcoinAddress(String hash)
        {
            Hash = hash;
        }
    }
}