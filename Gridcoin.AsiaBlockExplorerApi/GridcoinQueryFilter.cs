using Gridcoin.BlockExplorerApiClient.Rest;

namespace Gridcoin.BlockExplorerApiClient
{
    public class GridcoinQueryFilter : RestQueryFilter
    {
        public GridcoinQueryFilter(string name, object value = null, bool applyBoth = false)
            : base(name, value, applyBoth)
        {
        }

        public static IRestQueryFilter Api => new GridcoinQueryFilter("api");
        public static IRestQueryFilter ExtendedApi => new GridcoinQueryFilter("ext");

        public static IRestQueryFilter Difficulty = new GridcoinQueryFilter("getdifficulty");
        public static IRestQueryFilter Balance = new GridcoinQueryFilter("getbalance", "<hash>", true);
        public static IRestQueryFilter Transaction = new GridcoinQueryFilter("getrawtransaction");
        public static IRestQueryFilter Block = new GridcoinQueryFilter("getblock");
    }
}