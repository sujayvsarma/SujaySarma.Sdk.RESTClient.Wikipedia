using SujaySarma.Sdk.WikipediaApi.SerializationObjects;

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace SujaySarma.Sdk.WikipediaApi.Data
{
    /// <summary>
    /// Implements the "/data/citation/*" endpoints
    /// </summary>
    public class CitationClient : WikipediaClient
    {
        /// <summary>
        /// Get the citation reference for an item in MediaWiki format
        /// </summary>
        /// <param name="itemIdentifier">
        ///     Identifier for the citation (what do you want to cite?). Accepted identifiers are: 
        ///     ISBN, article URL, DOI, PMCID or PMID
        /// </param>
        /// <returns>List of citation information, or NULL</returns>
        public List<CitationMediaWikiFormat>? GetCitationMediaWiki(string itemIdentifier)
        {
            if (string.IsNullOrWhiteSpace(itemIdentifier))
            {
                throw new ArgumentNullException(nameof(itemIdentifier));
            }

            string? responseJson = GetCitationResponse("mediawiki", "itemIdentifier");
            return ((!string.IsNullOrWhiteSpace(responseJson)) ? JsonSerializer.Deserialize<List<CitationMediaWikiFormat>>(responseJson) : null);
        }

        /// <summary>
        /// Get the citation reference for an item in Zotero format
        /// </summary>
        /// <param name="itemIdentifier">
        ///     Identifier for the citation (what do you want to cite?). Accepted identifiers are: 
        ///     ISBN, article URL, DOI, PMCID or PMID
        /// </param>
        /// <returns>List of citation information, or NULL</returns>
        public List<CitationZoteroFormat>? GetCitationZotero(string itemIdentifier)
        {
            if (string.IsNullOrWhiteSpace(itemIdentifier))
            {
                throw new ArgumentNullException(nameof(itemIdentifier));
            }

            string? responseJson = GetCitationResponse("zotero", "itemIdentifier");
            return ((!string.IsNullOrWhiteSpace(responseJson)) ? JsonSerializer.Deserialize<List<CitationZoteroFormat>>(responseJson) : null);
        }

        /// <summary>
        /// Get the citation reference for an item in Wikibase format
        /// </summary>
        /// <param name="itemIdentifier">
        ///     Identifier for the citation (what do you want to cite?). Accepted identifiers are: 
        ///     ISBN, article URL, DOI, PMCID or PMID
        /// </param>
        /// <returns>List of citation information, or NULL</returns>
        /// <remarks>
        ///     Note: The REST endpoint does actually return the data in Zotero format!
        /// </remarks>
        public List<CitationZoteroFormat>? GetCitationWikibase(string itemIdentifier) => GetCitationZotero(itemIdentifier);

        /// <summary>
        /// Get the citation reference for an item in BibText format
        /// </summary>
        /// <param name="itemIdentifier">
        ///     Identifier for the citation (what do you want to cite?). Accepted identifiers are: 
        ///     ISBN, article URL, DOI, PMCID or PMID
        /// </param>
        /// <returns>Citation information as text!</returns>
        /// <remarks>
        ///     Though the result is structured (in TeX), we don't parse it here. That's upto the 
        ///     caller to parse and make use of the data.
        /// </remarks>
        public string? GetCitationBibText(string itemIdentifier)
        {
            if (string.IsNullOrWhiteSpace(itemIdentifier))
            {
                throw new ArgumentNullException(nameof(itemIdentifier));
            }

            return GetCitationResponse("bibtex", itemIdentifier);
        }


        private string? GetCitationResponse(string format, string identifier) => GET($"data/citation/{format}/{Uri.EscapeDataString(identifier)}").Result;



        /// <summary>
        /// Constructor (blank)
        /// </summary>
        public CitationClient() : base() { }

    }
}
