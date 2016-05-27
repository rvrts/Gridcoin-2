using System;
using System.Collections;
using System.Collections.Generic;

namespace Gridcoin.BlockExplorer
{
    public class Transaction : ITransaction
    {
        public IBlockExplorer BlockExplorer { get; set; }

        public TransactionHash Hash { get; set; }
        public ITransactionSender Sender { get; set; }
        public IEnumerable<ITransactionRecipient> Recipients { get; set; }

        public Transaction(IBlockExplorer blockExplorer)
        {
            if (blockExplorer == null) throw new ArgumentNullException(nameof(blockExplorer));

            BlockExplorer = blockExplorer;
        }
    }
}