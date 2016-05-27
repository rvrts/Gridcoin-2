using Gridcoin.BlockExplorer.Rest;

namespace Gridcoin.BlockExplorer.Web.Asia.Rest
{
    public class AsiaQueryFilter : RestQueryFilter
    {
        public AsiaQueryFilter(string name, object value = null, bool applyBoth = false)
            : base(name, value, applyBoth)
        {
        }

        public static IRestQueryFilter Api => new AsiaQueryFilter("api");
        public static IRestQueryFilter ExtendedApi => new AsiaQueryFilter("ext");

        public static IRestQueryFilter Difficulty = new AsiaQueryFilter("getdifficulty");
        public static IRestQueryFilter Balance = new AsiaQueryFilter("getbalance", "<hash>", true);
        public static IRestQueryFilter Transaction = new AsiaQueryFilter("getrawtransaction");
        public static IRestQueryFilter Block = new AsiaQueryFilter("getblock");
        public static IRestQueryFilter BlockHash = new AsiaQueryFilter("getblockhash");
    }
}