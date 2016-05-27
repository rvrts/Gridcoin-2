using System;

namespace Gridcoin.BlockExplorer
{
    public struct BlockHash
    {
        public string Hash { get; private set; }

        public BlockHash(String hash) : this()
        {
            if (hash == null)
                throw new ArgumentNullException(nameof(hash));
            if(hash.Length != 64)
                throw new ArgumentOutOfRangeException(nameof(hash), "A gridcoin block hash must be exactly 64 characters long.");

            Hash = hash;
        }
    }
}