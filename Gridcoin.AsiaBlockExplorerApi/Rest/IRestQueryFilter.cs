using System;

namespace Gridcoin.BlockExplorerApiClient.Rest
{
    public interface IRestQueryFilter
    {
        String Name { get; }
        Object Value { get; set; }
        Boolean ApplyBoth { get; }

        IRestQueryFilter WithValue(Object value);
        Uri ApplyToUri(Uri uri);
    }
}