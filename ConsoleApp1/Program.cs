
using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;

namespace ConsoleApp1
{
    class Program
    {
        //Tenant app constants
        private const string clientID = "ClientID";
        private const string clientSecret = "ClientSecret"; //Only for service principals
        private const string authority = "https://login.chinacloudapi.cn/TenantID";

        //Application constants
        private const string subscriptionId = "SubID";
        private const string profileName = "profileName";
        private const string resourceGroupName = "resourceGroupName";
        private const string resourceLocation = "chinanorth";


        static void Main(string[] args)
        {
            //Get a token
            AuthenticationResult authResult = GetAccessToken();

            // Create CDN client
            CdnManagementClient cdn = new CdnManagementClient(new Uri("https://management.chinacloudapi.cn"), new TokenCredentials(authResult.AccessToken))
            { SubscriptionId = subscriptionId };

            CreateCdnProfile(cdn);

            Console.ReadLine();
        }
       
        private static AuthenticationResult GetAccessToken()
        {
            AuthenticationContext authContext = new AuthenticationContext(authority);
            ClientCredential credential = new ClientCredential(clientID, clientSecret);
            AuthenticationResult authResult =
                authContext.AcquireTokenAsync("https://management.chinacloudapi.cn/", credential).Result;

            return authResult;
        }
        private static void CreateCdnProfile(CdnManagementClient cdn)
        {
           
            Profile profile1 = new Profile(resourceLocation,new Sku(SkuName.StandardChinaCdn));
            cdn.Profiles.Create(resourceGroupName, profileName, profile1);
            
        }

    }
}
