using System;
using System.Threading.Tasks;

namespace Gridcoin.BlockExplorerApiClient.Rest
{
    public interface IRestClient
    {
        String ExecuteQuery(IRestQuery query);
        Task<String> ExecuteQueryAsync(IRestQuery query);

        byte[] GetResource(Uri uri);
        Task<byte[]> GetResourceAsync(Uri uri);
    }
}