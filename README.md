# DAL (Data Access Layer)
Data Access Layer (DAL) library class # SqlDataAccess using Dapper(micro-ORMs) in C#.

You can create an instance of the SqlDataAccess class with the connection string and reuse it throughout your application without having to pass the connection string every time you call the LoadData or PersistData methods.

Below is # database bindings defined in the program.cs and # UserRepository class with examples of how to use the # SqlDataAccess class in DALLibrary above :


#Connection dependencies - NB: dont forget to include necessary libraries for each database type defined below

```C#
var connectionString = builder.Configuration.GetConnectionString("DBConnection");

var dbType = builder.Configuration.GetValue<string>("DatabaseType"); // e.g., "MySql", "SqlServer", "PostgreSql" defined in your appsettings.json like this { "DatabaseType": "MySql" }


///bind connectionString
builder.Services.AddDbContext<MeetingsDBContext>(options =>
{
    switch (dbType)
    {
        case "MySql":
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            break;
        case "SqlServer":
            options.UseSqlServer(connectionString);
            break;
        case "PostgreSql":
            options.UseNpgsql(connectionString);
            break;
        default:
            throw new NotSupportedException($"Database type '{dbType}' is not supported.");
    }
});

```

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

        public List<UserModel> GetAllUsers()
        {
            string sql = "SELECT * FROM Users";
            return _dataAccess.LoadData<UserModel, dynamic>(sql, new { });
        }

        public UserModel GetUserById(int id)
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

