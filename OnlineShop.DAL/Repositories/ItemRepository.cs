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
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateAsync(Item entity)
        {
            await _context.Item.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Item entity)
        {
            _context.Item.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Item> GetAsync(int id)
        {
            return await _context.Item.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Item>> GetAllItems()
        {
            return await _context.Item.ToListAsync();
        }

        public async Task<Item> GetByName(string name)
        {
            return await _context.Item.FirstOrDefaultAsync(x => x.Name == name);
        }

        public Item Update(Item entity)
        {
            throw new NotImplementedException();
        }
    }
}
