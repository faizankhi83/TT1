using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessEntities;

namespace Data.Repositories
{
    public interface IProductRepository 
    {
		Task AddProduct(Products product);
		Task UpdateProduct(Products product);
		Task DeleteProductbyId(string id);
		Task DeleteAllProduct();
		Task<List<Products>> GetAllProduct();
		Task<Products> GetProductById(string id);
	}
}