using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmApi.Models
{
    [Table("genres")]
    public class Genre
    {
        [Column("genre_id")]
        public int GenreId { get; set; }

        [Column("genre")]
        public string GenreName { get; set; }

        public ICollection<FilmGenre> FilmGenres { get; set; }
    }
}
