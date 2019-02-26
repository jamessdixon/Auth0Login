namespace Auth0Login

open Xamarin.Forms

type MainPage() as self =
    inherit ContentPage()

    do
        let userImage = new Image()
        userImage.Margin <- new Thickness(0.0,20.0,0.0,0.0)
        userImage.HeightRequest <- 240.0
        userImage.WidthRequest <- 240.0

        let greetingLabel = new Label()
        greetingLabel.Text <- "Welcome to Xamarin.Forms with Auth0!"
        greetingLabel.HorizontalOptions <- LayoutOptions.Center
        greetingLabel.VerticalOptions <- LayoutOptions.CenterAndExpand
        greetingLabel.FontAttributes <- FontAttributes.Bold
        greetingLabel.Margin <- new Thickness(0.0,10.0,0.0,0.0)

        let layout = new StackLayout()
        layout.Padding <- new Thickness(30.0)
        layout.Spacing <- 10.0
        layout.HorizontalOptions <- LayoutOptions.Center
        layout.Children.Add(userImage)
        layout.Children.Add(greetingLabel)
        self.Content <- layout
        ()



