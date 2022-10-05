using OnlineShop.DAL.Interfaces;
using OnlineShop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.Repositories
{
    public class ItemImageRepository : IBaseRepository<ItemImage>
    {
        private readonly ApplicationDbContext _context;

        public ItemImageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(ItemImage entity)
        {
            await _context.ItemImages.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ItemImage entity)
        {
            _context.ItemImages.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<ItemImage> GetAll()
        {
            return _context.ItemImages;
        }

        public async Task<ItemImage> Update(ItemImage entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
