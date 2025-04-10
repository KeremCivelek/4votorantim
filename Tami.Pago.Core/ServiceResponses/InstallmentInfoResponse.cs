namespace Tami.Pago.Core.ServiceResponses
{
    public class InstallmentInfoResponse : ResponseBase
    {
        /// <summary>
        /// Bankanın adıdır.
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// Bankanın EFT kodudur.
        /// </summary>
        public string BankId { get; set; }

        /// <summary>
        /// Kart tipidir. 
        /// Debit / Credit
        /// </summary>
        public string CardType { get; set; }

        /// <summary>
        /// Kart organizasyon bilgisidir.
        /// VISA / MASTERCARD / TROY / AMEX
        /// </summary>
        public string CardOrg { get; set; }

        /// <summary>
        /// Kartın kurumsal kart olup olmadığı bilgisidir.
        /// Evet:true
        /// Hayır:false
        /// </summary>
        public bool Commercial { get; set; }

        /// <summary>
        /// Kartın ödül grubudur.
        /// Bonus, Axess, Chip, World vb.
        /// </summary>
        public string RewardType { get; set; }

        /// <summary>
        /// Üye işyeri yetkisine bakarak işlemin 3d ile yapılma zorunluluğu belirtilir.
        /// true ise işlem 3dsiz gönderildiğinde hata alınacaktır.
        /// </summary>
        public bool Force3ds { get; set; }

        /// <summary>
        /// Üye işyeri yetkisine bakarak işlemin cvv ile yapılma zorunluluğu belirtilir.
        /// true ise işlem cvvsiz gönderildiğinde hata alınacaktır.
        /// </summary>
        public bool ForceCvc { get; set; }

        /// <summary>
        /// Üye işyeri yetkisine bakarak işlemin taksit ile yapılabilirliğini belirtir.
        /// false ise işlem taksitli gönderildiğinde hata alınacaktır.
        /// </summary>
        public bool IsInstallment { get; set; }
    }
}
