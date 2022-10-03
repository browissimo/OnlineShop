using OnlineShop.DAL.Interfaces;
using OnlineShop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.Repositories
{
    public class ColorRepository : IBaseRepository<Color>
    {
        private readonly ApplicationDbContext _context;

        public ColorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Color entity)
        {
            await _context.Colors.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Color entity)
        {
            _context.Colors.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Color> GetAll()
        {
            return _context.Colors;
        }

        public async Task<Color> Update(Color entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
