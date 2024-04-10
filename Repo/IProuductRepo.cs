
using backendtask.Model;

namespace backendtask.Repo
{
    public interface IProductRepo
    {
        Task<List<Product>> GetAll();
        Task<Product?> Getbycode(int ProductID);
        Task<string> Create(Product Entry);
        Task<string> Update(Product Entry, int ProductID);
        Task<string> Remove(int ProductID);
        // public string insert(Product Entry);
    }
}
