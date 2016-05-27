using System;

namespace Gridcoin.BlockExplorer.Rest
{
    public class RestQueryParameter : IRestQueryParameter
    {
        public string Name { get; }
        public object Value { get; set; }

        protected RestQueryParameter(String name, Object value = null)
        {
            Name = name;
            Value = value;
        }

        public IRestQueryParameter WithValue(object value)
        {
            Value = value;

            return this;
        }

        public Uri ApplyToUri(Uri uri)
        {
            Uri result = null;

            String uriString = uri.AbsoluteUri;
            
            uriString += $"{Uri.EscapeUriString(Name)}={Uri.EscapeUriString(Convert.ToString(Value))}";

            result = new Uri(uriString);

            return result;
        }
    }
}
