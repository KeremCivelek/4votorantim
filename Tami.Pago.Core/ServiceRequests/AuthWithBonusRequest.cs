namespace Tami.Pago.Core.ServiceRequests
{
    public class AuthWithBonusRequest : AuthRequest
    {
        /// <summary>
        /// Puan kullanımının olup olmadığını belirten alandır.
        /// </summary>
        public bool IsRewardToBeUsed { get; set; }
        public RewardToBeUsed RewardToBeUsed { get; set; }
    }

    public class RewardToBeUsed
    {
        public List<RewardItem> List { get; set; }
    }

    public class RewardItem
    {
        /// <summary>
        /// Kullanımak istenen Puan tipidir. Alabileceği değerler (BNS, TotalPoint, Chippara, ParaPuan, KullanPuan)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Kullanılmak istenen Puan tutarıdır. Küsurat ayracı nokta (.) ile yapılmalıdır.
        /// </summary>
        public decimal Amount { get; set; }
    }
}
