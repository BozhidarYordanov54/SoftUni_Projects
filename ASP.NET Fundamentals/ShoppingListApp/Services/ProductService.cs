﻿using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Contracts;
using ShoppingListApp.Data;
using ShoppingListApp.Data.Models;
using ShoppingListApp.Models;

namespace ShoppingListApp.Services
{
    public class ProductService : IProductService
    {
        private readonly ShoppingListDbContext _context;

        public ProductService(ShoppingListDbContext context)
        {
            _context = context;
        }

        public async Task AddProductAsync(ProductViewModel model)
        {
            var entity = new Product()
            {
                Name = model.Name
            };

            _context.Products.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var entity = await _context.Products.FindAsync(id);

            if(entity == null)
            {
                throw new ArgumentException("Product not found");
            }

            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllAsync()
        {
            return await _context.Products
                .AsNoTracking()
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToListAsync();
        }

        public async Task<ProductViewModel> GetByIdAsync(int id)
        {
            var entity = await _context.Products.FindAsync(id);

            if(entity == null)
            {
                throw new ArgumentException("Product not found");
            }

            return new ProductViewModel()
            {
                Id = entity.Id,
                Name = entity.Name
            };
                
        }

        public async Task UpdateProductAsync(ProductViewModel model)
        {
            var entity = await _context.Products.FindAsync(model.Id);

            if (entity == null)
            {
                throw new ArgumentException("Product not found");
            }

            entity.Name = model.Name;

            await _context.SaveChangesAsync();
        }
    }
}
