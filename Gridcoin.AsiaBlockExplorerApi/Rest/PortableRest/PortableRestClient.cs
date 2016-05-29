using System;
using System.Net.Http;
using System.Threading.Tasks;
using PortableRest;

namespace Gridcoin.BlockExplorer.Rest.PortableRest
{
    public class PortableRestClient : IRestClient
    {
        public IRestResponse Execute(IRestRequest request)
        {
            return ExecuteAsync(request).Result;
        }
        public async Task<IRestResponse> ExecuteAsync(IRestRequest request)
        {
            var client = new RestClient();
            var uri = request.Uri.AbsoluteUri;
            var requestType = MapRequestType(request.RequestType);
            var contentType = MapContentType(request.ContentType);

            var portableRequest = new global::PortableRest.RestRequest(uri, requestType, contentType);

            Object result = null;

            if(request.ContentType == ContentType.Json || request.ContentType == ContentType.Xml)
                result = await client.ExecuteAsync<String>(portableRequest);
            else if (request.ContentType == ContentType.Raw)
                result = await client.ExecuteAsync<byte[]>(portableRequest);

            return new RestResponse(request, result);
        }

        private HttpMethod MapRequestType(RequestType requestType)
        {
            if (requestType == RequestType.Get)
                return HttpMethod.Get;
            else
                throw new NotSupportedException();
        }
        private ContentTypes MapContentType(ContentType contentType)
        {
            if (contentType == ContentType.Json)
                return ContentTypes.Json;
            else if (contentType == ContentType.Xml)
                return ContentTypes.Xml;
            else if (contentType == ContentType.Raw)
                return ContentTypes.ByteArray;
            else
                throw new NotSupportedException();
        }
    }
}
