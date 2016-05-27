using System;

namespace Gridcoin.BlockExplorer
{
    public class BlockBuilder : IBlockBuilder
    {
        private BlockIndex m_Index;
        private BlockHash m_Hash;

        public IBlockExplorer BlockExplorer { get; private set; }

        public BlockBuilder(IBlockExplorer blockExplorer)
        {
            if (blockExplorer == null) throw new ArgumentNullException(nameof(blockExplorer));

            BlockExplorer = blockExplorer;
        }

        public IBlockBuilder WithIndex(BlockIndex blockIndex)
        {
            m_Index = blockIndex;

            return this;
        }
        public IBlockBuilder WithHash(BlockHash blockHash)
        {
            m_Hash = blockHash;

            return this;
        }

        public IBlock Build()
        {
            return new Block(BlockExplorer)
            {
                Index = m_Index,
                Hash = m_Hash,
            };
        }
    }
}