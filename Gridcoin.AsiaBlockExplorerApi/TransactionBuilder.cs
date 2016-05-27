using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Serialization;

namespace Gridcoin.BlockExplorer
{
    public class TransactionBuilder : ITransactionBuilder
    {
        public IBlockExplorer BlockExplorer { get; private set; }
        private TransactionHash m_Hash;
        private ITransactionSenderBuilder m_SenderBuilder;
        private List<ITransactionRecipientBuilder> m_RecipientBuilders; 

        public TransactionBuilder(IBlockExplorer blockExplorer)
        {
            if (blockExplorer == null) throw new ArgumentNullException(nameof(blockExplorer));

            BlockExplorer = blockExplorer;
        }

        public ITransactionBuilder WithHash(TransactionHash transactionHash)
        {
            m_Hash = transactionHash;

            return this;
        }
        public ITransactionBuilder WithSender(Action<ITransactionSenderBuilder> senderBuilding)
        {
            m_SenderBuilder = new TransactionSenderBuilder();

            senderBuilding(m_SenderBuilder);

            return this;
        }
        public ITransactionBuilder WithRecipients<TRecipient>(IEnumerable<TRecipient> recipients, Action<TRecipient, ITransactionRecipientBuilder> recipientBuilding)
        {
            m_RecipientBuilders = recipients.Select(recipient =>
            {
                var builder = new TransactionRecipientBuilder();
                recipientBuilding(recipient, builder);

                return (ITransactionRecipientBuilder)builder;
            }).ToList();

            return this;
        }

        public ITransaction Build()
        {
            return new Transaction(BlockExplorer)
            {
                Hash = m_Hash,
                Sender = m_SenderBuilder.Build(),
                Recipients = m_RecipientBuilders.Select(one => one.Build()),
            };
        }
    }
}