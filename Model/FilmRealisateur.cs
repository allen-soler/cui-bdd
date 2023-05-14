using System.ComponentModel.DataAnnotations.Schema;

namespace FilmApi.Models
{
    [Table("film_realisateurs")]
    public class FilmRealisateur
    {
        [Column("film_id")]
        public int FilmId { get; set; }

        [Column("realisateur_id")]
        public int RealisateurId { get; set; }

        [ForeignKey("FilmId")]
        public Film Film { get; set; }

        [ForeignKey("RealisateurId")]
        public Realisateur Realisateur { get; set; }
    }
}
