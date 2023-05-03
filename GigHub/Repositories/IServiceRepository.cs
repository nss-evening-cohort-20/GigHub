using GigHub.Models;

namespace GigHub.Repositories
{
    public interface IServiceRepository
    {
        void AddNewService(Service service);
        void DeleteService(int id);
        List<Service> GetAllServices();
        Service? GetServiceById(int id);
        void Update(Service service);
    }
}