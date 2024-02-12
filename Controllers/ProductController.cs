using Microsoft.AspNetCore.Mvc;
using Task5_webapiCrudoperationsdbfirstservicelayer_.Model;
using Task5_webapiCrudoperationsdbfirstservicelayer_.ServiceLayer;

namespace Task5_webapiCrudoperationsdbfirstservicelayer_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
       
            private readonly IProductService _productService;
            private readonly ProductDbContext _dbContext;
            //private readonly ILogger _logger;

            public ProductController(IProductService productService,ProductDbContext dbContext)
            {
                _productService = productService;
                _dbContext = dbContext;
                //_logger = logger;
            }

            [HttpGet]
            public IActionResult GetProducts()
            {
                var products = _productService.GetProducts();
                return Ok(products);
            }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                var product = _productService.GetProductById(id);
                if (product == null)
                {
                    throw new Exception();
                }
                return Ok(product);
            }
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, "An error occurred while processing the request.");
            //    return StatusCode(500, "Internal Server Error");
            //    //Log.Error(ex, "An error occurred while processing the request.");
            //    //return StatusCode(500, "Internal Server Error");
            //}
            catch (Exception ex)
            {
                Logtable log = new Logtable
                {
                    Timestamp = DateTime.UtcNow,
                    LogLevel = "Error",
                    sources = "Product",
                    message = "An error occurred",
                    Exception = ex.ToString()
                };

                _dbContext.Logtable.Add(log);
                _dbContext.SaveChanges();
            }
            return NoContent();
        }
            
            [HttpPost]
            public IActionResult CreateProduct( Product product)
            {
                _productService.CreateProduct(product);
                return Ok(product);
            }

            [HttpPut("{id}")]
            public IActionResult UpdateProduct(int id,Product product)
            {
                if (id != product.Id)
                {
                    return BadRequest();
                }

                _productService.UpdateProduct(product);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteProduct(int id)
            {
                _productService.DeleteProduct(id);
                return NoContent();
            }
        }
    
}
