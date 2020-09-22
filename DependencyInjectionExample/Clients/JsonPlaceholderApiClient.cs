using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace DependencyInjectionExample
{
    public class JsonPlaceholderApiClient
    {
        /// <summary>
        ///     Holt eine Liste mit allen Artikeln
        /// </summary>
        /// <returns>Liste mit Artikeln</returns>
        public async Task<PostDto[]> GetAllPostsAsync()
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client
                .GetAsync("https://jsonplaceholder.typicode.com/posts"))
            {
                response.EnsureSuccessStatusCode();

                string body = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<PostDto[]>(body);
            }
        }

        /// <summary>
        ///     Holt eine Liste mit allen Kommentaren
        /// </summary>
        /// <returns>Liste mit Kommentaren</returns>
        public async Task<CommentDto[]> GetAllCommentsAsync()
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/comments")
            )
            {
                response.EnsureSuccessStatusCode();

                string body = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<CommentDto[]>(body);
            }
        }
    }
}