using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gridcoin.BlockExplorer.Rest
{
    public class RestResponse : IRestResponse
    {
        public IRestRequest Request { get; }
        public Object Value { get; }

        public RestResponse(IRestRequest request, Object value)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            Request = request;
            Value = value;
        }
    }
}
