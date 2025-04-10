namespace Tami.Pago.Core.ServiceRequests
{
    public class InstallmentInfoRequest : RequestBase
    {
        /// <summary>
        /// Detayları öğrenilmek istenen kart numarasının ilk 6 hanesi veya 8 hanesi gönderilmelidir.
        /// </summary>
        public int BinNumber { get; set; }
    }
}
