using System.ComponentModel.DataAnnotations.Schema;

namespace FilmApi.Models
{
    [Table("film_genres")]
    public class FilmGenre
    {
        [Column("film_id")]
        public int FilmId { get; set; }
        
        [Column("genre_id")]
        public int GenreId { get; set; }

        [ForeignKey("FilmId")]
        public Film Film { get; set; }

        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
    }
}
