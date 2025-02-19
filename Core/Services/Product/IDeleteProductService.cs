using BusinessEntities;

namespace Core.Services.Product
{
    public interface IDeleteProductService
    {
        void Delete(User user);
        void DeleteAll();
    }
}