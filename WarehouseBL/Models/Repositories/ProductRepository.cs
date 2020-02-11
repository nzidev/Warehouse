using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarehouseBL.Models.DataBase;

namespace WarehouseBL.Models.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        CoreDbContext context;
        public ProductRepository(CoreDbContext context)
        {
            this.context = context;
        }
        public void Add(Product entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(Product entity)
        {
            context.Products.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products;
        }

        
        public Product GetById(int id)
        {
            return context.Products.Single(s => s.ProdictId == id);
        }

        public void ChangeStatus(Product product, Product.ProductStatus status)
        {
            Product updateProduct = context.Products.Single(x => x.ProdictId == product.ProdictId);
            updateProduct.Status = status;
            context.SaveChanges();
        }
    }
}
