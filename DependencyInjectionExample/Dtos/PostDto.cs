namespace DependencyInjectionExample
{
    public class PostDto
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
    }
}