using System;
using System.Collections.Generic;
using System.Linq;

namespace Gridcoin.BlockExplorer.Rest
{
    public class RestRequest : IRestRequest
    {
        public Uri Uri => CreateUri();
        public RequestType RequestType { get; private set; }
        public ContentType ContentType { get; private set; }
        public Uri Root { get; private set; }
        public IList<IRestQueryFilter> Filters { get; private set; }
        public IList<IRestQueryParameter> Parameters { get; private set; }
        public Type ResultType { get; private set; }

        public RestRequest(RequestType requestType, ContentType contentType = ContentType.Json)
        {
            RequestType = requestType;
            ContentType = contentType;

            Filters = new List<IRestQueryFilter>();
            Parameters = new List<IRestQueryParameter>();
        }

        private Uri CreateUri()
        {
            String uriString = "";

            uriString += $"{Root}";
            if (Filters.Any())
                uriString = Filters.Aggregate(new Uri(uriString), (acc, elem) => elem.ApplyToUri(acc)).AbsoluteUri;
            if (Parameters.Any())
                uriString = Parameters.Aggregate($"{uriString}?", (acc, elem) => $"{elem.ApplyToUri(new Uri(acc)).AbsoluteUri}&").TrimEnd(new [] {'&'});

            return new Uri(uriString);
        }

        public RestRequest WithContentAs(ContentType contentType)
        {
            ContentType = contentType;

            return this;
        }
        public RestRequest WithRoot(Uri rootUri)
        {
            Root = rootUri;

            return this;
        }
        public RestRequest WithFilter(IRestQueryFilter filter)
        {
            var existingFilter = Filters.FirstOrDefault(one => one.Name == filter.Name);

            if (existingFilter != null)
                existingFilter.Value = filter.Value;
            else
                Filters.Add(filter);
           
            return this;
        }
        public RestRequest WithParameter(IRestQueryParameter parameter)
        {
            var existingParameter = Parameters.FirstOrDefault(one => one.Name == parameter.Name);

            if (existingParameter != null)
                existingParameter.Value = parameter.Value;
            else
                Parameters.Add(parameter);

            return this;
        }

        public static RestRequest Post
        {
            get { return new RestRequest(RequestType.Post); }
        }
        public static RestRequest Get
        {
            get { return new RestRequest(RequestType.Get); }
        }
        public static RestRequest Put
        {
            get { return new RestRequest(RequestType.Put); }
        }
        public static RestRequest Patch
        {
            get { return new RestRequest(RequestType.Patch); }
        }
        public static RestRequest Delete
        {
            get { return new RestRequest(RequestType.Delete); }
        }
    }
}
