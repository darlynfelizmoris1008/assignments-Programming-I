namespace manuahorros.data
{
    public static class DbConnectionFactory
    {
        private const string ConnectionString =
            "Server=LEANDRO\\SQLEXPRESS;Database=ManuAhorrosDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public static IDbConnection CreateOpenConnection()
        {
            try
            {
                var connection = new SqlConnection(ConnectionString);
                connection.Open();
                return connection;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Connection Error:");
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error while opening DB connection:");
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
