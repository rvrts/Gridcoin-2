using System;
using System.Threading.Tasks;

namespace Gridcoin.BlockExplorer.Rest
{
    public interface IRestClient
    {
        IRestResponse Execute(IRestRequest request);
        Task<IRestResponse> ExecuteAsync(IRestRequest request);
    }

    public interface IRestResponse
    {
        IRestRequest Request { get; }
        Object Value { get; }
    }
}