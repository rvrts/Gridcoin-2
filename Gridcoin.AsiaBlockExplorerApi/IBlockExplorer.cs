using System.Diagnostics.Contracts;
using Gridcoin.BlockExplorer.Web.Asia;
using Gridcoin.BlockExplorer.Web.Asia.Rest;
using Gridcoin.BlockExplorer.Web.Asia.Rest.Entities;

namespace Gridcoin.BlockExplorer
{
    public interface IBlockExplorer
    {
        IBlock GetBlock(BlockIndex blockIndex);
        IBlock GetBlock(BlockHash blockHash);

        ITransaction GetTransaction(TransactionHash transactionHash);
    }
}
