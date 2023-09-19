namespace BlazorMaterialWeb;

// Checkbox
[EventHandler("oncheckedchange", typeof(MdCheckboxChangeEventArgs), enableStopPropagation: true, enablePreventDefault: true)]

// Chip
// TODO: onremove is working now with temporary workaround: https://github.com/material-components/material-web/issues/4905
[EventHandler("onchipselected", typeof(MdCheckedEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
[EventHandler("onchipremove", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]

// Dialog
[EventHandler("onopen", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
[EventHandler("onopened", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
[EventHandler("onclose", typeof(MdDialogReturnEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
[EventHandler("onclosed", typeof(MdDialogReturnEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
[EventHandler("oncancel", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]

// Menu
[EventHandler("onopening", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
// onopened is already registered by dialog
[EventHandler("onclosing", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
[EventHandler("onmenuclosed", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]

// Slider
[EventHandler("onsliderchange", typeof(MdSliderChangeEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
[EventHandler("onsliderinput", typeof(MdSliderChangeEventArgs), enableStopPropagation: true, enablePreventDefault: true)]

// Tabs
[EventHandler("ontabchanged", typeof(MdTabChangeEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
[EventHandler("ontabactivated", typeof(MdCheckedEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
public static class EventHandlers { }

public class MdCheckedEventArgs : EventArgs
{
    public string? Value { get; set; }
    public bool Checked { get; set; }
}

public class MdCheckboxChangeEventArgs : MdCheckedEventArgs
{
    public bool Indeterminate { get; set; }
}

public class MdDialogReturnEventArgs : EventArgs
{

    public string ReturnValue { get; set; } = "";

}

public class MdSliderChangeEventArgs : EventArgs
{
    public double Value { get; set; }
    public double ValueStart { get; set; }
    public double ValueEnd { get; set; }
}

public class MdTabChangeEventArgs : EventArgs
{
    public int Index { get; set; }
}