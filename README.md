1、Register an app in AzureAD

2、Get ClientID、ClientSecret、TenantID

3、Grant the app the "CDN Profile Contributor" role for your current subscription

4、Get token through ClientID,ClientSecret,TenantID

5、Call the SDK to create CDN profile through token