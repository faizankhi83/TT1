using BusinessEntities;
using System;
using System.Collections.Generic;

namespace WebApi.Models.Order
{
    public class OrdersData 
    {
        public OrdersData(Orders orders) 
        {
			if (orders != null)
			{
				OrderId = orders.OrderId;
				CustomerName = orders.CustomerName;
				OrderDate = orders.OrderDate;
				ProductId = orders.ProductId;
				OrderDate = orders.OrderDate;
			}
		}
		public string OrderId { get; set; }
		public string CustomerName { get; set; }
		public string[] ProductId { get; set; }
		public DateTime OrderDate { get; set; }

	}
}