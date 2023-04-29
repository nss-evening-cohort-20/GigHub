namespace Ranger_GigHub.Models
{
    public class Event
    {
        public int Id { get; set; }

        public int VenueId { get; set; }

        public string EventName { get; set; }

        public DateTime EventDate { get; set; }
    }
}

