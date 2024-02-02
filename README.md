# DAL
Data Access Layer (DAL) library class # SqlDataAccess using Dapper(micro-ORMs) in C#.

You can create an instance of the SqlDataAccess class with the connection string and reuse it throughout your application without having to pass the connection string every time you call the LoadData or PersistData methods.

Below is a # UserRepository class with examples of how to use the # SqlDataAccess class in DALLibrary above :


# Without Relationship with other tables
```C#

using DALLibrary;

namespace DataAccessExample
{

    public class UserRepository
    {
        private readonly SqlDataAccess _dataAccess;

        public UserRepository(string connectionString)
        {
            _dataAccess = new SqlDataAccess(connectionString);
        }

        public List<User> GetAllUsers()
        {
            string sql = "SELECT * FROM Users";
            return _dataAccess.LoadData<UserModel, dynamic>(sql, new { });
        }

        public User GetUserById(int id)
        {
            string sql = "SELECT * FROM Users WHERE Id = @Id";
            return _dataAccess.LoadData<UserModel, dynamic>(sql, new { Id = id }).FirstOrDefault();
        }

        public void InsertUser(UserModel user)
        {
            string sql = "INSERT INTO Users (Name, Email) VALUES (@Name, @Email)";
            _dataAccess.PersistData(sql, user);
        }

        public void UpdateUser(UserModel user)
        {
            string sql = "UPDATE Users SET Name = @Name, Email = @Email WHERE Id = @Id";
            _dataAccess.PersistData(sql, user);
        }

        public void DeleteUser(int id)
        {
            string sql = "DELETE FROM Users WHERE Id = @Id";
            _dataAccess.PersistData(sql, new { Id = id });
        }
    }
}

```

