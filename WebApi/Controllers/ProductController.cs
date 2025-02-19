using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using Core.Services.Product;
using WebApi.Models.Product;

namespace WebApi.Controllers
{
    [RoutePrefix("products")]
    public class ProductController : BaseApiController
    {
		//private readonly ICreateProductService _createProductService;
		//private readonly IDeleteProductService _deleteProductService;
		//private readonly IGetProductService _getProductService;
		//private readonly IUpdateProductService _updateProductService;

		private static List<Products> products = new List<Products>();

		//Notes: Created Service same as existing service , however is not using as per test requirments
		public ProductController()
        {
			//_createProductService = createProductService;
			//_deleteProductService = deleteProductService;
			//_getProductService = getProductService;
			//_updateProductService = updateProductService;
		}

		[Route("{productId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateProduct(Guid productId, [FromBody] ProductModel model)
        {
            Products product = new Products();
            product.ProductId = productId.ToString();
			product.ProductDesc = model.ProductDec;
			product.ProductName= model.ProductName;
            product.ProductCode = model.ProductCode;
			products.Add(product);
			return Found(new ProductData(product));
        }

        [Route("{productId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateProduct(Guid productId, [FromBody] ProductModel model)
        {
			var productToUpdate = products.FirstOrDefault(p => p.ProductId == productId.ToString());
			if (productToUpdate != null)
			{
				// Update properties
				productToUpdate.ProductName = model.ProductName;
				productToUpdate.ProductCode = model.ProductCode;
				productToUpdate.ProductDesc = model.ProductDec;
			}

			return Found(new ProductData(productToUpdate));

		}

        [Route("{productId:guid}/deletebyid")]
        [HttpDelete]
        public HttpResponseMessage DeleteProduct(Guid productId)
        {
			var productToDelete = products.FirstOrDefault(p => p.ProductId == productId.ToString());
			products.Remove(productToDelete);
			return Found();
        }

        [Route("{productId:guid}/getproductbyid")]
        [HttpGet]
        public HttpResponseMessage GetProductbyId(Guid productId)
        {
			var product = products.FirstOrDefault(p => p.ProductId == productId.ToString());
			return Found(product);
		}

		[Route("list/getproducts")]
		[HttpGet]
		public HttpResponseMessage GetProducts([FromBody] ProductModel model)
		{
			if (!string.IsNullOrEmpty(model.ProductName) && !string.IsNullOrEmpty(model.ProductCode))
			{
				var productToSearch = products.FirstOrDefault(p => p.ProductName == model.ProductName && p.ProductCode == model.ProductCode);
				if (productToSearch != null)
					return Found(new ProductData(productToSearch));
			}
			else if (!string.IsNullOrEmpty(model.ProductName))
			{
				var productToSearch = products.FirstOrDefault(p => p.ProductName == model.ProductName);
				if (productToSearch != null)
					return Found(new ProductData(productToSearch));
			}
			else if (!string.IsNullOrEmpty(model.ProductCode))
			{
				var productToSearch = products.FirstOrDefault(p => p.ProductCode == model.ProductCode);
				if (productToSearch != null)
					return Found(new ProductData(productToSearch));
				
			}			
			
		   return Found();
			
		}


		[Route("list")]
        [HttpGet]
        public HttpResponseMessage GetProducts()
        {
			return Found(products.ToList());
		}

        [Route("clear")]
        [HttpDelete]
        public HttpResponseMessage DeleteAllProducts()
        {
            products.Clear();
            return Found();
        }

    }
}