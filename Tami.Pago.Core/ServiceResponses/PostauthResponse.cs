using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Tami.Pago.Core.ServiceResponses
{
    public class PostAuthResponse : ResponseBaseExtend
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyTypes Currency { get; set; }
    }
}
