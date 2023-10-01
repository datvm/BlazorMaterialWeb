using BlazorMaterialWeb.Common;

namespace BlazorMaterialWeb.Chips;

public abstract class BaseMdChip : DefaultMdComponent
{
    public const string IconSlot = "icon";

    [Parameter]
    public bool Elevated { get; set; }

    [Parameter]
    public string? Label { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

}
