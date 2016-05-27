namespace Gridcoin.BlockExplorer
{
    public abstract class BlockExplorer : IBlockExplorer
    {
        private readonly IBlockCache m_BlockCache;
        private readonly ITransactionCache m_TransactionCache;

        public BlockExplorer()
        {
            m_BlockCache = new BlockCache();
            m_TransactionCache = new TransactionCache();
        }

        public IBlock GetBlock(BlockIndex blockIndex)
        {
            var block = m_BlockCache.Lookup(blockIndex);
            
            if (block == null)
            {   
                var blockBuilder = new BlockBuilder(this);
                block = OnGetBlock(blockIndex, blockBuilder).Build();
                m_BlockCache.Cache(block);
            }

            return block;
        }
        protected abstract IBlockBuilder OnGetBlock(BlockIndex blockIndex, IBlockBuilder blockBuilder);

        public IBlock GetBlock(BlockHash blockHash)
        {
            var block = m_BlockCache.Lookup(blockHash);

            if (block == null)
            {
                var blockBuilder = new BlockBuilder(this);
                block = OnGetBlock(blockHash, blockBuilder).Build();
                m_BlockCache.Cache(block);
            }

            return block;
        }
        protected abstract IBlockBuilder OnGetBlock(BlockHash blockHash, IBlockBuilder blockBuilder);

        public ITransaction GetTransaction(TransactionHash transactionHash)
        {
            var transaction = m_TransactionCache.Lookup(transactionHash);

            if (transaction == null)
            {
                var transactionBuilder = new TransactionBuilder(this);
                transaction = OnGetTransaction(transactionHash, transactionBuilder).Build();
                m_TransactionCache.Cache(transaction);
            }

            return transaction;
        }
        protected abstract ITransactionBuilder OnGetTransaction(TransactionHash transactionHash, ITransactionBuilder transactionBuilder);
    }
}