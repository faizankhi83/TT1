
﻿using System.Collections.Generic;
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
	public class OrderRepository : IOrderRepository
	{
		private static List<Orders> _orders = new List<Orders>();

		public OrderRepository()
		{

		}

		public async Task AddOrder(Orders order)
		{
			_orders.Add(order);
			await Task.CompletedTask;
		}

		public async Task UpdateOrder(Orders order)
		{
			var orderToUpdate = _orders.FirstOrDefault(p => p.OrderId == order.OrderId.ToString());
			if (orderToUpdate != null)
			{
				// Update properties
				orderToUpdate.CustomerName = order.CustomerName;
				orderToUpdate.ProductId = order.ProductId;
				orderToUpdate.OrderDate = order.OrderDate;
			}

			await Task.CompletedTask;
		}

		public async Task DeleteOrderbyId(string id)
		{
			var product = _orders.FirstOrDefault(p => p.OrderId == id);
			if (product != null)
			{
				_orders.Remove(product);
			}
			await Task.CompletedTask;
		}

		public async Task DeleteAllOrder()
		{
			_orders.Clear();
			await Task.CompletedTask;
		}
		public async Task<List<Orders>> GetAllOrder()
		{
			return await Task.FromResult(_orders);
		}

		public async Task<Orders> GetOrderById(string id)
		{
			var product = _orders.FirstOrDefault(p => p.OrderId == id);
			return await Task.FromResult(product);
		}

		
	}
}