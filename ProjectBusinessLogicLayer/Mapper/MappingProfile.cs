using AutoMapper;
using ProjectDto;
using ProjectEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBusinessLogicLayer.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieDto>()
                .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.MovieName))
                .ForMember(dest => dest.MovieDescription, opt => opt.MapFrom(src => src.MovieDescription))
                .ForMember(dest => dest.MovieType, opt => opt.MapFrom(src => src.MovieType))
                .ForMember(dest => dest.isWatch, opt => opt.MapFrom(src => src.isWatched))
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleasedDate))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.MovieId))
                .ForMember(dest => dest.ImageMovie, opt => opt.MapFrom(src => src.Image));

            CreateMap<MovieDto, Movie>()
                .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.MovieName))
                .ForMember(dest => dest.MovieType, opt => opt.MapFrom(src => src.MovieType))
                .ForMember(dest => dest.MovieDescription, opt => opt.MapFrom(src => src.MovieDescription))
                .ForMember(dest => dest.isWatched, opt => opt.MapFrom(src => src.isWatch))
                .ForMember(dest => dest.ReleasedDate, opt => opt.MapFrom(src => src.ReleaseDate))
                .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageMovie));

            CreateMap<User, UserDto>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            // UserDto -> User eşlemesi
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}
