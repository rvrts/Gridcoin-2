using System;

namespace Gridcoin.BlockExplorer.Rest
{
    public interface IRestRequest
    {
        Uri Uri { get; }
        RequestType RequestType { get; }
        ContentType ContentType { get; }
    }
}