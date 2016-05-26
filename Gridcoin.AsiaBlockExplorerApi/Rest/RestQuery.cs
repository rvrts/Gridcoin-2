using System;
using System.Collections.Generic;
using System.Linq;

namespace Gridcoin.BlockExplorerApiClient.Rest
{
    public interface IRestQuery
    {
        Uri Uri { get; }
    }
    public class RestQuery : IRestQuery
    {
        public Uri Uri => CreateUri();
        public Uri Root { get; private set; }
        public IList<IRestQueryFilter> Filters { get; private set; }
        public IList<IRestQueryParameter> Parameters { get; private set; }
        public Type ResultType { get; private set; }

        public RestQuery()
        {
            Filters = new List<IRestQueryFilter>();
            Parameters = new List<IRestQueryParameter>();
        }

        private Uri CreateUri()
        {
            String uriString = "";

            uriString += $"{Root}";
            if (Filters.Any())
                uriString = Filters.Aggregate(new Uri(uriString), (acc, elem) => elem.ApplyToUri(acc)).AbsoluteUri;
            //uriString += $"{String.Join("/", Filters)}";
            if (Parameters.Any())
                uriString = Parameters.Aggregate($"{uriString}?", (acc, elem) => $"{elem.ApplyToUri(new Uri(acc)).AbsoluteUri}&").TrimEnd(new [] {'&'});
                //uriString += $"?{String.Join("&", Parameters.Select(p => $"{Uri.EscapeUriString(p.Key)}={Uri.EscapeUriString(Convert.ToString(p.Value))}"))}";

            return new Uri(uriString);
        }

        public RestQuery WithRoot(Uri rootUri)
        {
            Root = rootUri;

            return this;
        }
        public RestQuery WithFilter(IRestQueryFilter filter)
        {
            var existingFilter = Filters.FirstOrDefault(one => one.Name == filter.Name);

            if (existingFilter != null)
                existingFilter.Value = filter.Value;
            else
                Filters.Add(filter);
           
            return this;
        }
        public RestQuery WithParameter(IRestQueryParameter parameter)
        {
            var existingParameter = Parameters.FirstOrDefault(one => one.Name == parameter.Name);

            if (existingParameter != null)
                existingParameter.Value = parameter.Value;
            else
                Parameters.Add(parameter);

            return this;
        }
    }
}
