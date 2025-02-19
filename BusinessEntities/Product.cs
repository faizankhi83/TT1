using System;
using System.Collections.Generic;
using Common.Extensions;

namespace BusinessEntities
{
    public class Products 
    {
		private string _id;
		private string _code;
		private string _name;
		private string _desc;

		public string ProductId
		{
			get => _id;
			set => _id = value;
		}

		public string ProductCode
        {
            get => _code;
            set => _code = value;
        }

        public string ProductName
        {
            get => _name;
            set => _name = value;
        }

		public string ProductDesc
		{
			get => _desc;
			set => _desc = value;
		}

		public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name was not provided.");
            }
            _name = name;
        }

        public void SetCode(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException("code was not provided.");
            }
			_code = code;
        }

        public void SetDesc(string desc)
        {
            _desc = desc;
        }
		
	}
}