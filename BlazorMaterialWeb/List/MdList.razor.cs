namespace BlazorMaterialWeb;

/// <summary>
/// Lists are continuous, vertical indexes of text and images.
/// <a href="https://m3.material.io/components/lists/overview">Design</a>,
/// <a href="https://material-web.dev/components/list/">Component</a>
/// </summary>
partial class MdList
{

    [Parameter]
    public MdListItemType? Type { get; set; }

    public async Task<IEnumerable<IJSObjectReference>> GetItemsAsync() =>
        await Js.GetElementPropertyAsync<IEnumerable<IJSObjectReference>>(
            el, "items");

    public async Task ActivateNextItemAsync() =>
        await Js.InvokeElementMethodAsync(el, "activateNextItem");

    public async Task ActivatePreviousItemAsync() =>
        await Js.InvokeElementMethodAsync(el, "activatePreviousItem");

}
