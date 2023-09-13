namespace Microsoft.JSInterop;

internal static class JsExtensions
{
    const string JsPrefix = "BlazorMaterialWeb.";

    public static async Task<T> GetElementPropertyAsync<T>(this IJSRuntime js, ElementReference el, string propertyName) =>
        await js.InvokeAsync<T>(Prefix("getElementProperty"), el, propertyName);

    public static async Task InvokeElementMethodAsync(this IJSRuntime js, ElementReference el, string methodName, params object[] parameters) =>
        await js.InvokeVoidAsync(
            Prefix("invokeElementMethodAsync"),
            GetInvokeParameters(el, methodName, parameters));

    public static async Task<T> InvokeElementMethodAsync<T>(this IJSRuntime js, ElementReference el, string methodName, params object[] parameters) =>
        await js.InvokeAsync<T>(
            Prefix("invokeElementMethodAsync"),
            GetInvokeParameters(el, methodName, parameters));

    static object[] GetInvokeParameters(ElementReference el, string methodName, params object[] parameters) =>
        new object[] { el, methodName }
        .Concat(parameters)
        .ToArray();

    static string Prefix(string name) => JsPrefix + name;

}
