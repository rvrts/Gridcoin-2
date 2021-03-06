﻿using System;

namespace Gridcoin.BlockExplorer
{
    public struct GridcoinAddress
    {
        public string Hash { get; private set; }

        public GridcoinAddress(String hash) : this()
        {
            if (hash == null)
                throw new ArgumentNullException(nameof(hash));
            if (hash.Length != 34)
                throw new ArgumentOutOfRangeException(nameof(hash), "A gridcoin address hash must be exactly 34 characters long");

            Hash = hash;
        }
    }
}