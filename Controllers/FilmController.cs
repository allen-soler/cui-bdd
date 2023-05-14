using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilmApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace FilmApi.Controllers
{
    [ApiController]
    [Route("api/films")]
    public class FilmsController : ControllerBase
    {
        private readonly FilmContext _context;

        public FilmsController(FilmContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<object>> GetAllFilms()
        {
            var films = _context.Films
                .Include(f => f.FilmRealisateurs).ThenInclude(fr => fr.Realisateur)
                .Include(f => f.FilmActeurs).ThenInclude(fa => fa.Acteur)
                .Include(f => f.FilmGenres).ThenInclude(fg => fg.Genre)
                .Take(10)
                .ToList();

            var filmDtos = films.Select(film => new
            {
                films_id = film.FilmId,
                titre = film.Titre,
                note = film.Note,
                annee = film.Annee.ToString("yyyy-MM-dd"),
                dure = film.Duree,
                realisateurs = film.FilmRealisateurs.Select(fr => new { id = fr.Realisateur.RealisateurId, name = fr.Realisateur.Nom }),
                acteurs = film.FilmActeurs.Select(fa => new { id = fa.Acteur.CastActorId, name = fa.Acteur.Nom }),
                genres = film.FilmGenres.Select(fg => new { id = fg.Genre.GenreId, name = fg.Genre.GenreName })
            }).ToList();

            return filmDtos;
        }
    }
}
