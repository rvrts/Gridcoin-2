using System;

namespace Gridcoin.BlockExplorer.Web.Asia.Rest.Entities
{
    public class AsiaBalance : IAsiaBalance
    {
        public decimal Value { get; private set; }

        public AsiaBalance(Decimal value)
        {
            Value = value;
        }
    }
}