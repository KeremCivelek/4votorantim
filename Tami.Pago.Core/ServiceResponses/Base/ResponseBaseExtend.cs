namespace Tami.Pago.Core.ServiceResponses
{
    public class ResponseBaseExtend : ResponseBase
    {
        /// <summary>
        /// Sipariş numarası.
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// İşlem tutarı.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// İşlemin fraud kontrol sonucu OK / NOK
        /// </summary>
        public int FraudStatus { get; set; }
    }
}
