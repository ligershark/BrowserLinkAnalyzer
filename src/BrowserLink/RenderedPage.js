/// <reference path="../_intellisense/browserlink.intellisense.js" />

(function (browserLink, $) {
    /// <param name="browserLink" value="bl" />
    /// <param name="$" value="jQuery" />

    function SendInfo() {
        alert("Hello from Browser Link Analyzer");

        // Use XmlHttpRequest to get the source verbatim from the web server
        var source = document.documentElement.outerHTML;

        browserLink.invoke("CollectSource", source);
    }

    return {

        onConnected: function () { // Is called when a connection is established
            SendInfo();
        }
    };
});