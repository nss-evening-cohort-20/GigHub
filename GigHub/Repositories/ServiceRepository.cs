using GigHub.Models;
using GigHub.Utils;
using Microsoft.Data.SqlClient;
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

        // 2. GetById
        // 3. GetByName
        // 4. Create
        // 5. Update
        // 6. Delete

        public Service? GetServiceById(int id)
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
                                        FROM [GigHub].[dbo].[Service]
                                        where [id] = @id";

                    cmd.Parameters.AddWithValue("@id", id); // if you have a "where" parameter then use this line

                    using var reader = cmd.ExecuteReader();

                    Service? service = null; // this holds your results

                    if (reader.Read())
                    {
                        service = new Service()
                        {
                            Id = DbUtils.GetInt(reader, "id"),
                            UserRoleId = DbUtils.GetInt(reader, "userRoleId"),
                            ServiceDescription = DbUtils.GetString(reader, "serviceDescription"),
                            ServiceRate = DbUtils.GetInt(reader, "serviceRate"),
                        };

                    }

                    return service;

                }

            }





        }

        // GET BY SERVICE DESCRIPTION

        public List<Service> GetServiceByDescription(string description)
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
                                        FROM [GigHub].[dbo].[Service]
                                        where [serviceDescription] = @serviceDescription";

                    cmd.Parameters.AddWithValue("@serviceDescription", description); 

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


        //public void CreateNewService(Service service)
        //{

        //    how to create a POST
        // 1.create and open a connection
        // 2.create a command
        // 3.provide SQL
        // 4.provide parameters
        // 5.execute SQL
        // 6.Optional = return something to indicate success

        //}



    }
}
