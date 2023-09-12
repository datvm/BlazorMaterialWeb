namespace BlazorMaterialWeb.Chips;

public abstract class BaseMdChip : DefaultMdComponent
{

    [Parameter]
    public bool Elevated { get; set; }

    [Parameter]
    public string? Label { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

}
