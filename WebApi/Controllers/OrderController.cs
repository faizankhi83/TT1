using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using Data.Repositories;
using WebApi.Models.Order;
using WebApi.Models.Product;

namespace WebApi.Controllers
{
    [RoutePrefix("orders")]
    public class OrdersController : BaseApiController
    {
		IOrderRepository orderRepository = new OrderRepository();

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
			orderRepository.AddOrder(order);
			return Found(new OrdersData(order));

		}

        [Route("{orderId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateOrder(Guid orderId, [FromBody] OrderModel model)
        {
			Orders order = new Orders();
			order.OrderId = orderId.ToString();
			order.CustomerName = model.CustomerName;
			order.OrderDate = model.OrderDate;
			order.ProductId = model.ProductId;
			orderRepository.UpdateOrder(order);
			return Found(new OrdersData(order));

		}

        [Route("{orderId:guid}/deletebyid")]
        [HttpDelete]
        public HttpResponseMessage DeleteOrder(Guid orderId)
        {
			orderRepository.DeleteOrderbyId(orderId.ToString());
			return Found();
		}

		[Route("clear")]
		[HttpDelete]
		public HttpResponseMessage DeleteAllOrders()
		{
			orderRepository.DeleteAllOrder();
			return Found();
		}

		[Route("{orderId:guid}/getorderbyid")]
        [HttpGet]
        public HttpResponseMessage GetOrderbyId(Guid orderId)
        {
			var order = orderRepository.GetOrderById(orderId.ToString());
			return Found(order);

		}

		[Route("list")]
		[HttpGet]
		public HttpResponseMessage GetOrders()
		{
			var order = orderRepository.GetAllOrder();
			return Found(order);
		}

		

	}
}