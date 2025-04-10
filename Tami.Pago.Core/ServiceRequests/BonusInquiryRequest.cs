namespace Tami.Pago.Core.ServiceRequests
{
    public class BonusInquiryRequest : RequestBase
    {
        /// <summary>
        /// Alıcıya ait ip adresi.
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// Üye işyerine ait mail bilgisi
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Kredi kartı numarası
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// Sorgulamanın yapılacağı kartın son kullanma tarihi ay bilgisi.
        /// </summary>
        public int ExpireMonth { get; set; }

        /// <summary>
        /// Sorgulamanın yapılacağı kartın son kullanma tarihi yıl bilgisi.
        /// </summary>
        public int ExpireYear { get; set; }

        /// <summary>
        /// Ödemenin alınacağı kartın güvenlik kodu bilgisi.
        /// </summary>
        public string Cvv { get; set; }

        /// <summary>
        /// Döviz Tipi
        /// </summary>
        public int CurrencyCode { get; set; }

        /// <summary>
        /// Tutar
        /// </summary>
        public int Amount { get; set; }
    }
}
