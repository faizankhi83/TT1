using System.Collections.Generic;
using System.Linq;
using BusinessEntities;
using Common;
using Data.Indexes;
using Raven.Client;

namespace Data.Repositories
{
    //[AutoRegister]
    //public class ProductRepository : Repository<Products>, IProductRepository
    //{
    //    private readonly IDocumentSession _documentSession;

    //    public ProductRepository(IDocumentSession documentSession) : base(documentSession)
    //    {
    //        _documentSession = documentSession;
    //    }

    //    public IEnumerable<Products> Get()
    //    {
    //        var query = _documentSession.Advanced.DocumentQuery<Products>();

    //        var hasFirstParameter = false;
			
    //        return query.ToList();
    //    }

    //    public void DeleteAll()
    //    {
    //        //base.DeleteAll<ProductListIndex>();
    //    }
    //}
}