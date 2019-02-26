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
    
type IAzureFunctionDataService = 
    abstract member GetGreeting : authenticationResult:AuthenticationResult -> string


module Support =
    let authenticationConfig = {Domain="sameroom.auth0.com"; ClientId="swOmR3UQJm26QlTVjtssAzQijfKUTaLV"; 
                                Audience = "https://sameroom.azurewebsites.net/api/Echo"}
    let azureConfig = {EchoUrl = "https://sameroom.azurewebsites.net/api/Echo"}


   