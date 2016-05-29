using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gridcoin.BlockExplorer
{
    public struct BlockIndex
    {
        public long Value { get; private set; }

        public BlockIndex(Int64 value) : this()
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Block index must be positive. Index 0 is the genesis block");

            Value = value;
        }

        public BlockIndex Decrement()
        {
            if (Value == 0)
                throw new InvalidOperationException("Block index is already the lowest possible");

            return new BlockIndex(Value - 1);
        }
        public BlockIndex Increment()
        {
            if (Value == Int64.MaxValue)
                throw new InvalidOperationException("Block index is already the highest possible");

            return new BlockIndex(Value + 1);
        }
    }
}
