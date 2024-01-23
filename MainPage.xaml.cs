namespace iOSBorderLeak.Maui;

public partial class MainPage
{
    private WeakReference? _previousPageReference;
    
    public MainPage()
    {
        InitializeComponent();
    }

    private void PushSafePage(object? sender, EventArgs e)
    {
        var safePage = new SafePage();
        _previousPageReference = new WeakReference(safePage);
        Navigation.PushAsync(safePage);
        ForceGCButton.IsEnabled = true;
    }
    
    private void PushLeakyPage(object? sender, EventArgs e)
    {
        var leakyPage = new LeakyPage();
        _previousPageReference = new WeakReference(leakyPage);
        Navigation.PushAsync(leakyPage);
        ForceGCButton.IsEnabled = true;
    }
    
    private async void ForceGC(object? sender, EventArgs e)
    {
        if(_previousPageReference == null)
            throw new InvalidOperationException("No page was pushed yet.");
        
        ForceGCButton.IsEnabled = false;
        
        for (var i = 0; i < 20; i++)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            if (!_previousPageReference.IsAlive)
            {
                Label.Text = $"🗑️➡️🚚 previous page was collected after {i + 1} collections.";
                break;
            }
            
            Label.Text = $"💦 previous page is still alive after {i + 1} collections.";

            await Task.Delay(1000);
        }
        
        ForceGCButton.IsEnabled = true;
    }
}