using Task5_webapiCrudoperationsdbfirstservicelayer_.Model;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Identity.Client;
using System.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace Task5_webapiCrudoperationsdbfirstservicelayer_.ServiceLayer
{
    public class ProductService:IProductService
    {
        private readonly ProductDbContext _dbContext;
        public ProductService(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Product.ToList();
        }
        public Product GetProductById(int Id)
        {
            return _dbContext.Product.Find(Id);
        }
        public void CreateProduct(Product product)
        {
            _dbContext.Product.Add(product);
            _dbContext.SaveChanges();

        }
        //[HttpPost]
        public void UpdateProduct(Product product)
        {
            var existingProduct = _dbContext.Product.Find(product.Id);
            if (existingProduct == null)
            {
                return;
            }

            // Update properties of the existing product
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Quantity= product.Quantity;
            _dbContext.SaveChanges();

        }
        public void DeleteProduct(int Id)
        {
            var product = _dbContext.Product.Find(Id);
            if (product != null)
            {
                _dbContext.Product.Remove(product);
                _dbContext.SaveChanges();
            }
        }
    }
}
