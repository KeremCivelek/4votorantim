namespace Tami.Pago.Core.ServiceResponses
{
    public class ResponseBase
    {
        public string RequestRawJson { get; set; }
        public string ResponseRawJson { get; set; }

        /// <summary>
        /// true dönmesi durumunda satış işlemi başarılı, false dönmesi durumunda hatalınmıştır.
        /// Hata detayı error code ve error message alanlarında paylaşılacaktır.
        /// </summary>
        public string Success { get; set; }

        /// <summary>
        /// İşlem tarihi.
        /// </summary>

        public DateTime SystemTime { get; set; }

        /// <summary>
        /// Transaction numarası.
        /// </summary>
        public string CorrelationId { get; set; }

        /// <summary>
        /// İşlemin sonucunun doğru kaynaktan geldiğini belirlemek için kullanılacak değerdir. Dokumanda nasıl hesaplanması gerektiği belirtilmiştir.
        /// </summary>
        public string SecurityHash { get; set; }

        /// <summary>
        /// Hata kodu.
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Hata mesajı.
        /// </summary>
        public string ErrorMessage { get; set; }

        public bool IsSuccess => Success == "true";
    }
}
