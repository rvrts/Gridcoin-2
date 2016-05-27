namespace Gridcoin.BlockExplorer
{
    public interface IBlock
    {
        BlockIndex Index { get; }
        BlockHash Hash { get; }

        IBlock GetPreviousBlock();
        IBlock GetNextBlock();
    }
}