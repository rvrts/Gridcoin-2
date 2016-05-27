namespace Gridcoin.BlockExplorer
{
    public interface IBlockBuilder
    {
        IBlockBuilder WithIndex(BlockIndex blockIndex);
        IBlockBuilder WithHash(BlockHash blockHash);

        IBlock Build();
    }
}