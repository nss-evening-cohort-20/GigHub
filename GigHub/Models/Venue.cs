using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class Venue
    {
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string VenueName { get; set; }

        [Required]
        public int VenueZipcode { get; set; }

        [StringLength(255)]
        public string? VenueDescription { get; set; }

        public int Capacity { get; set; }

        public int VenueRate { get; set; }

        public List<User> Users { get; set; }
    }
}
