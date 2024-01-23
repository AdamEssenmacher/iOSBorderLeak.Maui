namespace iOSBorderLeak.Maui;

public partial class SafePage
{
    public SafePage()
    {
        InitializeComponent();
    }

    private void GoBack(object? sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}