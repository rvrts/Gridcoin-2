using System;
using Newtonsoft.Json;

namespace Gridcoin.BlockExplorerApiClient
{
    public interface IBlockExplorerApi
    {
        String Name { get; }
        Uri ApiRoot { get; }

        IDifficulty GetCurrentDifficulty();
        IBalance GetBalance(GridcoinAddress address);
        IBlock GetBlock(BlockHash blockHash);
        ITransaction GetTransaction(GridcoinTransactionId transactionId);
    }

    public class BlockHash
    {
        public string Hash { get; private set; }

        public BlockHash(String hash)
        {
            Hash = hash;
        }
    }

    public interface IBlock
    {
        String Hash { get; }
        Int64 Height { get; }
        String[] Transactions { get; }
    }

    public interface ITransaction
    {
        String TransactionId { get; }
    }

    public class Transaction : ITransaction
    {
        [JsonProperty("txid")]
        public String TransactionId { get; set; }
        [JsonProperty("version")]
        public Int32 Version { get; set; }
        [JsonProperty("time")]
        public Int64 Time { get; set; }
        [JsonProperty("blockhash")]
        public String BlockHash { get; set; }

        [JsonProperty("vout")]
        public TransactionRecipient[] Recipients { get; set; }
    }

    public class TransactionRecipient
    {
        [JsonProperty("value")]
        public Decimal Value { get; set; }

        [JsonProperty("scriptPubKey")]
        public ScriptPubKey Key { get; set; }
    }

    public class ScriptPubKey
    {
        [JsonProperty("addresses")]
        public String[] Addresses { get; set; }
    }
}
