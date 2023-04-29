using GigHub.Models;
using System;

namespace GigHub.Repositories
{
    public interface IVenueRepository
    {
        List<Venue> GetAllVenues();
        Venue GetById(int id);
        Venue GetByZipcode(int zipcode);
        void Add(Venue venue);
        void Update(Venue venue);
        void Delete(int id);
    }
}