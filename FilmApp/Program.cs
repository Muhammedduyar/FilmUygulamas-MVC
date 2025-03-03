using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectBusinessLogicLayer.Concrete;
using ProjectBusinessLogicLayer.FluentValidation;
using ProjectBusinessLogicLayer.Mapper;
using ProjectBusinessLogicLayer.Service;
using ProjectDataAccessLayer.Abstract;
using ProjectDataAccessLayer.Concrete;
using ProjectDataAccessLayer.Context;
using ProjectDto;
using ProjectEntities.Models;
using System;

namespace FilmApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //automapper ekle
            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

            builder.Services.AddControllersWithViews()
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<MovieValidation>();
                    fv.DisableDataAnnotationsValidation = true;
                });

            // Dbcontext eklediks
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

           
            //Dependency Injection
            builder.Services.AddScoped<IMovieService, MovieManager>();
            builder.Services.AddScoped<IValidator<MovieDto>, MovieValidation>();

            builder.Services.AddScoped<IRepository<User>, UserRepository>();
            builder.Services.AddScoped<IRepository<Movie>, MovieRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "movies",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
