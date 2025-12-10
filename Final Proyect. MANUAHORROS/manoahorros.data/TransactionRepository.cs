using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using manuahorros.D;

namespace manuahorros.data
{
    public class TransactionRepository
    {
        public int Add(Transaction transaction)
        {
            try
            {
                if (!transaction.AccountId.HasValue)
                {
                    Console.WriteLine("TransactionRepository.Add: AccountId is required to save a transaction.");
                    return -1;
                }

                using var connection = DbConnectionFactory.CreateOpenConnection();
                using var command = connection.CreateCommand();

                command.CommandText = @"
                    INSERT INTO Transactions (
                        AccountId,
                        LoanId,
                        Date,
                        Type,
                        Amount,
                        Description,
                        CreatedAt
                    )
                    VALUES (
                        @AccountId,
                        @LoanId,
                        @Date,
                        @Type,
                        @Amount,
                        @Description,
                        @CreatedAt
                    );
                    SELECT CAST(SCOPE_IDENTITY() AS INT);
                ";

                AddParam(command, "@AccountId", transaction.AccountId.Value);

                AddParam(command, "@LoanId",
                    transaction.LoanId.HasValue && transaction.LoanId.Value > 0
                        ? transaction.LoanId.Value
                        : DBNull.Value);

                AddParam(command, "@Date", transaction.Date);
                AddParam(command, "@Type", (int)transaction.Type);
                AddParam(command, "@Amount", transaction.Amount);

                AddParam(command, "@Description",
                    string.IsNullOrWhiteSpace(transaction.Description)
                        ? DBNull.Value
                        : transaction.Description);

                AddParam(command, "@CreatedAt", transaction.CreatedAt);

                var result = command.ExecuteScalar();
                var newId = (int)(result ?? 0);

                typeof(BaseEntity)
                    .GetProperty(nameof(BaseEntity.Id))!
                    .SetValue(transaction, newId);

                return newId;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error in TransactionRepository.Add:");
                Console.WriteLine(ex.Message);
                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error in TransactionRepository.Add:");
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public List<Transaction> GetByAccountId(int accountId)
        {
            var transactions = new List<Transaction>();

            try
            {
                using var connection = DbConnectionFactory.CreateOpenConnection();
                using var command = connection.CreateCommand();

                command.CommandText = @"
                    SELECT
                        Id,
                        AccountId,
                        LoanId,
                        Date,
                        Type,
                        Amount,
                        Description,
                        CreatedAt
                    FROM Transactions
                    WHERE AccountId = @AccountId
                    ORDER BY Date ASC, Id ASC;
                ";

                AddParam(command, "@AccountId", accountId);

                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    transactions.Add(MapTransaction(reader));
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error in TransactionRepository.GetByAccountId:");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error in TransactionRepository.GetByAccountId:");
                Console.WriteLine(ex.Message);
            }

            return transactions;
        }

        public List<Transaction> GetAll()
        {
            var transactions = new List<Transaction>();

            try
            {
                using var connection = DbConnectionFactory.CreateOpenConnection();
                using var command = connection.CreateCommand();

                command.CommandText = @"
                    SELECT
                        Id,
                        AccountId,
                        LoanId,
                        Date,
                        Type,
                        Amount,
                        Description,
                        CreatedAt
                    FROM Transactions
                    ORDER BY Date ASC, Id ASC;
                ";

                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    transactions.Add(MapTransaction(reader));
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error in TransactionRepository.GetAll:");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error in TransactionRepository.GetAll:");
                Console.WriteLine(ex.Message);
            }

            return transactions;
        }
        public bool Delete(int id)
        {
            try
            {
                using var connection = DbConnectionFactory.CreateOpenConnection();
                using var command = connection.CreateCommand();

                command.CommandText = @"
                    DELETE FROM Transactions
                    WHERE Id = @Id;
                ";

                AddParam(command, "@Id", id);

                var rows = command.ExecuteNonQuery();
                return rows > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error in TransactionRepository.Delete:");
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error in TransactionRepository.Delete:");
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private static void AddParam(IDbCommand command, string name, object? value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value ?? DBNull.Value;
            command.Parameters.Add(parameter);
        }

        private static Transaction MapTransaction(IDataRecord record)
        {
            var tx = new Transaction
            {
                AccountId = record.GetInt32(record.GetOrdinal("AccountId")),
                Date = record.GetDateTime(record.GetOrdinal("Date")),
                Type = (TransactionType)record.GetInt32(record.GetOrdinal("Type")),
                Amount = record.GetDecimal(record.GetOrdinal("Amount")),
                Description = record.IsDBNull(record.GetOrdinal("Description"))
                    ? string.Empty
                    : record.GetString(record.GetOrdinal("Description"))
            };

            if (!record.IsDBNull(record.GetOrdinal("LoanId")))
            {
                tx.LoanId = record.GetInt32(record.GetOrdinal("LoanId"));
            }

            typeof(BaseEntity)
                .GetProperty(nameof(BaseEntity.Id))!
                .SetValue(tx, record.GetInt32(record.GetOrdinal("Id")));

            typeof(BaseEntity)
                .GetProperty(nameof(BaseEntity.CreatedAt))!
                .SetValue(tx, record.GetDateTime(record.GetOrdinal("CreatedAt")));

            return tx;
        }
    }
}
