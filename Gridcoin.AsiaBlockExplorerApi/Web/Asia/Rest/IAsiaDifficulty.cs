namespace Gridcoin.BlockExplorer.Web.Asia.Rest
{
    public interface IAsiaDifficulty
    {
        decimal ProofOfStake { get; set; }
        decimal ProofOfWork { get; set; }
        decimal SearchInterval { get; set; }
    }
}