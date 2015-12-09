using System.ComponentModel.Composition;
using System.IO;
using Microsoft.VisualStudio.Web.BrowserLink;

namespace BrowserLinkAnalyzer
{
    [Export(typeof(IBrowserLinkExtensionFactory))]
    public class RenderedPageFactory : IBrowserLinkExtensionFactory
    {
        public BrowserLinkExtension CreateExtensionInstance(BrowserLinkConnection connection)
        {
            return new RenderedPageExtension();
        }

        public string GetScript()
        {
            using (Stream stream = GetType().Assembly.GetManifestResourceStream("BrowserLinkAnalyzer.BrowserLink.RenderedPage.js"))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }

    public class RenderedPageExtension : BrowserLinkExtension
    {
        [BrowserLinkCallback] // This method can be called from JavaScript
        public void CollectSource(string source)
        {
            System.Diagnostics.Debug.Write(source);
        }
    }
}
