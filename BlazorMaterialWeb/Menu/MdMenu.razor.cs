namespace BlazorMaterialWeb;

/// <summary>
/// Menus display a list of choices on a temporary surface.
/// <a href="https://m3.material.io/components/menus/overview">Design</a>,
/// <a href="https://material-web.dev/components/menu/">Component</a>
/// </summary>
partial class MdMenu
{

    [Parameter]
    public string? Anchor { get; set; }

    [Parameter]
    public MdMenuPositioning? Positioning { get; set; }

    [Parameter]
    public bool Quick { get; set; }

    [Parameter]
    public bool HasOverflow { get; set; }

    [Parameter]
    public bool Open { get; set; }

    [Parameter]
    public EventCallback<bool> OpenChanged { get; set; }

    [Parameter]
    public int? XOffset { get; set; }

    [Parameter]
    public int? YOffset { get; set; }

    [Parameter]
    public int? TypeaheadDelay { get; set; }

    [Parameter]
    public MdMenuCorner? AnchorCorner { get; set; }

    [Parameter]
    public MdMenuCorner? MenuCorner { get; set; }

    [Parameter]
    public bool StayOpenOnOutsideClick { get; set; }

    [Parameter]
    public bool StayOpenOnFocusout { get; set; }

    [Parameter]
    public bool SkipRestoreFocus { get; set; }

    [Parameter]
    public MdMenuFocusState? DefaultFocus { get; set; }

    [Parameter]
    public EventCallback OnOpening { get; set; }

    [Parameter]
    public EventCallback OnOpened { get; set; }

    [Parameter]
    public EventCallback OnClosing { get; set; }

    [Parameter]
    public EventCallback OnClosed { get; set; }

    async Task OnOpenStatusChanged(bool open)
    {
        if (Open != open)
        {
            Open = open;
            await OpenChanged.InvokeAsync(open);
        }

        if (open)
        {
            await OnOpened.InvokeAsync();
        }
        else
        {
            await OnClosed.InvokeAsync();
        }
    }

    public async Task ShowAsync() =>
        await Js.InvokeElementMethodAsync(el, "show");

    public async Task CloseAsync() =>
        await Js.InvokeElementMethodAsync(el, "close");

    public async Task GetAnchorElementAsync() =>
        await Js.GetElementPropertyAsync<ElementReference>(el, "anchorElement");

    public async Task SetAnchorElementAsync(ElementReference anchorEl) =>
        await Js.SetElementPropertyAsync(el, "anchorElement", anchorEl);

    public async Task<IJSObjectReference> GetItemsAsync() =>
        await Js.GetElementPropertyAsync<IJSObjectReference>(el, "items");

    [return: NotNullIfNotNull(nameof(corner))]
    public static string? GetCornerName(MdMenuCorner? corner) => corner switch
    {
        null => null,
        MdMenuCorner.EndStart => "end-start",
        MdMenuCorner.EndEnd => "end-end",
        MdMenuCorner.StartStart => "start-start",
        MdMenuCorner.StartEnd => "start-end",
        _ => throw new NotImplementedException("Unknown value: " + corner),
    };

    [return: NotNullIfNotNull(nameof(focusState))]
    public static string? GetFocusStateName(MdMenuFocusState? focusState) => focusState switch
    {
        null => null,
        MdMenuFocusState.None => "none",
        MdMenuFocusState.ListRoot => "list-root",
        MdMenuFocusState.FirstItem => "first-item",
        MdMenuFocusState.LastItem => "last-item",
        _ => throw new NotImplementedException("Unknown value: " + focusState),
    };

}

/// <summary>
/// From menu.ts
/// </summary>
public enum MdMenuPositioning
{
    Absolute,
    Fixed,
}

/// <summary>
/// From surfacePositionController.ts
/// </summary>
public enum MdMenuCorner
{
    EndStart,
    EndEnd,
    StartStart,
    StartEnd,
}

/// <summary>
/// From shared.ts
/// </summary>
public enum MdMenuFocusState
{
    None,
    ListRoot,
    FirstItem,
    LastItem,
}