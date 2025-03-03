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
    public class UserRepository : IRepository<User>
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext appdbcontext)
        {
            _context = appdbcontext;
        }
        public async Task Add(User t)
        {
            await _context.Users.AddAsync(t);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if(user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetAllById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public Task<IEnumerable<User>> Search(string searchterm)
        {
            throw new NotImplementedException();
        }

        public async Task Update(User t)
        {
            _context.Users.Update(t);
            await _context.SaveChangesAsync();
        }
    }
}
