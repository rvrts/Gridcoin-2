using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gridcoin.BlockExplorer.Web.Asia.Rest;
using Gridcoin.BlockExplorer.Web.Asia.Rest.Entities;

namespace Gridcoin.BlockExplorer.Web.Asia
{
    public class AsiaBlockExplorer : BlockExplorer
    {
        public IAsiaBlockExplorerRestClient RestClient { get; private set; }

        public AsiaBlockExplorer(IAsiaBlockExplorerRestClient restClient)
        {
            if (restClient == null)
                throw new ArgumentNullException(nameof(restClient));

            RestClient = restClient;
        }

        protected override IBlockBuilder OnGetBlock(BlockIndex blockIndex, IBlockBuilder blockBuilder)
        {
            var blockHash = RestClient.GetBlockHash(blockIndex);

            return OnGetBlock(blockHash, blockBuilder);
        }

        protected override IBlockBuilder OnGetBlock(BlockHash blockHash, IBlockBuilder blockBuilder)
        {
            var restBlock = RestClient.GetBlock(blockHash);

            return blockBuilder
                .WithIndex(new BlockIndex(restBlock.Height))
                .WithHash(blockHash);
        }

        protected override ITransactionBuilder OnGetTransaction(TransactionHash transactionHash, ITransactionBuilder transactionBuilder)
        {
            var restTransaction = RestClient.GetTransaction(transactionHash);

            return transactionBuilder
                .WithHash(transactionHash)
                .WithSender(senderBuilder => senderBuilder
                    .WithTransactionHash(new TransactionHash(restTransaction.Senders.First().TransactionId)))
                .WithRecipients<AsiaTransactionRecipient>(restTransaction.Recipients, (recipient, recipientBuilder) => recipientBuilder
                    .WithValue(recipient.Value)
                    .WithAddress(new GridcoinAddress(recipient.Key.Addresses.First())));
        }
    }
}
