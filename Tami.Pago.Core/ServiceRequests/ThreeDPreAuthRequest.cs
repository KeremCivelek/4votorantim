namespace Tami.Pago.Core.ServiceRequests
{
    public class ThreeDPreAuthRequest : PreAuthRequest
    {
        /// <summary>
        /// İşlem sonucunun döneceği bağlantı adresidir.
        /// </summary>
        public string CallbackUrl { get; set; }
    }
}
