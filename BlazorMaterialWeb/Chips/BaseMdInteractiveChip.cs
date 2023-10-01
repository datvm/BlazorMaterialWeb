namespace BlazorMaterialWeb.Chips;

public abstract class BaseMdInteractiveChip : BaseMdChip
{

    [Parameter]
    public bool Selected { get; set; }
    [Parameter]
    public EventCallback<bool> SelectedChanged { get; set; }

    [Parameter]
    public EventCallback<MdCheckedEventArgs> OnSelected { get; set; }

    [Parameter]
    public EventCallback OnRemove { get; set; }

    async Task OnChipSelected(MdCheckedEventArgs e)
    {
        if (e.Checked != Selected)
        {
            Selected = e.Checked;
            await SelectedChanged.InvokeAsync(Selected);
        }

        await OnSelected.InvokeAsync(e);
    }

    protected override IEnumerable<KeyValuePair<string, object?>> ProtectedAdditionalAttributes =>
        new KeyValuePair<string, object?>[]
        {
            new("selected", Selected),

            new("onchipselected", EventCallback.Factory.Create<MdCheckedEventArgs>(this, OnChipSelected)),
            new("onchipremove", EventCallback.Factory.Create(this, OnRemove)),
        };

}
