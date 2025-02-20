using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BusinessEntities;
using Common;
using Data.Indexes;
using Raven.Client;

namespace Data.Repositories
{
    [AutoRegister]
    public class ProductRepository :  IProductRepository
    {	
		private static List<Products> _products = new List<Products>();

		public ProductRepository() 
        {
        
        }

		public async Task AddProduct(Products product)
		{
			_products.Add(product);
			await Task.CompletedTask;
		}

		public async Task UpdateProduct(Products product)
		{
			var productToUpdate = _products.FirstOrDefault(p => p.ProductId == product.ProductId.ToString());
			if (productToUpdate != null)
			{
				// Update properties
				productToUpdate.ProductName = product.ProductName;
				productToUpdate.ProductCode = product.ProductCode;
				productToUpdate.ProductDesc = product.ProductDesc;
			}

			await Task.CompletedTask;
		}

		public async Task DeleteProductbyId(string id)
		{
			var product = _products.FirstOrDefault(p => p.ProductId == id);
			if (product != null)
			{
				_products.Remove(product);
			}
			await Task.CompletedTask;
		}

		public async Task DeleteAllProduct()
		{
			_products.Clear();
			await Task.CompletedTask;
		}
		public async Task<List<Products>> GetAllProduct()
		{
			return await Task.FromResult(_products);
		}

		public async Task<Products> GetProductById(string id)
		{
			var product = _products.FirstOrDefault(p => p.ProductId == id);
			return await Task.FromResult(product);
		}

		public async Task<Products> GetProduct(Products product)
		{
			if (!string.IsNullOrEmpty(product.ProductName) && !string.IsNullOrEmpty(product.ProductCode))
			{
				var productToSearch = _products.FirstOrDefault(p => p.ProductName == product.ProductName && p.ProductCode == product.ProductCode);
				return await Task.FromResult(productToSearch);
			}
			else if (!string.IsNullOrEmpty(product.ProductName))
			{
				var productToSearch = _products.FirstOrDefault(p => p.ProductName == product.ProductName);
				return await Task.FromResult(productToSearch);
			}
			else 
			{
				var productToSearch = _products.FirstOrDefault(p => p.ProductCode == product.ProductCode);
				return await Task.FromResult(productToSearch);

			}
			
		}		
	}
}