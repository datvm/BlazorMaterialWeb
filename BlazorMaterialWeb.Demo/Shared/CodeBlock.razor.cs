namespace BlazorMaterialWeb.Demo.Shared;

partial class CodeBlock
{

    [Parameter, EditorRequired]
    public string? Code { get; set; } = null!;

    [Parameter]
    public string Language { get; set; } = "cshtml-razor";

}
