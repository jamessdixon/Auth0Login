namespace Auth0Login

open Xamarin.Forms
open IdentityModel.OidcClient

type LoginPage() as self =
    inherit ContentPage()

    let handleLoginResult (result:LoginResult) =
        match result.IsError with
        | true -> 
            AuthenticationResult.Bad {Error=result.Error}
        | false ->
            AuthenticationResult.Good {IdToken = result.IdentityToken; AccessToken=result.AccessToken; UserClaims=result.User.Claims;}

    let success (result:LoginResult) =
        let authResult = handleLoginResult result
        match authResult with 
        | AuthenticationResult.Good gar -> self.DisplayAlert("Success",gar.AccessToken,"OK") |> ignore
        | AuthenticationResult.Bad bar -> self.DisplayAlert("Failed",bar.Error,"OK") |> ignore

    let failure (ex:exn) = 
        self.DisplayAlert("Failed",ex.Message,"OK") |> ignore

    let clicked = 
        fun (ea) -> 
            let authenticationService = DependencyService.Get<IAuthenticationService>()
            let popForm = authenticationService.AuthenticateAsync ()
            Async.StartWithContinuations (popForm, success, failure, failure)
    do
        let logoImage = new Image()
        logoImage.Margin <- new Thickness(0.0,10.0,0.0,0.0)

        let mainPageLabel = new Label()
        mainPageLabel.Text <- "Welcome to Xamarin.Forms with Auth0!"
        mainPageLabel.HorizontalOptions <- LayoutOptions.Center
        mainPageLabel.VerticalOptions <- LayoutOptions.Center
        mainPageLabel.Margin <- new Thickness(0.0,10.0,0.0,0.0)

        let button = new Button()
        button.Text <- "Login"
        button.Margin <- new Thickness(0.0,10.0,0.0,0.0)
        button.Clicked.Add(clicked)
        
        let layout = new StackLayout()
        layout.Padding <- new Thickness(30.0)
        layout.Spacing <- 10.0
        layout.Children.Add(logoImage)
        layout.Children.Add(mainPageLabel)
        layout.Children.Add(button)
        self.Content <- layout
        ()

