using FilmApp.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.IdentityModel.Tokens;
using ProjectBusinessLogicLayer.Service;
using ProjectDto;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;


namespace FilmApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IMovieService _movieService;
        private readonly ILogger<MovieController> _logger;
        public MovieController(IMovieService movirservice,IWebHostEnvironment webHostEnvironment ,ILogger<MovieController> logger)
        {
            _movieService = movirservice;
            _logger = logger;
            _hostingEnvironment = webHostEnvironment;
            
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetAllMovie();
            return View(movies);
        }
        
        [HttpGet]
        public async Task<IActionResult> AddMovie()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddMovie(MovieImages p)
        {
            var movieDto = new MovieDto();
            if (p != null)
            {
                var extensions = Path.GetExtension(p.Image.FileName);
                var imagename = Guid.NewGuid() + extensions;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/FilmAppMVCImages/", imagename);
                var stream = new FileStream(location, FileMode.Create);
                p.Image.CopyTo(stream);
                movieDto.ImageMovie = imagename;
            }

            movieDto.Id = p.MovieId;
            movieDto.ReleaseDate = p.ReleasedDate;
            movieDto.MovieName = p.MovieName;
            movieDto.MovieDescription = p.MovieDescription;
            movieDto.MovieType = p.MovieType;
            movieDto.isWatch = p.isWatched;
            if (!ModelState.IsValid)
            {
                var messages = ModelState.ToList();
            }
            
            await _movieService.AddMovie(movieDto);
            TempData["SuccessMessage"] = "Film Başarıyla Eklendi.";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Search(string searchterm)
        {
            if (string.IsNullOrEmpty(searchterm))
            {
                return View(new List<MovieDto>());
            }
            var movies = await _movieService.Search(searchterm);
            return View(movies);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var movieDto = await _movieService.GetMovieById(id);

            if (movieDto == null)
            {
                return NotFound();
            }

            var movieImages = new MovieImages
            {
                MovieId = movieDto.Id,
                MovieName = movieDto.MovieName,
                MovieType = movieDto.MovieType,
                MovieDescription = movieDto.MovieDescription,
                ReleasedDate = movieDto.ReleaseDate,
                isWatched = movieDto.isWatch,
                // Resim dosyası yüklenmişse, buraya varsayılan olarak boş bırakabilirsiniz
                Image = null
            };

            return View(movieImages);
        }

        [HttpPost]
        public async Task<IActionResult> Update(MovieImages p)
        {
            var movieDto = new MovieDto();

            if (p != null)
            {
                if (p.Image != null && p.Image.Length > 0)
                {
                    var extensions = Path.GetExtension(p.Image.FileName);
                    var imagename = Guid.NewGuid() + extensions;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/FilmAppMVCImages/", imagename);
                    using (var stream = new FileStream(location, FileMode.Create))
                    {
                        await p.Image.CopyToAsync(stream);
                    }
                    movieDto.ImageMovie = imagename;
                }
                else
                {
                    // Resim seçilmemişse mevcut resmi koruyun
                    movieDto.ImageMovie = movieDto.ImageMovie; // Eğer mevcut resim yolu gönderiliyorsa
                }

                movieDto.Id = p.MovieId;
                movieDto.ReleaseDate = p.ReleasedDate;
                movieDto.MovieName = p.MovieName;
                movieDto.MovieDescription = p.MovieDescription;
                movieDto.MovieType = p.MovieType;
                movieDto.isWatch = p.isWatched;

                await _movieService.UpdateMovie(movieDto);
                TempData["SuccessMessage"] = "Film Başarıyla Güncellendi.";
                return RedirectToAction("Index");
            }

            // Model geçersizse formu tekrar gösterin
            return View(p);
        }


        [HttpGet]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _movieService.GetMovieById(id);
            if(movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }
        [HttpPost]
        [ActionName("DeleteMovie")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _movieService.DeleteMovie(id);
            TempData["SuccessMessage"] = "Film başarı ile silindi";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            
            var movie = await _movieService.GetMovieById(id);
            if(movie != null)
            {
                return View(movie);
            }
            else
            {
                return NotFound("Detay Yok");
            }
        }
    }
}
