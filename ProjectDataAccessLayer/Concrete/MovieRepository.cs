using Microsoft.EntityFrameworkCore;
using ProjectDataAccessLayer.Abstract;
using ProjectDataAccessLayer.Context;
using ProjectEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDataAccessLayer.Concrete
{
    public class MovieRepository : IRepository<Movie>
    {
        private readonly AppDbContext _context;
        public MovieRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task Add(Movie t)
        {
            await _context.Movies.AddAsync(t);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if(movie != null)
            {
                 _context.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetAllById(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task<IEnumerable<Movie>> Search(string searchterm)
        {
            var movielist =  _context.Movies
                .Where(f => f.MovieName.Contains(searchterm)).ToListAsync();
            return await movielist;
        }

        public async Task Update(Movie t)
        {
            _context.Movies.Update(t);
            await _context.SaveChangesAsync();
        }
    }
}