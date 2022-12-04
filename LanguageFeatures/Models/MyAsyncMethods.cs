using System.Collections.Generic;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public class MyAsyncMethods
    {
        public static async Task<long?> GetPageLength()
        {
            // Jeito "Original"
            //HttpClient client = new();
            //var httpTask = client.GetAsync("http://apress.com");
            //return httpTask.ContinueWith((Task<HttpResponseMessage> antecedent) =>
            //{
            //    return antecedent.Result.Content.Headers.ContentLength;
            //});

            // Usando async await
            HttpClient client = new();
            var httpMessage = await client.GetAsync("http://apress.com");
            return httpMessage.Content.Headers.ContentLength;
        }

        // Asynchronous Enumerable

        // this method isn't async
        //public static async Task<IEnumerable<long?>> GetPageLengths(
        //    List<string> output, params string[] urls)
        //{
        //    List<long?> results = new List<long?>();
        //    HttpClient client = new HttpClient();

        //    foreach(string url in urls)
        //    {
        //        output.Add($"Started request for {url}");
        //        var httpMessage = await client.GetAsync($"http://{url}");
        //        results.Add(httpMessage.Content.Headers.ContentLength);
        //        output.Add($"Completede request for {url}");
        //    }
        //    return results;
        //}

        // async method:

        public static async IAsyncEnumerable<long?> GetPageLengths(
            List<string> output, params string[] urls)
        {
            HttpClient client = new HttpClient();
            foreach(string url in urls)
            {
                output.Add($"Started request for {url}");
                var httpMessage = await client.GetAsync($"http://{url}");
                output.Add($"Completed request for {url}");
                yield return httpMessage.Content.Headers.ContentLength;
            }

        }
    }
}
