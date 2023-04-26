using Azure.Identity;
using GigHub.Models;
using GigHub.Utils;
using Microsoft.Data.SqlClient;

namespace GigHub.Repositories
{
    public class VenueRepository : BaseRepository, IVenueRepository
    {
        public VenueRepository(IConfiguration configuration) : base(configuration) { }
        public List<Venue> GetAllVenues()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                            SELECT v.id AS VenueId
                                  ,v.venueName
                                  ,v.venueZipcode
                                  ,v.venueDescription
                                  ,v.capacity
                                  ,v.venueRate
                                  ,u.id AS UserId
                                  ,u.userName
                                  ,u.userZipcode
                                  ,u.email
                                  ,u.phone
                                  ,u.socialMedia
                             FROM Venue v
                             JOIN VenueToUser vt
                               ON v.id = vt.VenueId
                             JOIN [User] u
                               ON u.id = vt.UserId
                            ";

                    var reader = cmd.ExecuteReader();

                    var venues = new List<Venue>();

                    var user = new User();

                    while (reader.Read())
                    {
                        var venue = new Venue()
                        {
                            Id = DbUtils.GetInt(reader, "VenueId"),
                            VenueName = DbUtils.GetString(reader, "venueName"),
                            VenueZipcode = DbUtils.GetInt(reader, "venueZipcode"),
                            VenueDescription = DbUtils.GetString(reader, "venueDescription"),
                            Capacity = DbUtils.GetInt(reader, "capacity"),
                            VenueRate = DbUtils.GetInt(reader, "venueRate"),
                            Users = new List<User>()
                        };

                        if (DbUtils.IsNotDbNull(reader, "UserId"))
                        {
                            var userTableId = DbUtils.GetInt(reader, "UserId");
                            var existingUser = venue.Users.FirstOrDefault(e => e.Id == userTableId);

                            if (existingUser == null)
                            {
                                venue.Users.Add(new User()
                                {
                                    Id = DbUtils.GetInt(reader, "UserId"),
                                    UserName = DbUtils.GetString(reader, "userName"),
                                    UserZipcode = DbUtils.GetInt(reader, "userZipcode"),
                                    Email = DbUtils.GetString(reader, "email"),
                                    Phone = DbUtils.GetString(reader, "phone"),
                                    SocialMedia = DbUtils.GetString(reader, "socialMedia")
                                });
                            }
                        }

                        venues.Add(venue);
                    }
                    conn.Close();
                    return venues;
                }
            }
        }

        public Venue GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                            SELECT v.id AS VenueId
                                  ,v.venueName
                                  ,v.venueZipcode
                                  ,v.venueDescription
                                  ,v.capacity
                                  ,v.venueRate
                                  ,u.id AS UserId
                                  ,u.userName
                                  ,u.userZipcode
                                  ,u.email
                                  ,u.phone
                                  ,u.socialMedia
                             FROM Venue v
                             JOIN VenueToUser vt
                               ON v.id = vt.VenueId
                             JOIN [User] u
                               ON u.id = vt.UserId
                            WHERE v.id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        Venue venue = null;
                        if (reader.Read())
                        {
                            venue = new Venue()
                            {
                                Id = DbUtils.GetInt(reader, "VenueId"),
                                VenueName = DbUtils.GetString(reader, "venueName"),
                                VenueZipcode = DbUtils.GetInt(reader, "venueZipcode"),
                                VenueDescription = DbUtils.GetString(reader, "venueDescription"),
                                Capacity = DbUtils.GetInt(reader, "capacity"),
                                VenueRate = DbUtils.GetInt(reader, "venueRate"),
                                Users = new List<User>()
                            };

                            if (DbUtils.IsNotDbNull(reader, "UserId"))
                            {
                                var userTableId = DbUtils.GetInt(reader, "UserId");
                                var existingUser = venue.Users.FirstOrDefault(e => e.Id == userTableId);

                                if (existingUser == null)
                                {
                                    venue.Users.Add(new User()
                                    {
                                        Id = DbUtils.GetInt(reader, "UserId"),
                                        UserName = DbUtils.GetString(reader, "userName"),
                                        UserZipcode = DbUtils.GetInt(reader, "userZipcode"),
                                        Email = DbUtils.GetString(reader, "email"),
                                        Phone = DbUtils.GetString(reader, "phone"),
                                        SocialMedia = DbUtils.GetString(reader, "socialMedia")
                                    });
                                }
                            }

                        }
                        reader.Close();

                        return venue;
                    }
                }
            }
        }

        public Venue GetByZipcode(int zipcode)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                            SELECT id AS VenueId
                                  ,venueName
                                  ,venueZipcode
                                  ,venueDescription
                                  ,capacity
                                  ,venueRate
                             FROM Venue
                            WHERE venueZipcode = @venueZipcode";
                    cmd.Parameters.AddWithValue("@venueZipcode", zipcode);

                    using (var reader = cmd.ExecuteReader())
                    {
                        Venue venue = null;
                        if (reader.Read())
                        {
                            venue = new Venue()
                            {
                                Id = DbUtils.GetInt(reader, "VenueId"),
                                VenueName = DbUtils.GetString(reader, "venueName"),
                                VenueZipcode = DbUtils.GetInt(reader, "venueZipcode"),
                                VenueDescription = DbUtils.GetString(reader, "venueDescription"),
                                Capacity = DbUtils.GetInt(reader, "capacity"),
                                VenueRate = DbUtils.GetInt(reader, "venueRate"),
                            };
                        }
                        reader.Close();

                        return venue;
                    }
                }
            }
        }
    }
}
