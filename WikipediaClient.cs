using SujaySarma.Sdk.RestApi;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SujaySarma.Sdk.WikipediaApi
{
    /// <summary>
    /// Base API client. Contains helper functions. Functions are public so that you can call them directly if you 
    /// wish for a new/undocumented API instead of implementing a class for a short-term purpose. All other *Client 
    /// classes in this library derive from this class.
    /// </summary>
    public class WikipediaClient
    {

        /// <summary>
        /// Execute a GET request against an endpoint
        /// </summary>
        /// <param name="uriFragment">Fragment (tail) of the Wikipedia.org REST endpoint. 
        /// (Provide only the part that comes after the <see cref="ENDPOINT_BASE_URI"/> value)</param>
        /// <param name="parameters">Optional, query string parameters. Function wil escape values, so pass in raw data!</param>
        /// <param name="headers">Optional, additional headers to add. Standard headers for Wikipedia.org API is added automaticaly.</param>
        /// <returns>Response content body as string. NULL if was not successful or content itself was NULL.</returns>
        public async Task<string?> GET(string uriFragment, Dictionary<string, string>? parameters = null, Dictionary<string, string>? headers = null)
        {
            StringBuilder uri = new ();
            uri.Append(ENDPOINT_BASE_URI).Append('/').Append(uriFragment);
            if ((parameters != null) && (parameters.Count > 0))
            {
                uri.Append('?');
                bool isFirstParam = true;
                foreach (string key in parameters.Keys)
                {
                    uri.Append($"{(isFirstParam ? "?" : "&")}{key}={Uri.EscapeDataString(parameters[key])}");
                    isFirstParam = false;
                }
            }

            RestApiClient client = RestApiClient.CreateBuilder()
                .WithRequestUri(new Uri(uri.ToString()))
                .WithHeader("Accept", "application/json");

            if (!string.IsNullOrWhiteSpace(apiUserContactEmail))
            {
                client.WithHeader("User-Agent", apiUserContactEmail);
                client.WithHeader("Api-User-Agent", apiUserContactEmail);
            }

            if ((headers != null) && (headers.Count > 0))
            {
                foreach (string key in headers.Keys)
                {
                    client.WithHeader(key, headers[key]);
                }
            }

            HttpResponseMessage responseMessage = await client.Get();
            if (responseMessage.IsSuccessStatusCode)
            {
                return responseMessage.Content.ReadAsStringAsync().Result;
            }

            return null;
        }


        /// <summary>
        /// Initialize the class
        /// </summary>
        public WikipediaClient()
            : this(Environment.GetEnvironmentVariable("WIKIPEDIA_CLIENT_API_EMAIL"))
        {
            
        }

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="emailAddress">E-mail address to use in Wikipedia API headers</param>
        public WikipediaClient(string? emailAddress)
        {
            apiUserContactEmail = emailAddress;
        }

        /// <summary>
        /// Base address for the Wikipedia.org rest API
        /// </summary>
        protected static readonly string ENDPOINT_BASE_URI = "https://en.wikipedia.org/api/rest_v1";

        // used from AddHeaders()
        private readonly string? apiUserContactEmail;
    }
}
