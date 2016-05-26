using System;
using System.Net.Http;
using System.Threading.Tasks;
using PortableRest;

namespace Gridcoin.BlockExplorerApiClient.Rest
{
    public class PortableRestClient : IRestClient
    {
        public String ExecuteQuery(IRestQuery query)
        {
            return ExecuteQueryAsync(query).Result;
        }
        public async Task<String> ExecuteQueryAsync(IRestQuery query)
        {
            var client = new RestClient();
            var request = new RestRequest(query.Uri.AbsoluteUri, HttpMethod.Get, ContentTypes.Json);
            //request.Headers.Add("X-Mashape-Key", query.ApiInfo.ApiKey);

            var result = await client.ExecuteAsync<String>(request);

            return result;
        }

        public byte[] GetResource(Uri uri)
        {
            return GetResourceAsync(uri).Result;
        }
        public async Task<byte[]> GetResourceAsync(Uri uri)
        {
            var client = new RestClient();
            var request = new RestRequest(uri.AbsoluteUri, HttpMethod.Get, ContentTypes.ByteArray);

            var result = await client.ExecuteAsync<byte[]>(request);

            return result;
        }
    }
}
