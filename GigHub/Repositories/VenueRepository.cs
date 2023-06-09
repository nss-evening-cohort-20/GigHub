﻿using Azure.Identity;
using GigHub.Models;
using GigHub.Utils;
using Microsoft.Data.SqlClient;
using System.Buffers;

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
                                  ,u.UserRoleId
                             FROM Venue v
                             JOIN VenueToUser vt
                               ON v.id = vt.VenueId
                             JOIN [User] u
                               ON u.id = vt.UserId";

                    var reader = cmd.ExecuteReader();

                    var venues = new List<Venue>();

                    Venue? venue = null;

                    while (reader.Read())
                    {
                        if (venue == null || venue.Id != DbUtils.GetInt(reader, "VenueId"))
                        {
                            if (venue != null)
                            {
                                venues.Add(venue);
                            }

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
                        }

                        venue.Users.Add(new User()
                        {
                            Id = DbUtils.GetInt(reader, "UserId"),
                            UserName = DbUtils.GetString(reader, "userName"),
                            UserZipcode = DbUtils.GetInt(reader, "userZipcode"),
                            Email = DbUtils.GetString(reader, "email"),
                            Phone = DbUtils.GetString(reader, "phone"),
                            SocialMedia = DbUtils.GetString(reader, "socialMedia"),
                            UserRoleId = DbUtils.GetInt(reader, "UserRoleId")
                        });
                    }

                    if (venue != null)
                    {
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
                                  ,u.UserRoleId
                             FROM Venue v
                             JOIN VenueToUser vt
                               ON v.id = vt.VenueId
                             JOIN [User] u
                               ON u.id = vt.UserId
                            WHERE v.id = @id";
                    
                    cmd.Parameters.AddWithValue("@id", id);

                    var reader = cmd.ExecuteReader();

                    Venue venue = null;
                    
                    while (reader.Read())
                    {
                        if (venue == null)
                        {
                             venue = new Venue
                             {
                                    Id = DbUtils.GetInt(reader, "VenueId"),
                                    VenueName = DbUtils.GetString(reader, "venueName"),
                                    VenueZipcode = DbUtils.GetInt(reader, "venueZipcode"),
                                    VenueDescription = DbUtils.GetString(reader, "venueDescription"),
                                    Capacity = DbUtils.GetInt(reader, "capacity"),
                                    VenueRate = DbUtils.GetInt(reader, "venueRate"),
                                    Users = new List<User>()
                             };
                        }

                        if (DbUtils.IsNotDbNull(reader, "UserId"))
                        {
                            venue.Users.Add(new User()
                            {
                                Id = DbUtils.GetInt(reader, "UserId"),
                                UserName = DbUtils.GetString(reader, "userName"),
                                UserZipcode = DbUtils.GetInt(reader, "userZipcode"),
                                Email = DbUtils.GetString(reader, "email"),
                                Phone = DbUtils.GetString(reader, "phone"),
                                SocialMedia = DbUtils.GetString(reader, "socialMedia"),
                                UserRoleId = DbUtils.GetInt(reader, "UserRoleId")
                            });
                        }
                    }
                    reader.Close();
                    return venue;

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
                                  ,u.UserRoleId
                             FROM Venue v
                             JOIN VenueToUser vt
                               ON v.id = vt.VenueId
                             JOIN [User] u
                               ON u.id = vt.UserId
                            WHERE venueZipcode = @venueZipcode";
                    
                    cmd.Parameters.AddWithValue("@venueZipcode", zipcode);

                    var reader = cmd.ExecuteReader();

                    Venue venue = null;

                    while (reader.Read())
                    {
                        if (venue == null)
                        {
                            venue = new Venue
                            {
                                Id = DbUtils.GetInt(reader, "VenueId"),
                                VenueName = DbUtils.GetString(reader, "venueName"),
                                VenueZipcode = DbUtils.GetInt(reader, "venueZipcode"),
                                VenueDescription = DbUtils.GetString(reader, "venueDescription"),
                                Capacity = DbUtils.GetInt(reader, "capacity"),
                                VenueRate = DbUtils.GetInt(reader, "venueRate"),
                                Users = new List<User>()
                            };
                        }

                        if (DbUtils.IsNotDbNull(reader, "UserId"))
                        {
                            venue.Users.Add(new User()
                            {
                                Id = DbUtils.GetInt(reader, "UserId"),
                                UserName = DbUtils.GetString(reader, "userName"),
                                UserZipcode = DbUtils.GetInt(reader, "userZipcode"),
                                Email = DbUtils.GetString(reader, "email"),
                                Phone = DbUtils.GetString(reader, "phone"),
                                SocialMedia = DbUtils.GetString(reader, "socialMedia"),
                                UserRoleId = DbUtils.GetInt(reader, "UserRoleId")
                            });
                        }
                    }
                    reader.Close();
                    return venue;
                }
            }
        }

        public void Add(Venue venue)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    INSERT INTO Venue (venueName
                                      ,venueZipcode
                                      ,venueDescription
                                      ,capacity
                                      ,venueRate)
                   OUTPUT INSERTED.ID
                               VALUES (@VenueName
                                      ,@VenueZipcode
                                      ,@VenueDescription
                                      ,@Capacity
                                      ,@VenueRate)";

                    DbUtils.AddParameter(cmd, "@VenueName", venue.VenueName);
                    DbUtils.AddParameter(cmd, "@VenueZipcode", venue.VenueZipcode);
                    DbUtils.AddParameter(cmd, "@VenueDescription", venue.VenueDescription);
                    DbUtils.AddParameter(cmd, "@Capacity", venue.Capacity);
                    DbUtils.AddParameter(cmd, "@VenueRate", venue.VenueRate);

                    venue.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(Venue venue)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                UPDATE Venue
                                   SET venueName = @VenueName,
                                       venueZipcode = @VenueZipcode,
                                       venueDescription = @VenueDescription,
                                       capacity = @Capacity,
                                       venueRate = @VenueRate
                                 WHERE Id = @Id";

                    DbUtils.AddParameter(cmd, "@VenueName", venue.VenueName);
                    DbUtils.AddParameter(cmd, "@VenueZipcode", venue.VenueZipcode);
                    DbUtils.AddParameter(cmd, "@VenueDescription", venue.VenueDescription);
                    DbUtils.AddParameter(cmd, "@Capacity", venue.Capacity);
                    DbUtils.AddParameter(cmd, "@VenueRate", venue.VenueRate);
                    DbUtils.AddParameter(cmd, "@Id", venue.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                         DELETE FROM VenueToUser
                               WHERE VenueId = @id
                         DELETE FROM Venue
                               WHERE id = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
