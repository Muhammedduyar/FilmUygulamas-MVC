using FluentValidation;
using ProjectDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBusinessLogicLayer.FluentValidation
{
    public class MovieValidation : AbstractValidator<MovieDto>
    {
        public MovieValidation()
        {
            RuleFor(movie => movie.MovieName)
                .NotEmpty().WithMessage("Lütfen İsim Giriniz...").MaximumLength(50).WithMessage("ismin çok uzun");
            RuleFor(movie => movie.MovieType).NotEmpty().WithMessage("Lütfen Film Türü Giriniz...");
            RuleFor(movie => movie.MovieDescription).NotEmpty().WithMessage("Lütfen Açıklama Giriniz")
                .MaximumLength(100).WithMessage("Spoiler Verme");
            RuleFor(movie => movie.ReleaseDate).NotEmpty().WithMessage("lütfen yayınlanma tarihi giriniz")
                .LessThan(DateTime.Now).WithMessage("Film Yayınlanma tarihi " + DateTime.Now + " tarihinden önce olmalıdır");
        }
    }
}
