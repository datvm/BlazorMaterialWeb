namespace BlazorMaterialWeb.Common;

public class DefaultInputComponent : DefaultJsComponent
{

    public async Task<bool> CheckValidityAsync() =>
        await InvokeMethodAsync<bool>("checkValidity");

    public async Task<bool> ReportValidityAsync() =>
        await InvokeMethodAsync<bool>("reportValidity");

    public async Task SetCustomValidityAsync(string? message) =>
        await InvokeMethodAsync("setCustomValidity", message);

}
