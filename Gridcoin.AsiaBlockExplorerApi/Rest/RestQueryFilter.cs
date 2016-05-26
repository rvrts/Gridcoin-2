using System;

namespace Gridcoin.BlockExplorerApiClient.Rest
{
    public class RestQueryFilter : IRestQueryFilter
    {
        public String Name { get; private set; }
        public Object Value { get; set; }
        public Boolean ApplyBoth { get; private set; }

        protected RestQueryFilter(String name, Object value = null, Boolean applyBoth = false)
        {
            Name = name;
            Value = value;
            ApplyBoth = applyBoth;
        }

        public IRestQueryFilter WithValue(Object value)
        {
            Value = value;

            return this;
        }

        public Uri ApplyToUri(Uri uri)
        {
            Uri result = null;

            String uriString = uri.AbsoluteUri;

            if (Value == null || ApplyBoth)
                uriString = $"{uriString}/{Name}";
            if (Value != null)
                uriString = $"{uriString}/{Value.ToString()}";

            result = new Uri(uriString);

            return result;
        }

        public static IRestQueryFilter Cards => new RestQueryFilter("cards");
        public static IRestQueryFilter CardBacks => new RestQueryFilter("cardback");
        public static IRestQueryFilter GameInfo => new RestQueryFilter("info");

        public static IRestQueryFilter CardId => new RestQueryFilter("card id", "0");
        public static IRestQueryFilter CardClass => new RestQueryFilter("card class", "0");
    }
}
