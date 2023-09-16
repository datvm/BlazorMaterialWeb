export function beforeStart() {
    globalThis.BlazorMaterialWeb ??= new class {

        constructor() {
            this.#overrideDispatch();
        }

        getElementProperty(element, propertyName) {
            return element[propertyName];
        }

        setElementProperty(element, propertyName, value) {
            element[propertyName] = value;
        }

        async invokeElementMethodAsync(element, methodName, ...args) {
            return await element[methodName](...args);
        }

        #overrideDispatch() {
            const original = EventTarget.prototype.dispatchEvent;

            EventTarget.prototype.dispatchEvent = function (event) {
                let arg = event;

                if (!event.bubbles && this.tagName.startsWith("MD-")) {
                    arg = new CustomEvent(event.type, {
                        bubbles: true,
                        detail: event.detail,
                        cancelable: event.cancelable,
                        composed: event.composed,
                    });
                }

                return original.call(this, arg);
            }
        }
    }();
}

export function afterStarted(blazor) {
    blazor.registerCustomEventType("checkedchange", {
        browserEventName: "change",
        createEventArgs: ({ target }) => {
            if (target.disabled) {
                return null;
            }
            return {
                value: target.value,
                checked: target.checked || target.selected, // For both switch and checkboxes
                indeterminate: target.indeterminate,
            };
        }
    });

    blazor.registerCustomEventType("selected", {
        browserEventName: "selected",
        createEventArgs: e => ({
            value: target.value,
            checked: e.target.selected
        }),
    });

    blazor.registerCustomEventType("remove", {
        browserEventName: "remove",
        createEventArgs: () => undefined,
    });

    blazor.registerCustomEventType("open", {
        browserEventName: "open",
        createEventArgs: () => undefined,
    });

    blazor.registerCustomEventType("opened", {
        browserEventName: "opened",
        createEventArgs: () => undefined,
    });

    blazor.registerCustomEventType("close", {
        browserEventName: "close",
        createEventArgs: e => ({
            returnValue: e.target.returnValue,
        }),
    });

    blazor.registerCustomEventType("closed", {
        browserEventName: "closed",
        createEventArgs: e => ({
            returnValue: e.target.returnValue,
        }),
    });

    blazor.registerCustomEventType("cancel", {
        browserEventName: "cancel",
        createEventArgs: () => undefined,
    });

    blazor.registerCustomEventType("opening", {
        browserEventName: "opening",
        createEventArgs: () => undefined,
    });

    blazor.registerCustomEventType("closing", {
        browserEventName: "closing",
        createEventArgs: () => undefined,
    });

    blazor.registerCustomEventType("menuclosed", {
        browserEventName: "closed",
        createEventArgs: () => undefined,
    });
}