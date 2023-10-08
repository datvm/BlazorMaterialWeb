namespace BlazorMaterialWeb;

/// <summary>
/// Tabs organize content across different screens and views.
/// <a href="https://m3.material.io/components/tabs/overview">Design</a>,
/// <a href="https://material-web.dev/components/tabs">Component</a>
/// </summary>
partial class MdTabs
{

    [Parameter]
    public bool AutoActivate { get; set; }

    [Parameter]
    public MdTabType TabType { get; set; }

    [Parameter]
    public EventCallback<MdTabChangeEventArgs> OnTabChanged { get; set; }

    public async Task<IJSObjectReference> GetTabsAsync() =>
        await GetPropertyAsync<IJSObjectReference>("tabs");

    public async Task<int> GetActiveTabIndexAsync() =>
        await GetPropertyAsync<int>("activeTabIndex");

    public async Task SetActiveTabIndexAsync(int index) =>
        await SetPropertyAsync("activeTabIndex", index);

    public async Task<ElementReference> GetActiveTabAsync() =>
        await GetPropertyAsync<ElementReference>("activeTab");

    public async Task SetActiveTabAsync(ElementReference tab) => 
        await SetPropertyAsync("activeTab", tab);

    public async Task ScrollToTabAsync(ElementReference tab) =>
        await InvokeMethodAsync("scrollToTab", tab);

}
