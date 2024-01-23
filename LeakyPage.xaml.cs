namespace iOSBorderLeak.Maui;

public partial class LeakyPage
{
    public LeakyPage()
    {
        InitializeComponent();
    }

    private async void GoBack(object? sender, EventArgs e)
    {
        await Navigation.PopAsync();
        
        // No effect
        //Border.Handler?.DisconnectHandler();
        //Handler?.DisconnectHandler();
    }
}