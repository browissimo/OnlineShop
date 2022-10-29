using Microsoft.EntityFrameworkCore;
using OnlineShop.DAL.Interfaces;
using OnlineShop.Domain.Entity;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.DAL.Repositories
{
    public class ItemRepository : IBaseRepository<Item>
    {
        private readonly ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Item entity)
        {
            await _context.Items.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Item entity)
        {
            _context.Items.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Item> GetAll()
        {
            return _context.Items.Include(i => i.Colors).Include(s => s.Sizes).Include(ic => ic.itemColors);
        }

        public async Task<Item> Update(Item entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
