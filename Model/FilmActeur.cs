using System.ComponentModel.DataAnnotations.Schema;

namespace FilmApi.Models
{
    [Table("film_acteurs")]
    public class FilmActeur
    {
        [Column("film_id")]
        public int FilmId { get; set; }
        
        [Column("cast_actor_id")]
        public int CastActorId { get; set; }

        [ForeignKey("FilmId")]
        public Film Film { get; set; }

        [ForeignKey("CastActorId")]
        public Acteur Acteur { get; set; }
    }
}
