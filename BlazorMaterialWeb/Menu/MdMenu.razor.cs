using Microsoft.JSInterop;

namespace BlazorMaterialWeb;

partial class MdMenu
{
    
    [Parameter]
    public string? Anchor { get; set; }

    [Parameter]
    public bool Fixed { get; set; }

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
    public int? ListTabIndex { get; set; }

    [Parameter]
    public MdMenuType Type { get; set; } = MdMenuType.Menu;

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
    public MdDefaultFocusState? DefaultFocus { get; set; }

    [Parameter]
    public EventCallback OnOpening { get; set; }
    
    [Parameter]
    public EventCallback OnOpened { get; set; }
    
    [Parameter]
    public EventCallback OnClosing { get; set; }

    [Parameter]
    public EventCallback OnClosed { get; set; }

    async Task OnMenuOpened()
    {
        Open = true;
        await OpenChanged.InvokeAsync(Open);
        await OnOpened.InvokeAsync();
    }

    async Task OnMenuClosed()
    {
        Open = false;
        await OpenChanged.InvokeAsync(Open);
        await OnClosed.InvokeAsync();
    }

    public async Task ShowAsync()
    {
        await Js.InvokeElementMethodAsync(el, "show");
    }

    public async Task CloseAsync()
    {
        await Js.InvokeElementMethodAsync(el, "close");
    }

    public async Task SetAnchorElementAsync(ElementReference anchorEl)
    {
        await Js.SetElementPropertyAsync(el, "anchorElement", anchorEl);
    }

}

/// <summary>
/// From menu.ts
/// </summary>
public enum MdMenuType
{
    Menu,
    MenuBar,
    Listbox,
    List,
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
/// From menu.ts
/// </summary>
public enum MdDefaultFocusState
{
    None,
    ListRoot,
    FirstItem,
    LastItem,
}