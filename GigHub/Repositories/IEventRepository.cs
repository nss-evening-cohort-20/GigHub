using GigHub.Models;

namespace GigHub.Repositories
{
    public interface IEventRepository
    {
        List<Event> GetAllEvents();

        Event GetById(int id);

        void Add(Event venueevent);

        void Update(Event venueevent);

        void Delete(int id);
    }
}