namespace BlazorMaterialWeb;

/// <summary>
/// Tabs organize content across different screens and views.
/// <a href="https://m3.material.io/components/tabs/overview">Design</a>,
/// <a href="https://material-web.dev/components/tabs">Component</a>
/// </summary>
partial class MdTab
{
    public const string IconSlot = "icon";

    [Parameter]
    public MdTabType? Type { get; set; }

    [CascadingParameter(Name = "TabType")]
    public MdTabType? GroupType { get; set; }

    /// <summary>
    /// Primary Tab only
    /// </summary>
    [Parameter]
    public bool InlineIcon { get; set; }

    [Parameter]
    public bool Active { get; set; }

    [Parameter]
    public EventCallback<bool> ActiveChanged { get; set; }

    [Parameter]
    public bool HasIcon { get; set; }

    [Parameter]
    public bool IconOnly { get; set; }

    async Task OnTabActivated(MdCheckedEventArgs e)
    {
        Active = e.Checked;
        await ActiveChanged.InvokeAsync(Active);
    }

    string TagName => (Type ?? GroupType ?? MdTabType.Primary) switch
    {
        MdTabType.Primary => "md-primary-tab",
        MdTabType.Secondary => "md-secondary-tab",
        _ => throw new NotImplementedException("Unknown type: " + Type),
    };

}
