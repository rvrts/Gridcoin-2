namespace Gridcoin.BlockExplorer
{
    public interface ITransactionCache
    {
        ITransaction Lookup(TransactionHash transactionHash);
        void Cache(ITransaction transaction);
    }
}