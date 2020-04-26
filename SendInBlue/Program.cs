using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;
using System;

namespace SendInBlue
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure API key authorization: api-key
            Configuration.Default.ApiKey.Add("api-key", "");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("api-key", "Bearer");
            // Configure API key authorization: partner-key
            Configuration.Default.ApiKey.Add("partner-key", "");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("partner-key", "Bearer");

            var apiInstance = new AccountApi();
            var emailCampaignsApi = new EmailCampaignsApi();

            try
            {
                // Get your account informations, plans and credits details
                GetAccount result = apiInstance.GetAccount();


                //emailCampaignsApi.se();

                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception when calling AccountApi.GetAccount: " + e.Message);
            }
        }
    }
}
