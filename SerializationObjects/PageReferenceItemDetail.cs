using System.Collections.Generic;

namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// An item in the <see cref="PageReferencesList.Items"/>
    /// </summary>
    public class PageReferenceItemDetail
    {
        /// <summary>
        /// List of backward-facing links from this item.
        /// </summary>
        public List<PageReferenceItemDetailBackLink>? BackLinks { get; set; }

        /// <summary>
        /// Content for the reference item. Expect 2 keys: "html" (the Html content) and "type" (can be "web", or "generic", or .. ?)
        /// </summary>
        public Dictionary<string, string>? Content { get; set; }
    }
}
