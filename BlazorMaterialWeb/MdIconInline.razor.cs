namespace BlazorMaterialWeb;

partial class MdIconInline
{

    public const string IconSharp = "material-symbols-sharp";
    public const string IconOutlined = "material-symbols-outlined";
    public const string IconRound = "material-symbols-round";

    [Parameter]
    public string IconClass { get; set; } = IconOutlined;

    [Parameter]
    public string Class { get; set; } = "";

}
