namespace Gridcoin.BlockExplorer.Web.Asia.Rest
{
    public interface IAsiaBlock
    {
        string Bits { get; set; }
        string Blocktrust { get; set; }
        string Chaintrust { get; set; }
        int Confirmations { get; set; }
        string Cpid { get; set; }
        decimal Difficulty { get; set; }
        int EntropyBit { get; set; }
        string Flags { get; set; }
        string GrcAddress { get; set; }
        string Hash { get; set; }
        long Height { get; set; }
        decimal Interest { get; set; }
        string LastPaymentTime { get; set; }
        string LastPorBlockHash { get; set; }
        decimal Magnitude { get; set; }
        string MerkleRoot { get; set; }
        string Mint { get; set; }
        string Modifier { get; set; }
        string ModifierChecksum { get; set; }
        string NextBlockHash { get; set; }
        long Nonce { get; set; }
        string PreviousBlockHash { get; set; }
        string ProofHash { get; set; }
        decimal ResearchAge { get; set; }
        decimal ResearchAverageMagnitude { get; set; }
        decimal ResearchMagnitudeUnit { get; set; }
        decimal ResearchSubsidy { get; set; }
        string Signature { get; set; }
        long Size { get; set; }
        long Time { get; set; }
        string[] Transactions { get; set; }
        int Version { get; set; }
    }
}