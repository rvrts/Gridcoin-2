using System;

namespace Gridcoin.BlockExplorerApiClient.Rest
{
    public interface IRestQueryParameter
    {
        String Name { get; }
        Object Value { get; set; }

        IRestQueryParameter WithValue(Object value);
        Uri ApplyToUri(Uri uri);
    }
}