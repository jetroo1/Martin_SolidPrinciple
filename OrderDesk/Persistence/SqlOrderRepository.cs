using Microsoft.Data.SqlClient;
using OrderDesk.Models;

namespace OrderDesk.Persistence;

// The SQL that used to sit inside btnSaveOrder_Click.
// Note the `using` blocks - the original leaked the connection
// whenever ExecuteNonQuery threw, because conn.Close() never ran.
public class SqlOrderRepository : IOrderRepository
{
    private readonly string connectionString;

    public SqlOrderRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void Save(Order order)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand("INSERT INTO Orders (Email, Total) VALUES(@e, @t)", conn))
            {
                cmd.Parameters.AddWithValue("@e", order.CustomerEmail);
                cmd.Parameters.AddWithValue("@t", order.Total);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
