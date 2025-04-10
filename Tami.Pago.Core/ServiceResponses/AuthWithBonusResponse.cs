namespace Tami.Pago.Core.ServiceResponses
{
    public class AuthWithBonusResponse : AuthResponse
    {
        /// <summary>
        /// Kullanılan Puan Tutarı
        /// </summary>
        public string RewardAmount { get; set; }
    }
}
