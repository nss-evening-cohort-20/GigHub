using GigHub.Models;
using GigHub.Utils;
using System.Security.Cryptography;

namespace GigHub.Repositories
{
    public class ServiceRepository : BaseRepository, IServiceRepository
    {
        public ServiceRepository(IConfiguration configuration) : base(configuration)
        {
        }

        // 1. GetAll
        // Create and open a connection
        // Create your command
        // Command text
        // Command parameters if needed
        // Execute SQL
        // Handle results

        public List<Service> GetAllServices()
        {
            using (var conn = Connection) // this creates the connection
            {
                conn.Open(); // this opens the connection 
                using (var cmd = conn.CreateCommand()) // this is command text
                {
                    cmd.CommandText = @"SELECT [id]
                                              ,[userRoleId]
                                              ,[serviceDescription]
                                              ,[serviceRate]
                                        FROM [GigHub].[dbo].[Service]"; // this is the command

                    using var reader = cmd.ExecuteReader(); // this executes SQL

                    var services = new List<Service>(); // this will hold the results

                    while (reader.Read())
                    {
                        var service = new Service()
                        {
                            Id = DbUtils.GetInt(reader, "id"),
                            UserRoleId = DbUtils.GetInt(reader, "userRoleId"),
                            ServiceDescription = DbUtils.GetString(reader, "serviceDescription"),
                            ServiceRate = DbUtils.GetInt(reader, "serviceRate"),
                        };
                        services.Add(service);

                    }

                    return services;
                    //we do not have to include conn.Close() as we are utilized "USING VAR READER" when executing SQL

                }

            }

        }




        // 2. GetById
        // 3. GetByName
        // 4. Create
        // 5. Update
        // 6. Delete





    }
}
