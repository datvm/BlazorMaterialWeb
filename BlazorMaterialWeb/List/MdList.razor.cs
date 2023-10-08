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

    public async Task<IJSObjectReference> GetItemsAsync() =>
        await GetPropertyAsync<IJSObjectReference>("items");

    public async Task<IJSObjectReference> ActivateNextItemAsync() =>
        await InvokeMethodAsync<IJSObjectReference>("activateNextItem");

    public async Task<IJSObjectReference> ActivatePreviousItemAsync() =>
        await InvokeMethodAsync<IJSObjectReference>("activatePreviousItem");

}
