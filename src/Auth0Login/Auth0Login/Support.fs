
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
    abstract member AuthenticateAsync : unit -> Async<IdentityModel.OidcClient.LoginResult>
    
module Support =
    let authenticationConfig = {Domain="XXXXXX"; ClientId="YYYYY"; Audience = "ZZZZZZ"}



                               


   