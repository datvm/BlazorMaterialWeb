﻿namespace BlazorMaterialWeb.Demo.Shared;

sealed partial class PageNav : IDisposable
{

    (string Text, string Url)? activeUrl;

    void FindActiveItem()
    {
        var path = new Uri(Nav.Uri).LocalPath;
        activeUrl = NavUrls
            .FirstOrDefault(q => path.StartsWith(
                q.Url,
                StringComparison.OrdinalIgnoreCase));
    }

    protected override void OnInitialized() =>
        Nav.LocationChanged += Nav_LocationChanged;

    public void Dispose() =>
        Nav.LocationChanged -= Nav_LocationChanged;


    private void Nav_LocationChanged(object? sender, Microsoft.AspNetCore.Components.Routing.LocationChangedEventArgs e)
    {
        FindActiveItem();
    }

}