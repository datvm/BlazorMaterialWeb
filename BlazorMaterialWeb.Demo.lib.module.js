import "https://cdnjs.cloudflare.com/ajax/libs/marked-gfm-heading-id/3.1.0/index.umd.min.js";

export function beforeStart() {

    function trimSameLeadingSpaces(input) {
        const lines = input.split("\n");

        let minSpace = Number.MAX_SAFE_INTEGER;
        for (const line of lines) {
            if (line.trim().length !== 0) {
                const space = line.match(/^\s*/)[0].length;
                minSpace = Math.min(minSpace, space);
            }
        }

        return lines
            .map(line => line.substring(minSpace))
            .join("\n");
    }

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
        marked.use(markedGfmHeadingId.gfmHeadingId());

        const obs = new MutationObserver((e) => {
            for (const record of e) {
                for (const node of record.addedNodes) {
                    node.querySelectorAll?.("template[data-markdown='true']")?.forEach(el => {
                        el.setAttribute("data-markdown", "false");
                        const md = trimSameLeadingSpaces(el.textContent);

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