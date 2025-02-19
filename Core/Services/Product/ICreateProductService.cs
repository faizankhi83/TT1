using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Product
{
    public interface ICreateProductService
    {
		Products Create(Guid id, string name, string email, int age, UserTypes type, decimal? annualSalary, IEnumerable<string> tags);
    }
}