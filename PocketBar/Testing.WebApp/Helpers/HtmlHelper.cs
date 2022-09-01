using AngleSharp;
using AngleSharp.Io;
using System.Net.Http;
using System.Threading;
using AngleSharp.Html.Dom;
using System.Threading.Tasks;
using System.Net.Http.Headers;


namespace Testing.WebApp.Helpers;


/// <summary>
/// Class Defines HTML Data Parser Helper.
/// </summary>
public static class HtmlHelpers
{
    
    /// <summary>
    /// Class Gets HTML Elements From Response.
    /// </summary>
    /// <param name="response">Defines Response Connection.</param>
    /// <returns>Full HTML Document.</returns>
    public static async Task<IHtmlDocument> GetDocumentAsync(HttpResponseMessage response)
    {
        var content = await response.Content.ReadAsStringAsync();
        var document = await BrowsingContext.New()
            .OpenAsync(ResponseFactory, CancellationToken.None);
        return (IHtmlDocument)document;

        void ResponseFactory(VirtualResponse htmlResponse)
        {
            htmlResponse
                .Address(response.RequestMessage?.RequestUri)
                .Status(response.StatusCode);

            MapHeaders(response.Headers);
            MapHeaders(response.Content.Headers);

            htmlResponse.Content(content);

            void MapHeaders(HttpHeaders headers)
            {
                foreach (var header in headers)
                {
                    foreach (var value in header.Value)
                    {
                        htmlResponse.Header(header.Key, value);
                    }
                }
            }
        }
    }
}