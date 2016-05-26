using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gridcoin.BlockExplorerApiClient.Rest;

namespace Gridcoin.BlockExplorerApiClient
{
    public class GridcoinQueryParameter : RestQueryParameter
    {
        public GridcoinQueryParameter(string name, object value = null) 
            : base(name, value)
        {
        }

        public static IRestQueryParameter TransactionId { get { return new GridcoinQueryParameter("txid");} }
        public static IRestQueryParameter Decrypt { get { return new GridcoinQueryParameter("decrypt", 1); } }
        public static IRestQueryParameter Hash { get { return new GridcoinQueryParameter("hash"); } }
    }
}
