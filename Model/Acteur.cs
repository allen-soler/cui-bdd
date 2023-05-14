using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmApi.Models
{
    [Table("acteurs")]
    public class Acteur
    {
        [Key]
        [Column("cast_actor_id")]
        public int CastActorId { get; set; }

        [Column("nom")]
        public string Nom { get; set; }

        [Column("personnage")]
        public string Personnage { get; set; }

        public ICollection<FilmActeur> FilmActeurs { get; set; }
    }
}
