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


        public List<Service> GetAllServices()
        {
            using (var conn = Connection) 
            {
                conn.Open(); 
                using (var cmd = conn.CreateCommand()) 
                {
                    cmd.CommandText = @"SELECT [id]
                                              ,[userRoleId]
                                              ,[serviceDescription]
                                              ,[serviceRate]
                                        FROM [GigHub].[dbo].[Service]"; 

                    using var reader = cmd.ExecuteReader(); 

                    var services = new List<Service>(); 

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

                }

            }

        }
    }
}
