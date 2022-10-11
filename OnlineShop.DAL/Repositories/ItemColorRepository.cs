using Microsoft.EntityFrameworkCore;
using OnlineShop.DAL.Interfaces;
using OnlineShop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.Repositories
{
    public class ItemColorRepository : IBaseRepository<ItemColor>
    {
        private readonly ApplicationDbContext _context;

        public ItemColorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(ItemColor entity)
        {
            await _context.ItemColors.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ItemColor entity)
        {
            _context.ItemColors.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<ItemColor> GetAll()
        {
            var test = _context.ItemColors.Include(c => c.ColorImages);
            return test;
        }

        public async Task<ItemColor> Update(ItemColor entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
