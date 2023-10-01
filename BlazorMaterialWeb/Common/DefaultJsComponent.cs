namespace BlazorMaterialWeb.Common;

public class DefaultJsComponent : DefaultMdComponent
{

    [Inject]
    protected IJSRuntime Js { get; set; } = null!;

    public async Task<T> InvokeMethodAsync<T>(string methodName, params object?[] parameters) =>
        await Js.InvokeElementMethodAsync<T>(el, methodName, parameters);

    public async Task InvokeMethodAsync(string methodName, params object?[] parameters) =>
        await Js.InvokeElementMethodAsync(el, methodName, parameters);

    public async Task<T> GetPropertyAsync<T>(string propertyName) =>
        await Js.GetElementPropertyAsync<T>(el, propertyName);

    public async Task SetPropertyAsync<T>(string propertyName, T? value) =>
        await Js.SetElementPropertyAsync(el, propertyName, value);

}
