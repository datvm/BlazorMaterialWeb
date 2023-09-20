namespace BlazorMaterialWeb;

// Checkbox
[EventHandler("oncheckedchange", typeof(MdCheckboxChangeEventArgs), enableStopPropagation: true, enablePreventDefault: true)]

// Chip
// TODO: onremove is working now with temporary workaround: https://github.com/material-components/material-web/issues/4905
[EventHandler("onchipselected", typeof(MdCheckedEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
[EventHandler("onchipremove", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]

// Dialog
[EventHandler("ondiagopen", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
[EventHandler("ondiagopened", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
[EventHandler("ondiagclose", typeof(MdDialogReturnEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
[EventHandler("ondiagclosed", typeof(MdDialogReturnEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
[EventHandler("ondiagcancel", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]

// Menu
[EventHandler("onmenuopening", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
[EventHandler("onmenuopened", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
[EventHandler("onmenuclosing", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
[EventHandler("onmenuclosed", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]

// Slider
[EventHandler("onsliderchange", typeof(MdSliderChangeEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
[EventHandler("onsliderinput", typeof(MdSliderChangeEventArgs), enableStopPropagation: true, enablePreventDefault: true)]

// Tabs
[EventHandler("ontabchanged", typeof(MdTabChangeEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
[EventHandler("ontabactivated", typeof(MdCheckedEventArgs), enableStopPropagation: true, enablePreventDefault: true)]

// Select
[EventHandler("onselectchange", typeof(MdSelectChangeEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
[EventHandler("onselectinput", typeof(MdSelectChangeEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
[EventHandler("onrequestselection", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
[EventHandler("onrequestdeselection", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
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

public class MdSelectChangeEventArgs : EventArgs
{
    public string Value { get; set; } = "";
    public int SelectedIndex { get; set; }
}