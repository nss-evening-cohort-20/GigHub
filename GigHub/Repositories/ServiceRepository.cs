using GigHub.Models;
using GigHub.Utils;
using Microsoft.Data.SqlClient;
using System;
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


        public void AddNewService(Service service)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    INSERT INTO Service ([userRoleId]
                                        ,[serviceDescription]
                                        ,[serviceRate])
                    OUTPUT INSERTED.ID 
                    VALUES              (@userRoleId
                                        ,@serviceDescription
                                        ,@serviceRate)"
                    ;

                    DbUtils.AddParameter(cmd, "@userRoleId", service.UserRoleId);
                    DbUtils.AddParameter(cmd, "@serviceDescription", service.ServiceDescription);
                    DbUtils.AddParameter(cmd, "@serviceRate", service.ServiceRate);
                    
                    service.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void DeleteService(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Service WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }





    }
}
