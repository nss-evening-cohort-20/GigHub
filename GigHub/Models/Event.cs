namespace GigHub.Models
{
    public class Event
    {
        public int Id { get; set; }

        public int VenueId { get; set; }

        public string eventName { get; set; }

        public DateTime eventDate { get; set; }

        public Venue Venue { get; set; }
    }
}

