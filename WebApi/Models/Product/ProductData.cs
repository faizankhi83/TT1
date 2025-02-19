using BusinessEntities;

namespace WebApi.Models.Product
{
    public class ProductData 
    {
        public ProductData(Products product) 
        {
			if (product != null)
			{
				ProductId = product.ProductId;
				ProductCode = product.ProductCode;
				ProductName = product.ProductName;
				ProductDesc = product.ProductDesc;
			}
		}
		public string ProductId { get; set; }
		public string ProductCode { get; set; }
        public string ProductName { get; set; }
		public string ProductDesc { get; set; }

	}
}