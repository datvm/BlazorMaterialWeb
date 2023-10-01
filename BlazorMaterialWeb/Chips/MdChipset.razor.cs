namespace BlazorMaterialWeb;

/// <summary>
/// Chips help people enter information, make selections, filter content, or trigger actions
/// <a href="https://m3.material.io/components/chips/overview">Design</a>,
/// <a href="https://material-web.dev/components/chip/">Component</a>
/// </summary>
partial class MdChipset
{

    public async Task<IJSObjectReference> GetChipsAsync() =>
        await GetPropertyAsync<IJSObjectReference>("chips");

}
