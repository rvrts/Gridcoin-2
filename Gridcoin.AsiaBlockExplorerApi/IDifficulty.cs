using System;

namespace Gridcoin.BlockExplorerApiClient
{
    public interface IDifficulty
    {
        Decimal ProofOfWork { get; }
        Decimal ProofOfStake { get; }
        Decimal SearchInterval { get; }
    }
}