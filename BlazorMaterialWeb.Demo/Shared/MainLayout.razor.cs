namespace BlazorMaterialWeb.Demo.Shared;

sealed partial class MainLayout : IDisposable
{

    bool menuCollapsed;
    (string Text, string Url)? activeUrl;

    static readonly (string Text, string Url)[] NavUrls =
    {
        ("Buttons", "/button"),
        ("Checkbox", "/checkbox"),
        ("Icon Buttons", "/icon-buttons"),
        ("Menus", "/menu"),
        ("Progress", "/progress"),
        ("Ripple", "/ripple"),
        ("Sliders", "/slider"),
    };

    protected override void OnInitialized() => 
        Nav.LocationChanged += Nav_LocationChanged;

    private void Nav_LocationChanged(object? sender, Microsoft.AspNetCore.Components.Routing.LocationChangedEventArgs e)
    {
        FindActiveItem();
    }

    void FindActiveItem()
    {
        var path = new Uri(Nav.Uri).LocalPath;
        activeUrl = NavUrls
            .FirstOrDefault(q => path.StartsWith(
                q.Url,
                StringComparison.OrdinalIgnoreCase));
    }

    public void Dispose() => 
        Nav.LocationChanged -= Nav_LocationChanged;
}
