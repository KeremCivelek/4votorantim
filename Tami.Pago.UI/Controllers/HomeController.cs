using Microsoft.AspNetCore.Mvc;
using Tami.Pago.Core;
using Tami.Pago.Core.ServiceRequests;

namespace Tami.Pago.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly TamiPagoManager _pagoManager;

        public HomeController()
        {
            _pagoManager = new TamiPagoManager(StaticContents.ServiceEndpoint, StaticContents.MerchantId, StaticContents.TerminalId, StaticContents.SecretKey, StaticContents.FixedKidValue, StaticContents.FixedKValue);
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Auth()
        {
            AuthRequest request = new()
            {
                Amount = (int)StaticContents.GetExampleBasket().GetTotalAmount(),
                BillingAddress = StaticContents.BillingAddress,
                ShippingAddress = StaticContents.ShippingAddress,
                Basket = StaticContents.GetExampleBasket(),
                Buyer = StaticContents.GetExampleBuyer(),
                Card = StaticContents.GetExampleCard(),
                OrderId = Guid.NewGuid().ToString("N"),
                PaymentChannel = PaymentChannels.WEB
            };
            var response = await _pagoManager.AuthAsync(request);
            return Json(response);
        }

        public async Task<IActionResult> AuthWithBonus()
        {
            AuthWithBonusRequest request = new()
            {
                Amount = (int)StaticContents.GetExampleBasket().GetTotalAmount(),
                BillingAddress = StaticContents.BillingAddress,
                ShippingAddress = StaticContents.ShippingAddress,
                Basket = StaticContents.GetExampleBasket(),
                Buyer = StaticContents.GetExampleBuyer(),
                Card = StaticContents.GetExampleCard(),
                OrderId = Guid.NewGuid().ToString("N"),
                PaymentChannel = PaymentChannels.WEB,
                IsRewardToBeUsed = true,
                RewardToBeUsed = new RewardToBeUsed() { List = new List<RewardItem> { new RewardItem() { Type = "BNS", Amount = 10 } } }
            };

            var response = await _pagoManager.AuthWithBonusAsync(request);
            return Json(response);
        }

        public async Task<IActionResult> PreAuth()
        {
            PreAuthRequest request = new()
            {
                Amount = (int)StaticContents.GetExampleBasket().GetTotalAmount(),
                BillingAddress = StaticContents.BillingAddress,
                ShippingAddress = StaticContents.ShippingAddress,
                Basket = StaticContents.GetExampleBasket(),
                Buyer = StaticContents.GetExampleBuyer(),
                Card = StaticContents.GetExampleCard(),
                OrderId = Guid.NewGuid().ToString("N"),
                PaymentChannel = PaymentChannels.WEB
            };
            var response = await _pagoManager.PreAuthAsync(request);
            return Json(response);
        }

        public async Task<IActionResult> PostAuth()
        {
            var orderId = Guid.NewGuid().ToString("N");
            PreAuthRequest request = new()
            {
                Amount = (int)StaticContents.GetExampleBasket().GetTotalAmount(),
                BillingAddress = StaticContents.BillingAddress,
                ShippingAddress = StaticContents.ShippingAddress,
                Basket = StaticContents.GetExampleBasket(),
                Buyer = StaticContents.GetExampleBuyer(),
                Card = StaticContents.GetExampleCard(),
                OrderId = orderId,
                PaymentChannel = PaymentChannels.WEB
            };
            var response = await _pagoManager.PreAuthAsync(request);
            //return Json(response);

            PostAuthRequest postAuthRequest = new()
            {
                Amount = 40,
                OrderId = orderId,
            };
            var postAuthResponse = await _pagoManager.PostAuthAsync(postAuthRequest);
            return Json(postAuthResponse);
        }

        public async Task<IActionResult> Reverse()
        {
            var orderId = Guid.NewGuid().ToString("N");

            AuthRequest request = new()
            {
                Amount = (int)StaticContents.GetExampleBasket().GetTotalAmount(),
                BillingAddress = StaticContents.BillingAddress,
                ShippingAddress = StaticContents.ShippingAddress,
                Basket = StaticContents.GetExampleBasket(),
                Buyer = StaticContents.GetExampleBuyer(),
                Card = StaticContents.GetExampleCard(),
                OrderId = orderId,
                PaymentChannel = PaymentChannels.WEB
            };
            var authResponse = await _pagoManager.AuthAsync(request);

            ReverseRequest reverseRequest = new()
            {
                Amount = 10,
                OrderId = orderId,
            };
            var reverseResponse = await _pagoManager.ReverseAsync(reverseRequest);
            return Json(reverseResponse);
        }

        public async Task<IActionResult> Auth3D()
        {
            ThreeDAuthRequest request = new()
            {
                Amount = (int)StaticContents.GetExampleBasket().GetTotalAmount(),
                BillingAddress = StaticContents.BillingAddress,
                ShippingAddress = StaticContents.ShippingAddress,
                Basket = StaticContents.GetExampleBasket(),
                Buyer = StaticContents.GetExampleBuyer(),
                Card = StaticContents.GetExampleCard(),
                OrderId = Guid.NewGuid().ToString("N"),
                PaymentChannel = PaymentChannels.WEB,
                CallbackUrl = "https://localhost:7229/ThreeDResponse"
            };
            var response = await _pagoManager.Auth3DAsync(request);
            return Json(response);
        }

        public async Task<IActionResult> PreAuth3D()
        {
            ThreeDPreAuthRequest request = new()
            {
                Amount = (int)StaticContents.GetExampleBasket().GetTotalAmount(),
                BillingAddress = StaticContents.BillingAddress,
                ShippingAddress = StaticContents.ShippingAddress,
                Basket = StaticContents.GetExampleBasket(),
                Buyer = StaticContents.GetExampleBuyer(),
                Card = StaticContents.GetExampleCard(),
                OrderId = Guid.NewGuid().ToString("N"),
                PaymentChannel = PaymentChannels.WEB,
                CallbackUrl = "https://localhost:7229/ThreeDResponse"
            };
            var response = await _pagoManager.PreAuth3DAsync(request);
            return Json(response);
        }

        public async Task<IActionResult> AuthComplete3D(string orderId)
        {
            Complete3dAuthRequest complete3DRequest = new()
            {
                OrderId = orderId
            };
            var response = await _pagoManager.Complete3DAuthAsync(complete3DRequest);
            return Json(response);
        }

        public async Task<IActionResult> Query(string orderId, bool isTransactionDetail)
        {
            QueryRequest request = new();
            request.OrderId = orderId;
            request.IsTransactionDetail = isTransactionDetail;

            var response = await _pagoManager.QueryAsync(request);
            return Json(response);
        }

        public async Task<IActionResult> InstallmentInfo(int binNumber)
        {
            InstallmentInfoRequest request = new();
            request.BinNumber = binNumber;
            var response = await _pagoManager.InstallmentInfoAsync(request);
            return Json(response);
        }

        public async Task<IActionResult> BinInfo(int binNumber)
        {
            BinInfoRequest request = new();
            request.BinNumber = binNumber;
            var response = await _pagoManager.BINInfoAsync(request);
            return Json(response);
        }

        public async Task<IActionResult> BonusInquiry()
        {
            BonusInquiryRequest request = new()
            {
                IpAddress = "1.1.111.111",
                EmailAddress = "cem@cem.com",
                CardNumber = "4546711234567894",
                ExpireMonth = 12,
                ExpireYear = 26,
                Cvv = "",
                CurrencyCode = 949,
                Amount = 10
            };
            var response = await _pagoManager.BonusInquiryAsync(request);
            return Json(response);
        }

        public IActionResult ThreeDResponse()
        {
            Response.Body = Request.Body;
            return Ok();
        }
    }
}
