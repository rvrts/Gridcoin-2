using System;

namespace Gridcoin.BlockExplorer
{
    public interface IBlockCache
    {
        IBlock Lookup(BlockIndex blockIndex);
        IBlock Lookup(BlockHash blockHash);
        void Cache(IBlock block);
    }
}