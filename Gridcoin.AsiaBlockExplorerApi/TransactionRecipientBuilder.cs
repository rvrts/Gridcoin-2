using System;

namespace Gridcoin.BlockExplorer
{
    public class TransactionRecipientBuilder : ITransactionRecipientBuilder
    {
        private Decimal m_Value;
        private GridcoinAddress m_Address;

        public ITransactionRecipientBuilder WithValue(decimal value)
        {
            m_Value = value;

            return this;
        }

        public ITransactionRecipientBuilder WithAddress(GridcoinAddress address)
        {
            m_Address = address;

            return this;
        }

        public ITransactionRecipient Build()
        {
            return new TransactionRecipient()
            {
                Value = m_Value,
                Address = m_Address,
            };
        }
    }
}