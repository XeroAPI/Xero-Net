## MVC Example Application
This example MVC application can be configured to be used with Public or Partner Applications.
 
The Authorize callback URL is required in XeroApiHelper.cs. If you are working locally then 'http://localhost:XXXXX/Home/Authorize' is fine, replacing XXXXX with your port. Make sure you add the call back domain to your application settings on https://app.xero.com 'localhost' is fine. For more details see here: http://developer.xero.com/documentation/advanced-docs/oauth-callback-domains-explained/
 
Add your keys into XeroApiHelper.cs and point the signingCertificatePath etc to your certificates if appropriate. Following down that class there will be code for Partner and Public. Comment out the methods that you do not need.
 
Running the application will open a view with a blue 'Connect to Xero' button. Clicking this will take you to Xero to authenticate the application. Authentication is passed back to the Home/Authorize endpoint. 
 
The Organisation view contains a quick example of using the Api wrapper to GET the Organisation's name and display it.

###Common Issues
######Parser Error Message: Could not load type 'Xero.Api.Example.MVC.MvcApplication'.
This issue may occur depending on your IIS version and where it attempts to find your libraries. You can fix this by changing the output path of your project build to "bin" from "bin/release" or "bin/debug" or you can change the target build to x86. 

######Xero.Api.Infrastructure.OAuth.UnexpectedOauthResponseException

This is most likely due to sending the API request in TLS1.2 or lower. If this is not set on your machine/project then you will need to have .NET 4.5 installed and add into your code(e.g. Global.asax.cs)
`ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;`
A bitwise operator can be used here to use older TLS versions
