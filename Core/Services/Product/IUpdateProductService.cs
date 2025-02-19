using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Product
{
    public interface IUpdateProductService
    {
        void Update(User user, string name, string email,int age, UserTypes type, decimal? annualSalary, IEnumerable<string> tags);
    }
}