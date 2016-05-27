using System.Collections.Generic;

namespace Gridcoin.BlockExplorer
{
    public class BlockCache : IBlockCache
    {
        private IDictionary<BlockIndex, BlockHash> m_BlockHashes; 
        private IDictionary<BlockHash, IBlock> m_Blocks;

        public BlockCache()
        {
            m_BlockHashes = new Dictionary<BlockIndex, BlockHash>();
            m_Blocks = new Dictionary<BlockHash, IBlock>();
        }

        public IBlock Lookup(BlockIndex blockIndex)
        {
            IBlock result = null;

            BlockHash hash;

            if (m_BlockHashes.TryGetValue(blockIndex, out hash))
                result = Lookup(hash);

            return result;
        }
        public IBlock Lookup(BlockHash blockHash)
        {
            IBlock result = null;

            m_Blocks.TryGetValue(blockHash, out result);

            return result;
        }
        public void Cache(IBlock block)
        {
            m_BlockHashes.Add(block.Index, block.Hash);
            m_Blocks.Add(block.Hash, block);
        }
    }
}