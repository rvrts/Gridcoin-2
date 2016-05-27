using Gridcoin.BlockExplorer.Web.Asia.Rest.Entities;

namespace Gridcoin.BlockExplorer.Web.Asia.Rest
{
    public interface IAsiaTransaction
    {
        string BlockHash { get; set; }
        AsiaTransactionSender[] Senders { get; set; }
        AsiaTransactionRecipient[] Recipients { get; set; }
        long Time { get; set; }
        string TransactionId { get; set; }
        int Version { get; set; }
    }
}