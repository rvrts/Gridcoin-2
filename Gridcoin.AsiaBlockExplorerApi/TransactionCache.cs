using System.Collections.Generic;

namespace Gridcoin.BlockExplorer
{
    public class TransactionCache : ITransactionCache
    {
        private IDictionary<TransactionHash, ITransaction> m_Transactions;

        public TransactionCache()
        {
            m_Transactions = new Dictionary<TransactionHash,ITransaction>();
        }

        public ITransaction Lookup(TransactionHash transactionHash)
        {
            ITransaction result = null;

            m_Transactions.TryGetValue(transactionHash, out result);

            return result;
        }
        public void Cache(ITransaction transaction)
        {
            m_Transactions.Add(transaction.Hash, transaction);
        }
    }
}