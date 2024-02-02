# DAL
Data Access Layer (DAL) library class # SqlDataAccess using Dapper(micro-ORMs) in C#.

You can create an instance of the SqlDataAccess class with the connection string and reuse it throughout your application without having to pass the connection string every time you call the LoadData or PersistData methods.

Below is are examples of how to use the # SqlDataAccess class :


```C#

string connectionString = "your_connection_string_here";
SqlDataAccess sqlDataAccess = new SqlDataAccess(connectionString);

List<MyDataModel> data = sqlDataAccess.LoadData<MyDataModel, dynamic>("SELECT * FROM MyTable", null);
sqlDataAccess.PersistData("INSERT INTO MyTable (Column1, Column2) VALUES (@Column1, @Column2)", new { Column1 = "Value1", Column2 = "Value2" });
```

