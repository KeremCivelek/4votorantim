namespace Tami.Pago.Core.ServiceResponses
{
    public class BonusInquiryResponse : ResponseBase
    {
        /// <summary>
        /// İşlem Onay durumunu belirlen alan
        /// </summary>
        public bool Approved { get; set; }

        /// <summary>
        /// Sipariş Numarası
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// Hata kodu
        /// </summary>
        public string ReturnCode { get; set; }

        /// <summary>
        /// Referans Numarası
        /// </summary>
        public string RetRefNum { get; set; }

        /// <summary>
        /// İşlem Tarihi
        /// </summary>
        public string ProvisionDate { get; set; }

        /// <summary>
        /// Puan Listesi
        /// </summary>
        public List<RewardList> RewardList { get; set; }

    }

    public class RewardList
    {
        /// <summary>
        /// Kart Tipi
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Kullanılabilir Puan Tutarı
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Kullanılabilir Puan Tipi
        /// </summary>
        public string Name { get; set; }
    }
}
