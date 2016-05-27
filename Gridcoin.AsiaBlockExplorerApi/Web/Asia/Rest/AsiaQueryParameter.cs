using Gridcoin.BlockExplorer.Rest;

namespace Gridcoin.BlockExplorer.Web.Asia.Rest
{
    public class AsiaQueryParameter : RestQueryParameter
    {
        public AsiaQueryParameter(string name, object value = null) 
            : base(name, value)
        {
        }

        public static IRestQueryParameter TransactionId { get { return new AsiaQueryParameter("txid");} }
        public static IRestQueryParameter Decrypt { get { return new AsiaQueryParameter("decrypt", 1); } }
        public static IRestQueryParameter Hash { get { return new AsiaQueryParameter("hash"); } }
        public static IRestQueryParameter Index { get { return new AsiaQueryParameter("index", 0); } }
    }
}
