namespace Auth0Login

open Xamarin.Forms

type App() =
    inherit Application()

    do
        base.MainPage <- NavigationPage(LoginPage())
