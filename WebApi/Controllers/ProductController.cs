using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BusinessEntities;
using Core.Services.Product;
using Data.Repositories;
using WebApi.Models.Product;

namespace WebApi.Controllers
{
    [RoutePrefix("products")]
    public class ProductController : BaseApiController
    {
		IProductRepository productRepository = new ProductRepository();
		//private static List<Products> products = new List<Products>();

		//Notes: Created Service same as existing service , however is not using as per test requirments
		public ProductController()
        {

		}

		[Route("{productId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateProduct(Guid productId, [FromBody] ProductModel model)
        {			
			Products product = new Products();
			product.ProductId = productId.ToString();
			product.ProductDesc = model.ProductDec;
			product.ProductName = model.ProductName;
			product.ProductCode = model.ProductCode;
			productRepository.AddProduct(product);

			return Found(new ProductData(product));
        }

        [Route("{productId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateProduct(Guid productId, [FromBody] ProductModel model)
        {			
			Products product = new Products();
			product.ProductId = productId.ToString();
			product.ProductDesc = model.ProductDec;
			product.ProductName = model.ProductName;
			product.ProductCode = model.ProductCode;
			productRepository.UpdateProduct(product);
			return Found(new ProductData(product));

		}

        [Route("{productId:guid}/deletebyid")]
        [HttpDelete]
        public HttpResponseMessage DeleteProduct(Guid productId)
        {
			productRepository.DeleteProductbyId(productId.ToString());
			return Found();
        }

		[Route("clear")]
		[HttpDelete]
		public HttpResponseMessage DeleteAllProducts()
		{
			productRepository.DeleteAllProduct();
			return Found();
		}

		[Route("{productId:guid}/getproductbyid")]
        [HttpGet]
        public HttpResponseMessage GetProductbyId(Guid productId)
        {
			var product= productRepository.GetProductById(productId.ToString());
			return Found(product);
		}

		[Route("list/getproducts")]
		[HttpGet]
		public HttpResponseMessage GetProducts([FromBody] ProductModel model)
		{
			Products product = new Products();
			product.ProductName = model.ProductName;
			product.ProductCode = model.ProductCode;
			var products = productRepository.GetProduct(product);
			return Found(products);

		}


		[Route("list")]
        [HttpGet]
        public HttpResponseMessage GetProducts()
        {
			var product = productRepository.GetAllProduct();
			return Found(product);
		}

        

    }
}