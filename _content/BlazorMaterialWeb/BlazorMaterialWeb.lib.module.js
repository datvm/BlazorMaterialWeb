export function beforeStart() {
    globalThis.BlazorMaterialWeb ??= new class {

        constructor() {
            this.#overrideDispatch();
            this.#observeChips();
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

        #observeChips() {
            const obs = new MutationObserver(changes => {
                for (const change of changes) {
                    const name = change.target.nodeName.toUpperCase();
                    if (name.startsWith("MD") && name.endsWith("CHIP")) {
                        const chip = change.target;
                        chip.dispatchEvent(new CustomEvent("selected", {
                            bubbles: true,
                            detail: {
                                value: chip.value,
                                checked: chip.selected,
                            }
                        }));
                    }
                }
            });

            obs.observe(document.body, {
                attributeFilter: ["selected"],
                attributes: true,
                subtree: true,
            })
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

    blazor.registerCustomEventType("chipselected", {
        browserEventName: "selected",
        createEventArgs: ({ target }) => ({
            value: target.value,
            checked: target.selected
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

    blazor.registerCustomEventType("sliderchange", {
        browserEventName: "change",
        createEventArgs: ({ target }) => ({
            value: target.value,
            valueStart: target.valueStart,
            valueEnd: target.valueEnd,
        }),
    });

    blazor.registerCustomEventType("sliderinput", {
        browserEventName: "input",
        createEventArgs: ({ target }) => ({
            value: target.value,
            valueStart: target.valueStart,
            valueEnd: target.valueEnd,
        }),
    });

    blazor.registerCustomEventType("tabchanged", {
        browserEventName: "change",
        createEventArgs: ({ target }) => {
            const tab = target.activeTab;

            tab.dispatchEvent("activated");

            return {
                index: target.activeTabIndex,
            };
        },
    });

    blazor.registerCustomEventType("tabactivated", {
        browserEventName: "activated",
        createEventArgs: ({ target }) => ({
            checked: target.active,
        }),
    });
}