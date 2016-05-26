using System;

namespace Gridcoin.BlockExplorerApiClient
{
    public interface IBalance
    {
        Decimal Value { get; }
    }
}