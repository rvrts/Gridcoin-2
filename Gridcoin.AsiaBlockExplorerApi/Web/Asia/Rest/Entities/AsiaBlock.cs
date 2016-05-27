using System;
using Newtonsoft.Json;

namespace Gridcoin.BlockExplorer.Web.Asia.Rest.Entities
{
    public class AsiaBlock : IAsiaBlock
    {
        [JsonProperty("hash")]
        public String Hash { get; set; }
        [JsonProperty("confirmations")]
        public Int32 Confirmations { get; set; }
        [JsonProperty("size")]
        public Int64 Size { get; set; }
        [JsonProperty("height")]
        public Int64 Height { get; set; }
        [JsonProperty("version")]
        public Int32 Version { get; set; }
        [JsonProperty("merkleroot")]
        public String MerkleRoot { get; set; }
        [JsonProperty("mint")]
        public String Mint { get; set; }
        [JsonProperty("time")]
        public Int64 Time { get; set; }
        [JsonProperty("nonce")]
        public Int64 Nonce { get; set; }
        [JsonProperty("bits")]
        public String Bits { get; set; }
        [JsonProperty("difficulty")]
        public Decimal Difficulty { get; set; }
        [JsonProperty("blocktrust")]
        public String Blocktrust { get; set; }
        [JsonProperty("chaintrust")]
        public String Chaintrust { get; set; }
        [JsonProperty("previousblockhash")]
        public String PreviousBlockHash { get; set; }
        [JsonProperty("nextblockhash")]
        public String NextBlockHash { get; set; }
        [JsonProperty("flags")]
        public String Flags { get; set; }
        [JsonProperty("proofhash")]
        public String ProofHash { get; set; }
        [JsonProperty("entropybit")]
        public Int32 EntropyBit { get; set; }
        [JsonProperty("modifier")]
        public String Modifier { get; set; }
        [JsonProperty("modifierchecksum")]
        public String ModifierChecksum { get; set; }
        [JsonProperty("tx")]
        public String[] Transactions { get; set; }
        [JsonProperty("signature")]
        public String Signature { get; set; }
        [JsonProperty("CPID")]
        public String Cpid { get; set; }
        public Decimal Magnitude { get; set; }
        public String LastPaymentTime { get; set; }
        public Decimal ResearchSubsidy { get; set; }
        public Decimal ResearchAge { get; set; }
        public Decimal ResearchMagnitudeUnit { get; set; }
        public Decimal ResearchAverageMagnitude { get; set; }
        [JsonProperty("LastPORBlockHash")]
        public String LastPorBlockHash { get; set; }
        public Decimal Interest { get; set; }
        [JsonProperty("GRCAddress")]
        public String GrcAddress { get; set; }
    }
}