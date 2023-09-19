namespace BlazorMaterialWeb.Demo.Shared;

partial class CodeBlock
{

    [Parameter, EditorRequired]
    public string? Code { get; set; } = null!;

    [Parameter]
    public string Language { get; set; } = "cshtml-razor";

    async Task CopyAsync()
    {
        if (Code is null) { return; }

        await Js.InvokeVoidAsync("navigator.clipboard.writeText", Code);
    }

}
