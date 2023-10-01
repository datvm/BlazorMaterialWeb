namespace BlazorMaterialWeb;

partial class MdDialog
{

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
    public EventCallback<MdDialogReturnCallbackArgs> OnOpen { get; set; }

    [Parameter]
    public EventCallback<MdDialogReturnCallbackArgs> OnOpened { get; set; }

    [Parameter]
    public EventCallback<MdDialogReturnCallbackArgs> OnClose { get; set; }

    [Parameter]
    public EventCallback<MdDialogReturnCallbackArgs> OnClosed { get; set; }

    [Parameter]
    public EventCallback<MdDialogReturnCallbackArgs> OnCancel { get; set; }

    Task OnDomOpen() => OnOpen.InvokeAsync(new(this));

    async Task OnDomOpened()
    {
        Open = true;
        await OpenChanged.InvokeAsync(true);
        await OnOpened.InvokeAsync(new(this));
    }

    Task OnDomClose(MdDialogReturnEventArgs e) =>
        OnClose.InvokeAsync(new(this, e.ReturnValue));

    async Task OnDomClosed(MdDialogReturnEventArgs e)
    {
        Open = false;
        await OpenChanged.InvokeAsync(false);
        await OnClosed.InvokeAsync(new(this, e.ReturnValue));
        closeTcs?.TrySetResult(e.ReturnValue);
    }

    Task OnDomCancelled() =>
        OnCancel.InvokeAsync(new(this));

    public async Task<string> GetReturnValueAsync() =>
        await Js.GetElementPropertyAsync<string>(el, "returnValue");

    public async Task OpenAsync() =>
        await InvokeMethodAsync("show");

    public async Task CloseAsync(string? returnValue = null) =>
        await InvokeMethodAsync("close", returnValue);

    public async Task<MdDialogReturnCallbackArgs> OpenForResultAsync()
    {
        var tcs = closeTcs = new TaskCompletionSource<string>();
        _ = OpenAsync(); // Don't need to wait for this

        return new(this, await tcs.Task);
    }

}

public enum MdDialogType
{
    Alert,
}

public record MdDialogReturnCallbackArgs(MdDialog Dialog, string? ReturnValue = null);