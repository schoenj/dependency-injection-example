using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionExample.Services
{
    public class ArtikelService
    {
        private readonly JsonPlaceholderApiClient _client;

        /// <summary>
        ///     Initialisiert eine neue Instanz des <see cref="ArtikelService" />
        /// </summary>
        /// <param name="client">JsonPlaceholder Api Client</param>
        public ArtikelService(JsonPlaceholderApiClient client)
        {
            _client = client;
        }

        /// <summary>
        ///     Holt alle Artikel und deren Kommentare
        /// </summary>
        /// <returns>Liste mit Artikel</returns>
        public async Task<List<ArtikelDto>> GetAllAsync()
        {
            PostDto[] posts = await _client.GetAllPostsAsync();
            CommentDto[] comments = await _client.GetAllCommentsAsync();

            List<ArtikelDto> artikel = new List<ArtikelDto>();

            foreach (PostDto post in posts)
            {
                List<CommentDto> kommentare = comments.Where(x => x.PostId == post.Id).ToList();

                ArtikelDto dto = new ArtikelDto
                {
                    Id = post.Id,
                    Body = post.Body,
                    Title = post.Title,
                    UserId = post.Id,
                    Comments = kommentare
                };

                artikel.Add(dto);
            }

            return artikel;
        }
    }

    public class ArtikelDto
    {
        /// <summary>
        ///     Holt oder setzt die Id eines Artikels
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Holt oder setzt die Id eines Users
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        ///     Holt oder setzt einen Titel
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Holt oder setzt einen Inhalt
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        ///     Holt oder setzt eine Liste mit Kommentaren
        /// </summary>
        public List<CommentDto> Comments { get; set; }
    }
}