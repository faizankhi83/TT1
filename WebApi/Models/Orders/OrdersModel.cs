using System;
using System.Collections.Generic;
using BusinessEntities;

namespace WebApi.Models.Order
{
    public class OrderModel
	{
		public string OrderId { get; set; }
		public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
		public string[] ProductId { get; set; }

	}
}