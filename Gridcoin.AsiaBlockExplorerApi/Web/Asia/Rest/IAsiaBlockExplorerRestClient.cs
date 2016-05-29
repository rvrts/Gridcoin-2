using Gridcoin.BlockExplorer.Web.Asia.Rest.Entities;

namespace Gridcoin.BlockExplorer.Web.Asia.Rest
{
    public interface IAsiaBlockExplorerRestClient
    {
        IAsiaDifficulty GetCurrentDifficulty();
        IAsiaBalance GetBalance(GridcoinAddress address);
        BlockHash GetBlockHash(BlockIndex blockIndex);
        IAsiaBlock GetBlock(BlockHash blockHash);
        IAsiaTransaction GetTransaction(TransactionHash transactionHash);
    }
}