using System;
using System.Collections;
using System.Collections.Generic;

namespace Gridcoin.BlockExplorer
{
    public interface ITransactionBuilder
    {
        ITransactionBuilder WithHash(TransactionHash transactionHash);
        ITransactionBuilder WithSender(Action<ITransactionSenderBuilder> senderBuilding);
        ITransactionBuilder WithRecipients<TRecipient>(IEnumerable<TRecipient> recipients, Action<TRecipient, ITransactionRecipientBuilder> recipientBuilding);

        ITransaction Build();
    }

    public interface ITransactionRecipientBuilder
    {
        ITransactionRecipientBuilder WithValue(Decimal value);
        ITransactionRecipientBuilder WithAddress(GridcoinAddress address);

        ITransactionRecipient Build();
    }

    public interface ITransactionRecipient
    {
        Decimal Value { get; }
        GridcoinAddress Address { get; }
    }

    public interface ITransactionSenderBuilder
    {
        ITransactionSenderBuilder WithTransactionHash(TransactionHash transactionHash);

        ITransactionSender Build();
    }

    public interface ITransactionSender
    {
        TransactionHash TransactionHash { get; }
    }

    public class TransactionSender : ITransactionSender
    {
        public TransactionHash TransactionHash { get; set; }
    }
}