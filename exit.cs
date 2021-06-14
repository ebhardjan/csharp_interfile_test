using System.Data;
using System.Data.SqlClient;

public class BadSink
{
    public void bad_sink(string queryParam)
    {
        var sqlString = "SELECT * FROM Products WHERE CategoryID = " + queryParam;
        using (var conn = new SqlConnection("connString"))
        {
            var command = new SqlCommand(sqlString, conn);
            command.ExecuteReader();
        }
    }
}

public class SanitizedSink
{
    public static void sanitized_sink(string queryParam)
    {
        var sqlString = "SELECT * FROM Products WHERE CategoryID = @CategoryID";
        using (var conn = new SqlConnection("connString"))
        {
            var command = new SqlCommand(sqlString, conn);
            command.Parameters.Add("@CategoryID", SqlDbType.Int).Value = queryParam;
            command.ExecuteReader();
        }
    }
}