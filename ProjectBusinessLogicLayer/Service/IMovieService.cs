using ProjectDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBusinessLogicLayer.Service
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetAllMovie();
        Task<MovieDto>GetMovieById(int id);
        Task AddMovie(MovieDto movieDto);
        Task DeleteMovie(int id);
        Task UpdateMovie(MovieDto movieDto);
        Task<IEnumerable<MovieDto>> Search(string searchterm);
    }
}
