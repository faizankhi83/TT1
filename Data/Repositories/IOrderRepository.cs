using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessEntities;

namespace Data.Repositories
{
	public interface IOrderRepository

	{
		Task AddOrder(Orders order);
		Task UpdateOrder(Orders order);
		Task DeleteOrderbyId(string id);
		Task DeleteAllOrder();
		Task<List<Orders>> GetAllOrder();
		Task<Orders> GetOrderById(string id);

	}
}