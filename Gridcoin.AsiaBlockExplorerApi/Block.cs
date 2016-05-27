using System;

namespace Gridcoin.BlockExplorer
{
    public class Block : IBlock
    {
        public IBlockExplorer BlockExplorer { get; set; }

        public BlockIndex Index { get; set; }
        public BlockHash Hash { get; set; }

        public Block(IBlockExplorer blockExplorer)
        {
            if (blockExplorer == null) throw new ArgumentNullException(nameof(blockExplorer));

            BlockExplorer = blockExplorer;
        }

        public IBlock GetPreviousBlock()
        {
            return BlockExplorer.GetBlock(Index.Decrement());
        }
        public IBlock GetNextBlock()
        {
            return BlockExplorer.GetBlock(Index.Increment());
        }
    }
}