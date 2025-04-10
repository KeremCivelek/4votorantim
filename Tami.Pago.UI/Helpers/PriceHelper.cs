using Tami.Pago.Core.ServiceRequests;

namespace Tami.Pago.UI
{
    public static class PriceHelper
    {
        public static decimal GetTotalAmount(this RequestBasketBase basket)
        {
            if (basket != null && basket.BasketItems != null && basket.BasketItems.Count > 0)
            {
                return basket.BasketItems.Sum(m => m.TotalPrice);
            }

            return 0;
        }
    }
}
