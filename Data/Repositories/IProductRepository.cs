using System.Collections.Generic;
using BusinessEntities;

namespace Data.Repositories
{
    public interface IProductRepository 
    {
        IEnumerable<Products> Get();
        void DeleteAll();
    }
}