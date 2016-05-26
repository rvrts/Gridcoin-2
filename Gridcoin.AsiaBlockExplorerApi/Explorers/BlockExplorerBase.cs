using System;
using System.Threading.Tasks;
using Gridcoin.BlockExplorerApiClient.Rest;
using Newtonsoft.Json;

namespace Gridcoin.BlockExplorerApiClient.Explorers
{
    public abstract class BlockExplorerBase : IBlockExplorerApi
    {
        public static IRestClient DefaultRestClient { get; private set; }

        public String Name { get; private set; }
        public Uri ApiRoot { get; private set; }
        public IRestClient RestClient { get; private set; }

        static BlockExplorerBase()
        {
            DefaultRestClient = new PortableRestClient();
        }

        public BlockExplorerBase(String name, Uri apiRoot)
            : this(name, apiRoot, DefaultRestClient)
        {
            
        }
        public BlockExplorerBase(String name, Uri apiRoot, IRestClient restClient)
        {
            if (apiRoot == null) throw new ArgumentNullException(nameof(apiRoot));
            if (restClient == null) throw new ArgumentNullException(nameof(restClient));

            Name = name;
            ApiRoot = apiRoot;
            RestClient = restClient;
        }

        protected async Task<TResult> ExecuteQueryAsync<TResult>(IRestQuery query)
        {
            var content = await RestClient.ExecuteQueryAsync(query);
            var result = JsonConvert.DeserializeObject<TResult>(content);

            return result;
        }

        public abstract IDifficulty GetCurrentDifficulty();
        public abstract IBalance GetBalance(GridcoinAddress address);
        public abstract IBlock GetBlock(BlockHash blockHash);
        public abstract ITransaction GetTransaction(GridcoinTransactionId transactionId);
    }
}
