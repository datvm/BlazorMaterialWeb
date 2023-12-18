namespace BlazorMaterialWeb.Common;

public interface IJSArrayReference<T>
{
    IJSObjectReference JSObjectReference { get; }

    Task<T> GetItemAsync(long index);
    Task<long> GetLengthAsync();
}

class JSArrayReference<T> : IJSArrayReference<T>
{
    readonly IJSObjectReference jsRef;
    readonly IJSRuntime js;

    public JSArrayReference(IJSObjectReference jsRef, IJSRuntime js)
    {
        this.jsRef = jsRef;
        this.js = js;
    }

    public IJSObjectReference JSObjectReference => jsRef;

    public async Task<long> GetLengthAsync() =>
        await js.GetObjectPropertyAsync<long>(jsRef, "length");

    public async Task<T> GetItemAsync(long index) =>
        await js.GetArrayElementAsync<T>(jsRef, index);

}
