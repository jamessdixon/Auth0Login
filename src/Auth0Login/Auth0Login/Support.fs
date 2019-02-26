//this tutorial: https://auth0.com/blog/developing-mobile-apps-with-xamarin-forms-and-azure-functions/
namespace Auth0Login

open System.Security.Claims

type AuthenticationConfig = {Domain:string; ClientId:string; Audience:string}
type AzureConfig = {EchoUrl: string}

type GoodAuthenticationResult = {IdToken:string; AccessToken:string; UserClaims: Claim seq}
type BadAuthenticationResult = {Error: string}

type AuthenticationResult = 
| Good of GoodAuthenticationResult
| Bad of BadAuthenticationResult


type IAuthenticationService = 
    abstract member Authenticate : AuthenticationResult
    
module Support =
    let authenticationConfig = {Domain="dev-lf8igpbj.auth0.com"; ClientId="f7oEF-Oo0yU3NiMe06GZ6sAnr5bUzyeh"; 
                                Audience = "https://sameroom.azurewebsites.net/api/Echo"}


   