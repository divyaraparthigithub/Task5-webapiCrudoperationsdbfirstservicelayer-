using Task5_webapiCrudoperationsdbfirstservicelayer_.Model;

namespace Task5_webapiCrudoperationsdbfirstservicelayer_.ServiceLayer
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);    
        void DeleteProduct(int id);
    }
        
        
}
