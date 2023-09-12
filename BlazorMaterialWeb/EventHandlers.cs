namespace BlazorMaterialWeb;

[EventHandler("oncheckedchange", typeof(CheckboxChangeEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
public static class EventHandlers { }

public class CheckboxChangeEventArgs : EventArgs
{
    public bool Checked { get; set; }
    public bool Indeterminate { get; set; }
}
