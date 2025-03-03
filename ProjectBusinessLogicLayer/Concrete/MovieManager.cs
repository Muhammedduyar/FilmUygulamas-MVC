using AutoMapper;
using AutoMapper.Configuration.Annotations;
using FluentValidation;
using ProjectBusinessLogicLayer.Service;
using ProjectDataAccessLayer.Abstract;
using ProjectDto;
using ProjectEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBusinessLogicLayer.Concrete
{
    public class MovieManager : IMovieService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Movie> _movierepositry;
        private readonly IValidator<MovieDto> _validator;

        public MovieManager(IMapper mapper,IValidator<MovieDto> validator,IRepository<Movie> repository)
        {
            _mapper = mapper;
            _movierepositry = repository;
            _validator = validator;
        }
        public async Task AddMovie(MovieDto movieDto)
        {
            var validatitonresult = await _validator.ValidateAsync(movieDto);
            if (!validatitonresult.IsValid)
            {
                throw new ValidationException(validatitonresult.Errors);
            }
            var movie = _mapper.Map<Movie>(movieDto);
            await _movierepositry.Add(movie);
        }

        public async Task DeleteMovie(int id)
        {
            await _movierepositry.Delete(id);
        }

        public async Task<IEnumerable<MovieDto>> GetAllMovie()
        {
            var movies = await _movierepositry.GetAll();
            var movieDtos = _mapper.Map<IEnumerable<MovieDto>>(movies);
            return movieDtos;
        }

        public async Task<MovieDto> GetMovieById(int id)
        {
            var movie = await _movierepositry.GetAllById(id);
            var moviedto = _mapper.Map<MovieDto>(movie);
            return moviedto;
        }

        public async Task<IEnumerable<MovieDto>> Search(string searchterm)
        {
            var movielist = await _movierepositry.Search(searchterm);
            var dtos = _mapper.Map<IEnumerable<MovieDto>>(movielist);
            return dtos;
        }

        public async Task UpdateMovie(MovieDto movieDto)
        {
            var validationResult = await _validator.ValidateAsync(movieDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            else
            {
                var movie = _mapper.Map<Movie>(movieDto);
                await _movierepositry.Update(movie);
            }
        }
    }
}
