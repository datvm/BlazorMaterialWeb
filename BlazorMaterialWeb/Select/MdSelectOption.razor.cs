namespace BlazorMaterialWeb;

public class MdSelectOption
{
    public const string HeadlineSlot = "headline";
    public const string OverlineSlot = "overline";
    public const string SupportingTextSlot = "supporting-text";
    public const string TrailingSupportingTextSlot = "trailing-supporting-text";

    public const string StartSlot = "start";
    public const string EndSlot = "end";
}

/// <summary>
/// Select menus display a list of choices on temporary surfaces and display the currently selected menu item above the menu.
/// <a href="https://material-web.dev/components/select/">Component</a>
/// </summary>
partial class MdSelectOption<TValue>
{

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public bool Selected { get; set; }

    [Parameter]
    public EventCallback<bool> SelectedChanged { get; set; }

    [Parameter]
    public TValue? Value { get; set; }

    [Parameter]
    public string? TypeaheadText { get; set; }

    [Parameter]
    public string? DisplayText { get; set; }

    [Parameter]
    public EventCallback OnCloseMenu { get; set; }

    [Parameter]
    public EventCallback OnRequestSelection { get; set; }

    [Parameter]
    public EventCallback OnRequestDeselection { get; set; }

    async Task OnSelectedChanged(bool selected)
    {
        if (Selected == selected) { return; }

        Selected = selected;
        await SelectedChanged.InvokeAsync(selected);

        await (selected ?
                OnRequestSelection :
                OnRequestDeselection)
            .InvokeAsync();
    }

}

