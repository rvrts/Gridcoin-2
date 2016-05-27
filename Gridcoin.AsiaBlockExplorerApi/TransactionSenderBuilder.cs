namespace Gridcoin.BlockExplorer
{
    public class TransactionSenderBuilder : ITransactionSenderBuilder
    {
        private TransactionHash m_TransactionHash;

        public ITransactionSenderBuilder WithTransactionHash(TransactionHash transactionHash)
        {
            m_TransactionHash = transactionHash;

            return this;
        }

        public ITransactionSender Build()
        {
            return new TransactionSender()
            {
                TransactionHash = m_TransactionHash,
            };
        }
    }
}