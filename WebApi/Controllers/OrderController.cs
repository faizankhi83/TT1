using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using WebApi.Models.Order;


namespace WebApi.Controllers
{
    [RoutePrefix("orders")]
    public class OrdersController : BaseApiController
    {
		private static List<Orders> orderlist = new List<Orders>();
		public OrdersController()
        {
			
		}

		[Route("{orderId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateOrder(Guid orderId, [FromBody] OrderModel model)
        {
            Orders order = new Orders();
			order.OrderId = orderId.ToString();
			order.CustomerName = model.CustomerName;
			order.OrderDate=model.OrderDate;
			order.ProductId = model.ProductId;
			orderlist.Add(order);
			return Found(new OrdersData(order));
        }

        [Route("{orderId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateOrder(Guid orderId, [FromBody] OrderModel model)
        {
			var orderToUpdate = orderlist.FirstOrDefault(p => p.OrderId == orderId.ToString());
			if (orderToUpdate != null)
			{
				// Update properties
				orderToUpdate.CustomerName = model.CustomerName;
				orderToUpdate.ProductId = model.ProductId;
				orderToUpdate.OrderDate = model.OrderDate;
			}

			return Found(new OrdersData(orderToUpdate));

		}

        [Route("{orderId:guid}/deletebyid")]
        [HttpDelete]
        public HttpResponseMessage DeleteOrder(Guid orderId)
        {
			var orderToDelete = orderlist.FirstOrDefault(p => p.OrderId == orderId.ToString());
			orderlist.Remove(orderToDelete);
			return Found();
        }

        [Route("{orderId:guid}/getorderbyid")]
        [HttpGet]
        public HttpResponseMessage GetOrderbyId(Guid orderId)
        {
			var order = orderlist.FirstOrDefault(p => p.OrderId == orderId.ToString());
			return Found(order);
		}

		[Route("list")]
		[HttpGet]
		public HttpResponseMessage GetOrders()
		{
			return Found(orderlist.ToList());
		}

		[Route("clear")]
		[HttpDelete]
		public HttpResponseMessage DeleteAllOrders()
		{
			orderlist.Clear();
			return Found();
		}

	}
}