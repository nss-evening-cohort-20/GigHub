using GigHub.Models;
using GigHub.Utils;

namespace GigHub.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
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
                            FirebaseUid = DbUtils.GetNullableString(reader, "FirebaseUid"),
                            UserName = DbUtils.GetString(reader, "userName"),
                            UserZipcode = DbUtils.GetInt(reader, "userZipcode"),
                            Email = DbUtils.GetString(reader, "email"),
                            Phone = DbUtils.GetString(reader, "phone"),
                            SocialMedia = DbUtils.GetString(reader, "socialMedia"),
                            UserRoleId = DbUtils.GetInt(reader, "UserRoleId")
                        };

                        users.Add(user);
                    }
                    conn.Close();
                    return users;
                }
            }
        }
        public User GetUserById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    SELECT id, FirebaseUid, userName, userZipcode, email, phone, socialMedia, UserRoleId 
                    FROM [User]
                    WHERE id = @id";

                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();
                    User user = null;
                    while (reader.Read())
                    {
                        user = new User()
                        {
                            Id = DbUtils.GetInt(reader, "id"),
                            FirebaseUid = DbUtils.GetNullableString(reader, "FirebaseUid"),
                            UserName = DbUtils.GetString(reader, "userName"),
                            UserZipcode = DbUtils.GetInt(reader, "userZipcode"),
                            Email = DbUtils.GetString(reader, "email"),
                            Phone = DbUtils.GetString(reader, "phone"),
                            SocialMedia = DbUtils.GetString(reader, "socialMedia"),
                            UserRoleId = DbUtils.GetInt(reader, "UserRoleId")
                        };

                    }
                    conn.Close();
                    return user;
                }
            }
        }

        public void Insert(User user)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    INSERT INTO [User]
                    (FirebaseUid, userName, userZipcode, email, phone, socialMedia, UserRoleId)
                    OUTPUT INSERTED.Id
                    VALUES (@FirebaseUid, @userName, @userZipcode, @email, @phone, @socialMedia, @UserRoleId)";

                    cmd.Parameters.AddWithValue("@FirebaseUid", user.FirebaseUid);
                    cmd.Parameters.AddWithValue("@userName", user.UserName);
                    cmd.Parameters.AddWithValue("@userZipcode", user.UserZipcode);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@phone", user.Phone);
                    cmd.Parameters.AddWithValue("@socialMedia", user.SocialMedia);
                    cmd.Parameters.AddWithValue("@UserRoleId", user.UserRoleId);

                    user.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(User user)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    UPDATE [User]
                    SET FirebaseUid = @FirebaseUid, 
                        userName = @userName,
                        userZipcode = @userZipcode, 
                        email = @email,
                        phone = @phone,
                        socialMedia = @socialMedia,
                        UserRoleId = @UserRoleId
                    WHERE Id = @Id";

                    DbUtils.AddParameter(cmd, "@Id", user.Id);
                    DbUtils.AddParameter(cmd, "@FirebaseUid", user.FirebaseUid);
                    DbUtils.AddParameter(cmd, "@userName", user.UserName);
                    DbUtils.AddParameter(cmd, "@userZipcode", user.UserZipcode);
                    DbUtils.AddParameter(cmd, "@email", user.Email);
                    DbUtils.AddParameter(cmd, "@phone", user.Phone);
                    DbUtils.AddParameter(cmd, "@socialMedia", user.SocialMedia);
                    DbUtils.AddParameter(cmd, "@UserRoleId", user.UserRoleId);

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
                    cmd.CommandText = "DELETE FROM [User] WHERE Id = @Id";
                    DbUtils.AddParameter(cmd, "@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
