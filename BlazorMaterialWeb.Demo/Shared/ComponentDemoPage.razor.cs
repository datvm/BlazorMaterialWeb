namespace BlazorMaterialWeb.Demo.Shared;

partial class ComponentDemoPage
{

    public static readonly Uri GithubUserContentBaseUri = new("https://raw.githubusercontent.com/");
    public static readonly Uri GithubBlobUri = new("https://github.com/");

    public const string WebComponentPathTemplate = "/material-components/material-web/tree/main/{0}";
    public const string BlazorComponentPathTemplate = "/datvm/BlazorMaterialWeb/blob/master/BlazorMaterialWeb/{0}";
    public const string DemoPagePathTemplate = "/datvm/BlazorMaterialWeb/blob/master/BlazorMaterialWeb.Demo/Pages/{0}.razor";
    public const string DemoPageRawPathTemplate = "/datvm/BlazorMaterialWeb/master/BlazorMaterialWeb.Demo/Pages/{0}.razor";

    [Parameter, EditorRequired]
    public string Name { get; set; } = null!;

    [Parameter, EditorRequired]
    public RenderFragment Description { get; set; } = null!;

    [Parameter, EditorRequired]
    public string DesignUrl { get; set; } = null!;

    [Parameter, EditorRequired]
    public string ComponentUrl { get; set; } = null!;

    [Parameter, EditorRequired]
    public string ComponentSourcePath { get; set; } = null!;

    [Parameter, EditorRequired]
    public string BlazorComponentSourcePath { get; set; } = null!;

    [Parameter, EditorRequired]
    public string BlazorDemoSourceName { get; set; } = null!;

    [Parameter, EditorRequired]
    public RenderFragment ComponentDemo { get; set; } = null!;

    [Parameter]
    public RenderFragment? Tweaks { get; set; }

    string? currCodeUrl;
    string? demoCode;

    protected override async Task OnParametersSetAsync()
    {
        var codeUrl = DemoCodeContentRawUri.AbsoluteUri;
        if (currCodeUrl == codeUrl) { return; }

        try
        {
            // Set URL first to prevent code keep loading everytime
            // state change
            currCodeUrl = codeUrl;

            demoCode = await Http.GetStringAsync(codeUrl);            
        }
        catch
        {
            demoCode = "Error loading demo code";
        }
        
    }

    public Uri DemoCodeContentUri => new(
        GithubBlobUri,
        string.Format(DemoPagePathTemplate, BlazorDemoSourceName));

    public Uri DemoCodeContentRawUri => new(
        GithubUserContentBaseUri,
        string.Format(DemoPageRawPathTemplate, BlazorDemoSourceName));

    public Uri WebComponentSourceUri => new(
        GithubBlobUri,
        string.Format(WebComponentPathTemplate, ComponentSourcePath));

    public Uri BlazorComponentSourceUri => new(
               GithubBlobUri,
               string.Format(BlazorComponentPathTemplate, BlazorComponentSourcePath));

}
