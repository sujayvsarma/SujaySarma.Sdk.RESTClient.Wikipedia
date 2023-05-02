using SujaySarma.Sdk.RestApi;

using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SujaySarma.Sdk.WikipediaApi.Transform
{
    /// <summary>
    /// Implements the "/transform/*" endpoints of the WikiPedia.org REST API. Allows the caller to transform data 
    /// from one format to another for reusability. 
    /// </summary>
    /// <remarks>
    ///     Currently only one call is implemented. The required API/specs for the other specifications are not provided in the 
    ///     Wikipedia.org REST API documentation.
    /// </remarks>
    public class TransformationClient : WikipediaClient
    {

        /// <summary>
        /// Convert Html to WikiText format
        /// </summary>
        /// <param name="html">Input Html</param>
        /// <returns>Converted WikiText</returns>
        public async Task<string?> HtmlToWikiTextAsync(string html)
        {
            if (string.IsNullOrWhiteSpace(html))
            {
                throw new ArgumentNullException(nameof(html));
            }

            // construct multi-part form data
            string boundaryName = $"----------{Guid.NewGuid():N}";

            StringBuilder requestContent = new();
            requestContent.Append("--").Append(boundaryName)
                .Append("\r\nContent-Disposition: form-data; name=\"scrub_wikitext\"\r\n\r\nfalse");
            requestContent.Append("--").Append(boundaryName)
                .Append("\r\nContent-Disposition: form-data; name=\"html\"\r\n\r\n")
                    .Append(html);

            RestApiClient client = RestApiClient.CreateBuilder()
                .WithRequestUri(new Uri($"{ENDPOINT_BASE_URI}/transform/html/to/wikitext"))
                .WithBody(requestContent.ToString(), $"multipart/form-data; boundary={boundaryName}");

            HttpResponseMessage responseMessage = await client.Post();
            if (! responseMessage.IsSuccessStatusCode)
            {
                return null;
            }

            return await responseMessage.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Constructor (blank)
        /// </summary>
        public TransformationClient(): base() { }
    }
}
