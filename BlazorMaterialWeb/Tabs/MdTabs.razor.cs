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

    ElementReference el;

    public async Task<int> GetActiveTabIndexAsync()
    {
        return await Js.GetElementPropertyAsync<int>(el, "activeTabIndex");
    }

    public async Task SetActiveTabIndexAsync(int index)
    {
        await Js.SetElementPropertyAsync(el, "activeTabIndex", index);
    }

    public async Task<ElementReference> GetActiveTabAsync()
    {
        return await Js.GetElementPropertyAsync<ElementReference>(el, "activeTab");
    }

    public async Task SetActiveTabAsync(ElementReference tab)
    {
        await Js.SetElementPropertyAsync(el, "activeTab", tab);
    }

}
