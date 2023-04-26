using Ranger_GigHub.Models;
using Microsoft.Data.SqlClient;

namespace Ranger_GigHub.Repositories
{
    public class EventRepository 
    {
        private readonly IConfiguration _config;

        public EventRepository(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public List<Event> GetAllEvents()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, VenueId, Event Name, EventDate
                    FROM Events
                    ";

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Event> events = new List<Event>();
                    while (reader.Read())
                    {
                        Event venueevent = new Event
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            VenueId = reader.GetInt32(reader.GetOrdinal("VenueId")),
                            EventName = reader.GetString(reader.GetOrdinal("EventName")),
                            EventDate = reader.GetDateTime(reader.GetOrdinal("EventDate")),
                        };

                        events.Add(venueevent);
                    }
                    reader.Close();

                    return events;
                }
            }
        }
    }
}
