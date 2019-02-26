namespace Auth0Login

open Xamarin.Forms

type LoginPage() as self =
    inherit ContentPage()

    let clicked = 
        fun (ea) -> 
            let authenticationService = DependencyService.Get<IAuthenticationService>()
            let result = authenticationService.Authenticate
            self.DisplayAlert("Pressed","Details Here","OK") |> ignore

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

