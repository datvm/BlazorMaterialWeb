namespace BlazorMaterialWeb;

partial class MdDialog
{

    ElementReference el;
    TaskCompletionSource<string>? closeTcs;

    [Parameter]
    public RenderFragment? Headline { get; set; }

    [Parameter]
    public RenderFragment? Actions { get; set; }

    [Parameter]
    public bool Open { get; set; }

    [Parameter]
    public EventCallback<bool> OpenChanged { get; set; }

    [Parameter]
    public MdDialogType? Type { get; set; }

    [Parameter]
    public EventCallback OnOpen { get; set; }

    [Parameter]
    public EventCallback OnOpened { get; set; }

    [Parameter]
    public EventCallback OnClose { get; set; }

    [Parameter]
    public EventCallback<string> OnClosed { get; set; }

    [Parameter]
    public EventCallback OnCancel { get; set; }

    async Task OnDomOpened()
    {
        Open = true;
        await OpenChanged.InvokeAsync(true);
        await OnOpened.InvokeAsync();
    }

    async Task OnDomClosed(DialogReturnEventArgs e)
    {
        Open = false;
        await OpenChanged.InvokeAsync(false);
        await OnClosed.InvokeAsync(e.ReturnValue);
        closeTcs?.TrySetResult(e.ReturnValue);
    }

    public async Task<string> GetReturnValueAsync() =>
        await Js.GetElementPropertyAsync<string>(el, "returnValue");

    public async Task OpenAsync()
    {
        await Js.InvokeElementMethodAsync(el, "show");
    }

    public async Task CloseAsync()
    {
        await Js.InvokeElementMethodAsync(el, "close");
    }

    public async Task<string> OpenForResultAsync()
    {
        var tcs = closeTcs = new TaskCompletionSource<string>();
        _ = OpenAsync(); // Don't need to wait for this
        
        return await closeTcs.Task;
    }

}

public enum MdDialogType
{
    Alert,
}