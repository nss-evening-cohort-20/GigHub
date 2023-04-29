using GigHub.Models;

namespace GigHub.Repositories
{
    public interface IServiceRepository
    {
        List<Service> GetAllServices();
        Service? GetServiceById(int id);
    }
}