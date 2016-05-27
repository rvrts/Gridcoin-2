using System;
using System.Threading.Tasks;
using Gridcoin.BlockExplorer.Rest;
using Gridcoin.BlockExplorer.Rest.PortableRest;
using Gridcoin.BlockExplorer.Web.Asia.Rest.Entities;
using Newtonsoft.Json;

namespace Gridcoin.BlockExplorer.Web.Asia.Rest
{
    public class AsiaBlockExplorerRestClient : IAsiaBlockExplorerRestClient
    {
        public static IRestClient DefaultRestClient { get; private set; }
        
        public Uri ApiRoot { get; private set; }
        public IRestClient RestClient { get; private set; }

        static AsiaBlockExplorerRestClient()
        {
            DefaultRestClient = new PortableRestClient();
        }
        public AsiaBlockExplorerRestClient(Uri apiRoot)
            : this(apiRoot, DefaultRestClient)
        {
            
        }
        public AsiaBlockExplorerRestClient(Uri apiRoot, IRestClient restClient)
        {
            if (apiRoot == null) throw new ArgumentNullException(nameof(apiRoot));
            if (restClient == null) throw new ArgumentNullException(nameof(restClient));

            ApiRoot = apiRoot;
            RestClient = restClient;
        }

        protected async Task<IRestResponse> ExecuteRequest(IRestRequest request)
        {
            return await RestClient.ExecuteAsync(request);
        }
        protected TResult Deserialize<TResult>(IRestResponse response)
        {
            if (response.Request.ContentType != ContentType.Json && response.Request.ContentType != ContentType.Raw)
                throw new ArgumentException("I only understand request with json or raw content");
            else if (response.Request.ContentType == ContentType.Raw && typeof(TResult) != typeof(byte[]))
                throw new ArgumentException("For raw content the type of TResult must be byte[]");

            TResult result = default(TResult);

            if (response.Request.ContentType == ContentType.Json)
            {
                var json = response.Value as String;

                if (json == null)
                    throw new Exception();

                if (typeof (TResult) == typeof (String))
                    result = (TResult)response.Value;
                else
                    result = JsonConvert.DeserializeObject<TResult>(json);
            }
            else if (response.Request.ContentType == ContentType.Raw)
            {
                var raw = response.Value as byte[];

                if (raw == null)
                    throw new Exception();

                result = (TResult)response.Value;
            }


            return result;
        }

        public IAsiaDifficulty GetCurrentDifficulty()
        {
            var request = RestRequest.Get.WithRoot(ApiRoot)
                .WithFilter(AsiaQueryFilter.Api)
                .WithFilter(AsiaQueryFilter.Difficulty);

            var response = ExecuteRequest(request).Result;

            var result = Deserialize<AsiaDifficulty>(response);

            return result;
        }
        public IAsiaBalance GetBalance(GridcoinAddress address)
        {
            var request = RestRequest.Get.WithRoot(ApiRoot)
                .WithFilter(AsiaQueryFilter.ExtendedApi)
                .WithFilter(AsiaQueryFilter.Balance.WithValue(address.Hash));

            var response = ExecuteRequest(request).Result;

            var result = Deserialize<Decimal>(response);

            return new AsiaBalance(result);
        }
        public BlockHash GetBlockHash(BlockIndex blockIndex)
        {
            var request = RestRequest.Get.WithRoot(ApiRoot)
                .WithFilter(AsiaQueryFilter.Api)
                .WithFilter(AsiaQueryFilter.BlockHash)
                .WithParameter(AsiaQueryParameter.Index.WithValue(blockIndex.Value));

            var response = ExecuteRequest(request).Result;

            var result = Deserialize<String>(response);

            return new BlockHash(result);
        }
        public IAsiaBlock GetBlock(BlockHash blockHash)
        {
            var request = RestRequest.Get.WithRoot(ApiRoot)
                .WithFilter(AsiaQueryFilter.Api)
                .WithFilter(AsiaQueryFilter.Block)
                .WithParameter(AsiaQueryParameter.Hash.WithValue(blockHash.Hash));

            var response = ExecuteRequest(request).Result;

            var result = Deserialize<AsiaBlock>(response);

            return result;
        }
        public IAsiaTransaction GetTransaction(TransactionHash transactionHash)
        {
            var request = RestRequest.Get.WithRoot(ApiRoot)
                .WithFilter(AsiaQueryFilter.Api)
                .WithFilter(AsiaQueryFilter.Transaction)
                .WithParameter(AsiaQueryParameter.TransactionId.WithValue(transactionHash.Hash))
                .WithParameter(AsiaQueryParameter.Decrypt);

            var response = ExecuteRequest(request).Result;

            var result = Deserialize<AsiaTransaction>(response);

            return result;
        }
    }
}
