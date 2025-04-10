using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Tami.Pago.Core.ServiceResponses
{
    public class Complete3dAuthResponse : ResponseBaseExtend
    {
        /// <summary>
        /// İşlem para birimi.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyTypes Currency { get; set; }

        /// <summary>
        /// İşlem taksit sayısı.
        /// </summary>
        public int InstallmentCount { get; set; }

        /// <summary>
        /// İşlem yapılan kart bilgileri.
        /// </summary>
        public ResponseCardBase Card { get; set; }

    }
}
