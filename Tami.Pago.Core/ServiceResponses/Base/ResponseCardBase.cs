namespace Tami.Pago.Core.ServiceResponses
{
    public class ResponseCardBase
    {
        /// <summary>
        /// İşlem yapılan kartın ilk 8 hanesi.
        /// </summary>
        public string BinNumber { get; set; }

        /// <summary>
        /// İşlem yapılan kartın maskeli kart numarası bilgisi.
        /// </summary>
        public string MaskedNumber { get; set; }

        /// <summary>
        /// İşlem yapılan kartın markası.
        /// </summary>
        public string CardBrand { get; set; }

        /// <summary>
        /// İşlem yapılan kartın organizasyon bilgisi.
        /// </summary>
        public string CardOrganization { get; set; }

        /// <summary>
        /// İşlem yapılan kartın tipi.
        /// </summary>
        public string CardType { get; set; }
    }
}
