namespace Tami.Pago.Core.ServiceResponses
{
    public class ResponseTransactionBase
    {
        /// <summary>
        /// İlgili kaydın tutarı.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// İlgili kaydın işlem türü.
        /// </summary>
        public string TransactionType { get; set; }

        /// <summary>
        /// İlgili kaydın başarı durumu.
        /// </summary>
        public string TransactionStatus { get; set; }

        /// <summary>
        /// İlgili kaydın tarihi.
        /// </summary>
        public string TransactionDate { get; set; }

        /// <summary>
        /// İşlem iade/iptal edilirken bir reason alanı bilgisi girildiğinde bu alanda gösterilir.
        /// </summary>
        public string Reason { get; set; }
    }
}
