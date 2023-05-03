using Microsoft.Extensions.Hosting;
using GigHub.Models;
using GigHub.Utils;



namespace GigHub.Repositories
{
    public class EventRepository : BaseRepository, IEventRepository
    {
        public EventRepository(IConfiguration configuration) : base(configuration) { }

        public List<Event> GetAllEvents()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    SELECT e.Id AS EventId
                           ,e.VenueId 
                           ,e.eventName 
                           ,e.eventDate
                           ,v.venueName
                           ,v.venueZipcode
                    FROM Event e
                           LEFT JOIN Venue v ON e.VenueId = v.id
                    ORDER BY eventDate
                    ";

                    var reader = cmd.ExecuteReader();

                    var events = new List<Event>();
                    
                    while (reader.Read())
                    {
                        events.Add(new Event()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("EventId")),
                            VenueId = reader.GetInt32(reader.GetOrdinal("VenueId")),
                            eventName = reader.GetString(reader.GetOrdinal("eventName")),
                            eventDate = reader.GetDateTime(reader.GetOrdinal("eventDate")),
                            Venue = new Venue()
                            {
                                VenueName = DbUtils.GetString(reader, "venueName"),
                            }
                        });
                    }
                    reader.Close();

                    return events;
                }
            }
        }
        public Event GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    SELECT e.Id AS EventId
                           ,e.VenueId 
                           ,e.eventName 
                           ,e.eventDate
                           ,v.venueName
                           ,v.venueZipcode
                    FROM Event e
                           LEFT JOIN Venue v ON e.VenueId = v.id
                    ORDER BY eventDate
                    ";

                    DbUtils.AddParameter(cmd, "@Id", id);

                    var reader = cmd.ExecuteReader();

                    Event venueevent = null;
                    if (reader.Read())
                    {
                        venueevent = new Event()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("EventId")),
                            VenueId = reader.GetInt32(reader.GetOrdinal("VenueId")),
                            eventName = reader.GetString(reader.GetOrdinal("eventName")),
                            eventDate = reader.GetDateTime(reader.GetOrdinal("eventDate")),
                            Venue = new Venue()
                            {
                                VenueName = DbUtils.GetString(reader, "venueName"),
                            },
                        };
                    }

                    reader.Close();

                    return venueevent;
                }
            }
        }

        public void Add(Event venueevent)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                     INSERT INTO Event (VenueId, eventName, eventDate)
                     OUTPUT INSERTED.ID
                     VALUES (@VenueId, @eventName, @eventDate)
                    ";

                    DbUtils.AddParameter(cmd, "@VenueId", venueevent.VenueId);
                    DbUtils.AddParameter(cmd, "@eventName", venueevent.eventName);
                    DbUtils.AddParameter(cmd, "@eventDate", venueevent.eventDate);

                    venueevent.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(Event venueevent)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE Event
                        SET VenueId = @VenueId,
                            eventName = @eventName,
                            eventDate = @eventDate
                        WHERE Id = @Id
                    ";

                    DbUtils.AddParameter(cmd, "@VenueId", venueevent.VenueId);
                    DbUtils.AddParameter(cmd, "@eventName", venueevent.eventName);
                    DbUtils.AddParameter(cmd, "@eventDate", venueevent.eventDate);
                    DbUtils.AddParameter(cmd, "@Id", venueevent.Id);

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
                    cmd.CommandText = "DELETE FROM Event WHERE Id = @Id";

                    DbUtils.AddParameter(cmd, "@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
