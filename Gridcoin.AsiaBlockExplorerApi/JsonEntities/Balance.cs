using System;

namespace Gridcoin.BlockExplorerApiClient.JsonEntities
{
    public class Balance : IBalance
    {
        public decimal Value { get; private set; }

        public Balance(Decimal value)
        {
            Value = value;
        }
    }
}