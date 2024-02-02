# DAL
Data Access Layer (DAL) library class # SqlDataAccess using Dapper(micro-ORMs) in C#.

You can create an instance of the SqlDataAccess class with the connection string and reuse it throughout your application without having to pass the connection string every time you call the LoadData or PersistData methods.

Below is are examples of how to use the # SqlDataAccess class :


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
            return _dataAccess.LoadData<User, dynamic>(sql, new { });
        }

        public User GetUserById(int id)
        {
            string sql = "SELECT * FROM Users WHERE Id = @Id";
            return _dataAccess.LoadData<User, dynamic>(sql, new { Id = id }).FirstOrDefault();
        }

        public void InsertUser(User user)
        {
            string sql = "INSERT INTO Users (Name, Email) VALUES (@Name, @Email)";
            _dataAccess.PersistData(sql, user);
        }

        public void UpdateUser(User user)
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

