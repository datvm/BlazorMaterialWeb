namespace BlazorMaterialWeb.Chips;

public abstract partial class BaseMdChip
{
    public const string IconSlot = "icon";

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public bool AlwaysFocusable { get; set; }

    [Parameter]
    public string? Label { get; set; }

    protected abstract string TagName { get; }

}
