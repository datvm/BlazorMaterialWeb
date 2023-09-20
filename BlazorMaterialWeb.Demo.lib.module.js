export function beforeStart() {

    function observeCodeHighlight() {
        const obs = new MutationObserver((e) => {
            if (e.some(record => {
                for (const node of record.addedNodes) {
                    if (node?.querySelector?.("code")) {
                        return true;
                    }
                }

                return false;
            })) {
                hljs.highlightAll();
            }
        });

        obs.observe(document.body, {
            childList: true,
            subtree: true,
        });
    }

    function observeMarkdown() {
        const obs = new MutationObserver((e) => {
            for (const record of e) {
                for (const node of record.addedNodes) {
                    node.querySelectorAll?.("template[data-markdown='true']")?.forEach(el => {
                        el.setAttribute("data-markdown", "false");
                        const md = el.textContent.trim();

                        const html = marked.parse(md);
                        const div = document.createElement("div");
                        div.innerHTML = html;

                        el.parentElement.insertBefore(div, el);
                    });
                }
            }

        });

        obs.observe(document.body, {
            childList: true,
            subtree: true,
        });
    }

    observeCodeHighlight();
    observeMarkdown();
}