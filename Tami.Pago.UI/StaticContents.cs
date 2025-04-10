using Tami.Pago.Core.ServiceRequests;

namespace Tami.Pago.UI
{
    public static class StaticContents
    {
        public const string ServiceEndpoint = "https://sandbox-paymentapi.tami.com.tr";
        public const long MerchantId = 77006950L;
        public const long TerminalId = 84006953L;
        public const string SecretKey = "0edad05a-7ea7-40f1-a80c-d600121ca51b";
        public const string FixedKidValue = "00ff6ea8-3511-4d04-946c-ba569208306f";
        public const string FixedKValue = "87919a8f-957b-427b-ae12-167622ab52b5";

        public static RequestAddressBase ShippingAddress = new() 
        {
            Address = "Deneme adresi",
            City = "İstanbul",
            CompanyName = "Deneme Firması",
            ContactName = "Oğuzhan Okur",
            Country = "Türkiye",
            District = "Maltepe",
            PhoneNumber = "07505555555",
            ZipCode = "34846"
        };

        public static RequestAddressBase BillingAddress = new()
        {
            Address = "Deneme adresi",
            City = "İstanbul",
            CompanyName = "Deneme Firması",
            ContactName = "Oğuzhan Okur",
            Country = "Türkiye",
            District = "Maltepe",
            PhoneNumber = "07505555555",
            ZipCode = "34846"
        };

        public static RequestBasketBase GetExampleBasket()
        {
            var basket = new RequestBasketBase() { BasketId = Guid.NewGuid().ToString("N"), BasketItems = new List<RequestBasketItemBase>() };
            basket.BasketItems.Add(new RequestBasketItemBase() { Category = "Oyuncak", SubCategory = "Çocuk Oyunu", ItemType = "PHYSICAL", ItemId = "4388002", Name = "Lego", NumberOfProducts = 10, TotalPrice = 30, UnitPrice = 3 });
            basket.BasketItems.Add(new RequestBasketItemBase() { Category = "Oyuncak", SubCategory = "Alt Oyuncak", ItemType = "PHYSICAL", ItemId = "5647389393", Name = "Piyano", NumberOfProducts = 5, TotalPrice = 385, UnitPrice = 77 });
            return basket;
        }

        public static RequestBuyerBase GetExampleBuyer()
        {
            return new RequestBuyerBase()
            {
                EmailAddress = "destek@garantibbva.com.tr",
                IpAddress = "127.0.0.1",
                RegistrationAddress = "Maltepe",
                BuyerId = Guid.NewGuid().ToString("N"),
                City = "İstanbul",
                Country = "Türkiye",
                IdentityNumber = 11111111111,
                LastLoginDate = DateTime.Now,
                Name = "Oğuzhan",
                SurName = "Okur",
                PhoneNumber = "07325555555",
                RegistrationDate = DateTime.Now.AddDays(-10),
                ZipCode = "34846"
            };
        }

        public static RequestCardBase GetExampleCard()
        {
            return new RequestCardBase()
            {
                Cvv = "",
                ExpireMonth = 4,
                ExpireYear = 2026,
                Number = "4824910501747014",
                HolderName =  "Mesut Sarıtaş"
            };
        }
    }
}
