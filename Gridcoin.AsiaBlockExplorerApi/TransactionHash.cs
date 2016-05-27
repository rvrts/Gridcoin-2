using System;

namespace Gridcoin.BlockExplorer
{
    public struct TransactionHash
    {
        public string Hash { get; private set; }
        
        public TransactionHash(String hash) : this()
        {
            if (hash == null)
                throw new ArgumentNullException(nameof(hash));
            if (hash.Length != 64)
                throw new ArgumentOutOfRangeException(nameof(hash), "A gridcoin transaction hash must be exactly 64 characters long.");

            Hash = hash;
        }
    }
}