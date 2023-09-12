namespace BlazorMaterialWeb;

partial class MdCheckbox
{

    [Parameter]
    public bool Checked { get; set; }

    [Parameter]
    public EventCallback<bool> CheckedChanged { get; set; }

    [Parameter]
    public bool Indeterminate { get; set; }

    [Parameter]
    public EventCallback<bool> IndeterminateChanged { get; set; }

    async Task OnCheckedChanged(CheckboxChangeEventArgs e)
    {
        var intermediateChanged = e.Indeterminate != Indeterminate;

        Checked = e.Checked;
        Indeterminate = e.Indeterminate;

        await CheckedChanged.InvokeAsync(Checked);
        if (intermediateChanged)
        {
            await IndeterminateChanged.InvokeAsync(Indeterminate);
        }
    }

}
