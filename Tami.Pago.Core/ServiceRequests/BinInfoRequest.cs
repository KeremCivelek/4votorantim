namespace Tami.Pago.Core.ServiceRequests
{
    public class BinInfoRequest : RequestBase
    {
        /// <summary>
        /// Detayları öğrenilmek istenen kart numarasının ilk 6 hanesi veya 8 hanesi gönderilmelidir.
        /// </summary>
        public int BinNumber { get; set; }
    }
}
