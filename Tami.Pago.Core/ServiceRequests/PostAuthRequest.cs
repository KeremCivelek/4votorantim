namespace Tami.Pago.Core.ServiceRequests
{
    public class PostAuthRequest : RequestBaseExtend
    {
        public override ValidationResult Validate()
        {
            if (Amount <= 0)
            {
                ValidationResult.Failed("Amount alanı 0'dan büyük olmalıdır.");
            }

            if (string.IsNullOrEmpty(OrderId))
            {
                ValidationResult.Failed("OrderId alanı boş veya null olamaz.");
            }

            return ValidationResult.Success;
        }
    }
}
