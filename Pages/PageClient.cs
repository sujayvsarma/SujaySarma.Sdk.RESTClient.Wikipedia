using SujaySarma.Sdk.WikipediaApi.SerializationObjects;

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace SujaySarma.Sdk.WikipediaApi.Pages
{
    /// <summary>
    /// Client that implements the "/page" endpoint. This class contains some base functions and 
    /// other miscellaneous methods that do not need classes of their own.
    /// </summary>
    public class PageClient : WikipediaClient
    {

        /// <summary>
        /// List page-related API entry points.
        /// </summary>
        /// <param name="fullyQualifyResults">If set to TRUE, returns fully qualified URI. Otherwise the result is only the final segment of the URI. (Note that this is not a parameter for the REST API endpoint)</param>
        /// <returns>List of URI strings. Will be Non-NULL + empty list in case of problems.</returns>
        public List<string> GetPageServiceEndpoints(bool fullyQualifyResults = true)
        {
            string? responseJson = GET("page").Result;
            List<string> results = new ();
            if (!string.IsNullOrWhiteSpace(responseJson))
            {
                PagesListResult? result = JsonSerializer.Deserialize<PagesListResult>(responseJson);
                results = result?.Items ?? new List<string>();

                if (fullyQualifyResults && (results.Count > 0))
                {
                    for (int i = 0; i < results.Count; i++)
                    {
                        results[i] = $"{ENDPOINT_BASE_URI}/page/{results[i]}";
                    }
                }
            }

            return results;
        }

        /// <summary>
        /// Gets metadata for a random page from Wikipedia.
        /// </summary>
        /// <param name="formatType">Format of the data to be returned. This is the data format matching one of the other query types</param>
        /// <returns>Data in the requested format (as dynamic). Caller must use/cast to the right format. Will be NULL if there was a problem</returns>
        public dynamic? GetRandomPage(MetadataFormatType formatType = MetadataFormatType.Title)
        {
            if (!Enum.IsDefined(typeof(MetadataFormatType), formatType))
            {
                throw new ArgumentOutOfRangeException(nameof(formatType));
            }

            string paramFormatType = Enum.GetName(typeof(MetadataFormatType), formatType)!.ToLower().Replace("_", "-");
            string? resultData = GET($"page/random/{paramFormatType}").Result;
            if (!string.IsNullOrWhiteSpace(resultData))
            {
                switch (formatType)
                {
                    case MetadataFormatType.Title:
                        return JsonSerializer.Deserialize<PageMetadataBasic>(resultData);

                    case MetadataFormatType.Related:
                        PageMetadataList? result = JsonSerializer.Deserialize<PageMetadataList>(resultData);
                        return result?.Pages ?? new List<PageMetadata>();

                    case MetadataFormatType.Summary:
                        return JsonSerializer.Deserialize<PageMetadata>(resultData);

                    case MetadataFormatType.Html:
                        return resultData;

                    case MetadataFormatType.Mobile_Sections:
                        return JsonSerializer.Deserialize<MobileFriendlyPage>(resultData);

                    case MetadataFormatType.Mobile_Sections_Lead:
                        return JsonSerializer.Deserialize<MobileFriendlyPageLead>(resultData);

                }
            }

            return null;
        }

        /// <summary>
        /// Returns a list of pages that are related to the provided topic
        /// </summary>
        /// <param name="topic">Topic name (can be partial page name)</param>
        /// <returns>List of page information metadata. May be empty, but never NULL</returns>
        public List<PageMetadata> GetPagesRelatedTo(string topic)
        {
            if (string.IsNullOrWhiteSpace(topic))
            {
                throw new ArgumentNullException(nameof(topic));
            }

            List<PageMetadata> results = new ();
            string? resultData = GET($"page/related/{topic}").Result;
            if (!string.IsNullOrWhiteSpace(resultData))
            {
                PageMetadataList? result = JsonSerializer.Deserialize<PageMetadataList>(resultData);
                results = result?.Pages ?? new List<PageMetadata>();
            }

            return results;
        }



        /// <summary>
        /// Constructor (blank)
        /// </summary>
        public PageClient() : base() { }

    }
}
