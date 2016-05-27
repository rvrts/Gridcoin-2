namespace Gridcoin.BlockExplorer
{
    public class TransactionRecipient : ITransactionRecipient
    {
        public decimal Value { get; set; }
        public GridcoinAddress Address { get; set; }
    }
}