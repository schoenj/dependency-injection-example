namespace DependencyInjectionExample
{
    public class CommentDto
    {
        /// <summary>
        ///     Holt oder setzt die Id eines Kommentars
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Holt oder setzt einen Namen
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Holt oder setzt eine E-Mail Adresse
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     Holt oder setzt die Id eines Artikels
        /// </summary>
        public int PostId { get; set; }

        /// <summary>
        ///     Holt oder setzt einen Inhalt
        /// </summary>
        public string Body { get; set; }
    }
}