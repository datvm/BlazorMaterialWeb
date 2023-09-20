namespace BlazorMaterialWeb;

public class MdSelectOption : MdMenuItem
{

    [Parameter]
    public string? Value { get; set; }

    [Parameter]
    public bool Selected { get; set; }

    [Parameter]
    public EventCallback<bool> SelectedChanged { get; set; }

    async Task OnRequestSelectionAsync()
    {
        Selected = true;
        await SelectedChanged.InvokeAsync(true);
    }

    async Task OnRequestDeselectionAsync()
    {
        Selected = false;
        await SelectedChanged.InvokeAsync(false);
    }

    public override MdListItemRole Type
    {
        get => MdListItemRole.MenuItem;
        set => throw new InvalidOperationException();
    }

    protected override IEnumerable<KeyValuePair<string, object?>>? ProtectedAdditionalAttributes =>
        new KeyValuePair<string, object?>[]
        {
            new("value", Value),
            new("selected", Selected),
            new("onrequestselection", EventCallback.Factory.Create(this, OnRequestSelectionAsync)),
            new("onrequestdeselection", EventCallback.Factory.Create(this, OnRequestDeselectionAsync)),
        };

}
