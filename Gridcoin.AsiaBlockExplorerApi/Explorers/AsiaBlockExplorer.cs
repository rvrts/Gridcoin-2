using System;
using Gridcoin.BlockExplorerApiClient.JsonEntities;
using Gridcoin.BlockExplorerApiClient.Rest;

namespace Gridcoin.BlockExplorerApiClient.Explorers
{
    public class AsiaBlockExplorer : BlockExplorerBase
    {
        public AsiaBlockExplorer()
            : base("Gridcoin Asia Block Explorer", new Uri("http://explorer.gridcoin.asia"))
        {
            
        }

        public override IDifficulty GetCurrentDifficulty()
        {
            var query = new RestQuery().WithRoot(ApiRoot)
                .WithFilter(GridcoinQueryFilter.Api)
                .WithFilter(GridcoinQueryFilter.Difficulty);

            var queryResult = ExecuteQueryAsync<Difficulty>(query).Result;

            return queryResult;
        }

        public override IBalance GetBalance(GridcoinAddress address)
        {
            var query = new RestQuery().WithRoot(ApiRoot)
                .WithFilter(GridcoinQueryFilter.ExtendedApi)
                .WithFilter(GridcoinQueryFilter.Balance.WithValue(address.Hash));

            var queryResult = ExecuteQueryAsync<Decimal>(query).Result;

            return new Balance(queryResult);
        }

        public override IBlock GetBlock(BlockHash blockHash)
        {
            var query = new RestQuery().WithRoot(ApiRoot)
                .WithFilter(GridcoinQueryFilter.Api)
                .WithFilter(GridcoinQueryFilter.Block)
                .WithParameter(GridcoinQueryParameter.Hash.WithValue(blockHash.Hash));

            var queryResult = ExecuteQueryAsync<Block>(query).Result;

            return queryResult;
        }

        public override ITransaction GetTransaction(GridcoinTransactionId transactionId)
        {
            var query = new RestQuery().WithRoot(ApiRoot)
                .WithFilter(GridcoinQueryFilter.Api)
                .WithFilter(GridcoinQueryFilter.Transaction)
                .WithParameter(GridcoinQueryParameter.TransactionId.WithValue(transactionId.Hash))
                .WithParameter(GridcoinQueryParameter.Decrypt);

            var queryResult = ExecuteQueryAsync<Transaction>(query).Result;

            return queryResult;
        }
    }
}
