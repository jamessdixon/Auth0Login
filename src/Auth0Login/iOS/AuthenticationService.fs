namespace Auth0Login.iOS

open System
open UIKit
open Auth0Login
open Xamarin.Forms
open Auth0.OidcClient

type LoginParameters = { audience : string }

type AuthenticationService() =
    interface  IAuthenticationService with
        member this.AuthenticateAsync () =            
            let options = new Auth0ClientOptions()
            options.Domain <- Support.authenticationConfig.Domain
            options.ClientId <- Support.authenticationConfig.ClientId
            options.Scope <- "openid profile"
            let client = new Auth0Client(options)
            client.LoginAsync({ audience = Support.authenticationConfig.Audience }) |> Async.AwaitTask

module AuthenticationService =
    [<assembly: Dependency(typeof<AuthenticationService>)>]
    do()
    