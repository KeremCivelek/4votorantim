using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Tami.Pago.Core.ServiceResponses
{
    public class QueryResponse : ResponseBase
    {
        /// <summary>
        /// İşlemin oluşturulma tarihidir.
        /// </summary>

        public DateTime OrderDate { get; set; }

        /// <summary>
        /// İşlemin döviz kodudur.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyTypes Currency { get; set; }


        /// <summary>
        /// İşlemin taksit sayısıdır.
        /// </summary>
        public int InstallmentCount { get; set; }

        /// <summary>
        /// isTransactionDetail true gönderilirse ilgili sipariş bilgisinin başından geçen tüm işlem verilerini göstermektedir.
        /// </summary>
        public List<ResponseTransactionBase> Transactions { get; set; }
    }
}
