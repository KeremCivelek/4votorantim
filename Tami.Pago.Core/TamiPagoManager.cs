using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Tami.Pago.Core.ServiceRequests;
using Tami.Pago.Core.ServiceResponses;

namespace Tami.Pago.Core
{
    public class TamiPagoManager
    {
        private readonly TamiHttpClient _httpClient;
        private readonly long _merchantId;
        private readonly long _terminalId;
        private readonly string _secretKey;
        private readonly string _fixedKidValue;
        private readonly string _fixedKValue;
        public TamiPagoManager(string baseAddress, long merchantId, long terminalId, string secretKey, string fixedKidValue, string fixedKValue)
        {
            _merchantId = merchantId;
            _terminalId = terminalId;
            _secretKey = secretKey;
            _fixedKidValue = fixedKidValue;
            _fixedKValue = fixedKValue;
            _httpClient = new TamiHttpClient(baseAddress, merchantId, terminalId, secretKey);
        }

        public TamiPagoManager(TamiHttpClient httpClient, string fixedKidValue, string fixedKValue)
        {
            _httpClient = httpClient;
            _merchantId = httpClient.MerchantId;
            _terminalId = httpClient.TerminalId;
            _secretKey = httpClient.SecretKey;
            _fixedKidValue = fixedKidValue;
            _fixedKValue = fixedKValue;
        }

        public async Task<AuthResponse> AuthAsync(AuthRequest request)
        {
            return await PostRequestAsync<AuthRequest, AuthResponse>("payment/auth", request);
        }

        public async Task<AuthWithBonusResponse> AuthWithBonusAsync(AuthWithBonusRequest request)
        {
            return await PostRequestAsync<AuthWithBonusRequest, AuthWithBonusResponse>("payment/auth", request);
        }

        public async Task<PreAuthResponse> PreAuthAsync(PreAuthRequest request)
        {
            return await PostRequestAsync<PreAuthRequest, PreAuthResponse>("payment/pre-auth", request);
        }

        public async Task<PostAuthResponse> PostAuthAsync(PostAuthRequest request)
        {
            return await PostRequestAsync<PostAuthRequest, PostAuthResponse>("payment/post-auth", request);
        }

        public async Task<ReverseResponse> ReverseAsync(ReverseRequest request)
        {
            return await PostRequestAsync<ReverseRequest, ReverseResponse>("payment/reverse", request);
        }

        public async Task<Complete3dAuthResponse> Complete3DAuthAsync(Complete3dAuthRequest request)
        {
            return await PostRequestAsync<Complete3dAuthRequest, Complete3dAuthResponse>("payment/complete-3ds", request);
        }

        public async Task<ThreeDAuthResponse> Auth3DAsync(ThreeDAuthRequest request)
        {
            return await PostRequestAsync<ThreeDAuthRequest, ThreeDAuthResponse>("payment/auth", request);
        }

        public async Task<ThreeDPreAuthResponse> PreAuth3DAsync(ThreeDPreAuthRequest request)
        {
            return await PostRequestAsync<ThreeDPreAuthRequest, ThreeDPreAuthResponse>("payment/pre-auth", request);
        }

        public async Task<QueryResponse> QueryAsync(QueryRequest request)
        {
            return await PostRequestAsync<QueryRequest, QueryResponse>("payment/query", request);
        }

        public async Task<InstallmentInfoResponse> InstallmentInfoAsync(InstallmentInfoRequest request)
        {
            return await PostRequestAsync<InstallmentInfoRequest, InstallmentInfoResponse>("installment/installment-info", request);
        }

        public async Task<BinInfoResponse> BINInfoAsync(BinInfoRequest request)
        {
            return await PostRequestAsync<BinInfoRequest, BinInfoResponse>("installment/bin-info", request);
        }

        public async Task<BonusInquiryResponse> BonusInquiryAsync(BonusInquiryRequest request)
        {
            return await PostRequestAsync<BonusInquiryRequest, BonusInquiryResponse>("vas/bonusQuery", request);
        }

        private async Task<Y> PostRequestAsync<T, Y>(string path, T request)
            where T : RequestBase
            where Y : ResponseBase
        {
            var requestValidation = request.Validate();

            if (requestValidation.Succeeded)
            {
                string requestObject = JsonConvert.SerializeObject(request, new JsonSerializerSettings() { Converters = { new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fff" } }, NullValueHandling = NullValueHandling.Ignore, ContractResolver = new CamelCasePropertyNamesContractResolver() });
                
                request.SecurityHash = CryptoHelper.GenerateJWKSignature(_merchantId, _terminalId, _secretKey, requestObject, _fixedKidValue, _fixedKValue);

                return await _httpClient.PostAsync<Y>(path, request);
            }
            throw new Exception($"İstek validasyon hatası: {string.Join(",", requestValidation.Errors)}");
        }
    }
}
