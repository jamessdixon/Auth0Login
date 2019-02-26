namespace Auth0Login.iOS

open System
open UIKit
open Auth0Login
open Xamarin.Forms
open Auth0.OidcClient

type AuthenticationService() =
    interface  IAuthenticationService with
        member this.Authenticate =            
            let options = new Auth0ClientOptions()
            options.Domain <- Support.authenticationConfig.Domain
            options.ClientId <- Support.authenticationConfig.ClientId
            options.Scope <- "openid profile"
            let client = new Auth0Client(options)
            let result = client.LoginAsync().Result
            match result.IsError with
            | true -> 
                AuthenticationResult.Bad {Error=result.Error}
            | false ->
                AuthenticationResult.Good {IdToken = result.IdentityToken; AccessToken=result.AccessToken; UserClaims=result.User.Claims;}

module AuthenticationService =
    [<assembly: Dependency(typeof<AuthenticationService>)>]
    do()
    