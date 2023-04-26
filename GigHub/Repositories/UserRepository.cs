using GigHub.Models;
using GigHub.Utils;

namespace GigHub.Repositories
{
    public class UserRepository : BaseRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration) { }

        public List<User> GetAllUsers()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    SELECT id, FirebaseUid, userName, userZipcode, email, phone, socialMedia, UserRoleId 
                    FROM [User]";

                    var reader = cmd.ExecuteReader();

                    var users = new List<User>();

                    while (reader.Read())
                    {
                        var user = new User()
                        {
                            Id = DbUtils.GetInt(reader, "id"),
                            FirebaseUid = null,
                            UserName = DbUtils.GetString(reader, "userName"),
                            UserZipcode = DbUtils.GetInt(reader, "userZipcode"),
                            Email = DbUtils.GetString(reader, "email"),
                            Phone = DbUtils.GetString(reader, "phone"),
                            SocialMedia = DbUtils.GetString(reader, "socialMedia"),
                            UserRoleId = DbUtils.GetInt(reader, "UserRoleId")
                        };

                        if (DbUtils.IsNotDbNull(reader, "FirebaseUid"))
                        {
                            user.FirebaseUid = DbUtils.GetString(reader, "FirebaseUid");
                        };

                        users.Add(user);
                    }
                    conn.Close();
                    return users;
                }
            }
        }
    }
}
