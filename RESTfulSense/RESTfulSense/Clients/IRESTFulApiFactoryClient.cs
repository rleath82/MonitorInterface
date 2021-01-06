using System.Threading.Tasks;

namespace RESTfulSense.Clients
{
    public interface IRESTFulApiFactoryClient
    {
        ValueTask<T> GetContentAsync<T>(string relativeUrl);
        ValueTask<string> GetContentStringAsync(string relativeUrl);
        ValueTask<T> PostContentAsync<T>(string relativeUrl, T content);
        ValueTask<TResult> PostContentAsync<TContent, TResult>(string relativeUrl, TContent content);
        ValueTask<T> PutContentAsync<T>(string relativeUrl, T content);
        ValueTask<T> PutContentAsync<T>(string relativeUrl);
        ValueTask DeleteContentAsync(string relativeUrl);
        ValueTask<T> DeleteContentAsync<T>(string relativeUrl);
    }
}
