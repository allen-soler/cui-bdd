using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmApi.Models
{
    [Table("films")]
    public class Film
    {
        [Column("film_id")]
        public int FilmId { get; set; }

        [Column("titre")]
        public string Titre { get; set; }

        [Column("annee", TypeName = "Date")]
        public DateTime Annee { get; set; }

        [Column("note")]
        public float Note { get; set; }

        [Column("duree")]
        public int Duree { get; set; }

        public ICollection<FilmActeur> FilmActeurs { get; set; }
        public ICollection<FilmGenre> FilmGenres { get; set; }
        public ICollection<FilmRealisateur> FilmRealisateurs { get; set; }
    }
}
