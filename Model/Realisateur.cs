using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmApi.Models
{
    [Table("realisateurs")]
    public class Realisateur
    {
        [Column("realisateur_id")]
        public int RealisateurId { get; set; }

        [Column("nom")]
        public string Nom { get; set; }

        public ICollection<FilmRealisateur> FilmRealisateurs { get; set; }
    }
}
