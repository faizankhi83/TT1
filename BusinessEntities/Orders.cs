using System;
using System.Collections.Generic;
using Common.Extensions;

namespace BusinessEntities
{
    public class Orders 
    {
		private string _id;
		private string _customername;
		private DateTime _date;
		private string[] _productid;
		public string OrderId
		{
			get => _id;
			set => _id = value;
		}

		public string CustomerName
        {
            get => _customername;
            set => _customername = value;
        }

        public DateTime OrderDate
        {
            get => _date;
            set => _date = value;
        }

		public string[] ProductId
		{
			get => _productid;
			set => _productid = value;
		}
	}
}