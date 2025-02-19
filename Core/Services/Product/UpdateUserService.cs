using System.Collections.Generic;
using BusinessEntities;
using Common;

namespace Core.Services.Product
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateUserService : IUpdateProductService
    {
        public void Update(User user, string name, string email,int age, UserTypes type, decimal? annualSalary, IEnumerable<string> tags)
        {
            user.SetEmail(email);
            user.SetName(name);
            user.SetType(type);
            user.SetMonthlySalary(annualSalary.Value / 12);
            user.SetTags(tags);
			user.SetAge(age);
		}
    }
}