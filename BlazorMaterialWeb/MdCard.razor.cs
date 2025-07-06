namespace BlazorMaterialWeb;

partial class MdCard
{

    [Parameter]
    public int ElevationLevel { get; set; } = 3;

    [Parameter]
    public string Class { get; set; } = "";

    [Parameter]
    public string? ContainerClass { get; set; }

}
