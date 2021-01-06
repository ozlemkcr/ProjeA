using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class PaypalConfiguration
    {
        public readonly static string clientId;
        public readonly static string clientSecret;

        static PaypalConfiguration()
        {
            var config = getconfig();
            clientId = "AaNjxryyvIlsRxiXX6th0kdEniZGRLc89QQyxT-xqk4n-QzO-rIjrzyFExtSbw6uEIHph17TaKQIu2EF";
            clientSecret = "EKJzqx2PB6ysArbSOZT4hNdFzScygOnXb3T-7tSc241IYpF_zvpEEM6wMqwvMoY9eG5sBUJwkiWs4Q57";

        }

        private static Dictionary<string, string> getconfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }
        private static string GetAccessToken()
        {
            string accessToken = new OAuthTokenCredential(clientId,clientSecret, getconfig()).GetAccessToken();
            return accessToken;
        }
        public static APIContext GetAPIContext()
        {
            APIContext apicontext = new APIContext(GetAccessToken());
            apicontext.Config = getconfig();
            return apicontext;
        }
    }
}