using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using manuahorros.D;

namespace manuahorros.data
{
    public class AccountRepository
    {
        public int Add(Account account)
        {
            try
            {
                using var connection = DbConnectionFactory.CreateOpenConnection();
                using var command = connection.CreateCommand();

                command.CommandText = @"
                    INSERT INTO Accounts (
                        MemberId,
                        AccountNumber,
                        AccountType,
                        Balance,
                        IsActive,
                        CreatedAt
                    )
                    VALUES (
                        @MemberId,
                        @AccountNumber,
                        @AccountType,
                        @Balance,
                        @IsActive,
                        @CreatedAt
                    );
                    SELECT CAST(SCOPE_IDENTITY() AS INT);
                ";

                AddParam(command, "@MemberId", account.MemberId);
                AddParam(command, "@AccountNumber", account.AccountNumber);
                AddParam(command, "@AccountType", (int)account.AccountType);
                AddParam(command, "@Balance", account.Balance);
                AddParam(command, "@IsActive", account.IsActive);
                AddParam(command, "@CreatedAt", account.CreatedAt);

                var result = command.ExecuteScalar();
                var newId = (int)(result ?? 0);

                typeof(BaseEntity)
                    .GetProperty(nameof(BaseEntity.Id))!
                    .SetValue(account, newId);

                return newId;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error in AccountRepository.Add:");
                Console.WriteLine(ex.Message);
                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error in AccountRepository.Add:");
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public Account? GetById(int id)
        {
            try
            {
                using var connection = DbConnectionFactory.CreateOpenConnection();
                using var command = connection.CreateCommand();

                command.CommandText = @"
                    SELECT
                        Id,
                        MemberId,
                        AccountNumber,
                        AccountType,
                        Balance,
                        IsActive,
                        CreatedAt
                    FROM Accounts
                    WHERE Id = @Id;
                ";

                AddParam(command, "@Id", id);

                using var reader = command.ExecuteReader();

                if (!reader.Read())
                    return null;

                return MapAccount(reader);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error in AccountRepository.GetById:");
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error in AccountRepository.GetById:");
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<Account> GetByMemberId(int memberId)
        {
            var accounts = new List<Account>();

            try
            {
                using var connection = DbConnectionFactory.CreateOpenConnection();
                using var command = connection.CreateCommand();

                command.CommandText = @"
                    SELECT
                        Id,
                        MemberId,
                        AccountNumber,
                        AccountType,
                        Balance,
                        IsActive,
                        CreatedAt
                    FROM Accounts
                    WHERE MemberId = @MemberId;
                ";

                AddParam(command, "@MemberId", memberId);

                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    accounts.Add(MapAccount(reader));
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error in AccountRepository.GetByMemberId:");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error in AccountRepository.GetByMemberId:");
                Console.WriteLine(ex.Message);
            }

            return accounts;
        }

        public List<Account> GetAll()
        {
            var accounts = new List<Account>();

            try
            {
                using var connection = DbConnectionFactory.CreateOpenConnection();
                using var command = connection.CreateCommand();

                command.CommandText = @"
                    SELECT
                        Id,
                        MemberId,
                        AccountNumber,
                        AccountType,
                        Balance,
                        IsActive,
                        CreatedAt
                    FROM Accounts;
                ";

                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    accounts.Add(MapAccount(reader));
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error in AccountRepository.GetAll:");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error in AccountRepository.GetAll:");
                Console.WriteLine(ex.Message);
            }

            return accounts;
        }

        public bool Update(Account account)
        {
            try
            {
                using var connection = DbConnectionFactory.CreateOpenConnection();
                using var command = connection.CreateCommand();

                command.CommandText = @"
                    UPDATE Accounts
                    SET
                        MemberId = @MemberId,
                        AccountNumber = @AccountNumber,
                        AccountType = @AccountType,
                        Balance = @Balance,
                        IsActive = @IsActive
                    WHERE Id = @Id;
                ";

                AddParam(command, "@Id", account.Id);
                AddParam(command, "@MemberId", account.MemberId);
                AddParam(command, "@AccountNumber", account.AccountNumber);
                AddParam(command, "@AccountType", (int)account.AccountType);
                AddParam(command, "@Balance", account.Balance);
                AddParam(command, "@IsActive", account.IsActive);

                var rows = command.ExecuteNonQuery();
                return rows > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error in AccountRepository.Update:");
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error in AccountRepository.Update:");
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using var connection = DbConnectionFactory.CreateOpenConnection();
                using var command = connection.CreateCommand();

                command.CommandText = @"
                    DELETE FROM Accounts
                    WHERE Id = @Id;
                ";

                AddParam(command, "@Id", id);

                var rows = command.ExecuteNonQuery();
                return rows > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error in AccountRepository.Delete:");
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error in AccountRepository.Delete:");
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

        private static Account MapAccount(IDataRecord record)
        {
            var account = new Account
            {
                MemberId = record.GetInt32(record.GetOrdinal("MemberId")),
                AccountNumber = record.GetString(record.GetOrdinal("AccountNumber")),
                AccountType = (AccountType)record.GetInt32(record.GetOrdinal("AccountType")),
                IsActive = record.GetBoolean(record.GetOrdinal("IsActive"))
            };

            typeof(BaseEntity)
                .GetProperty(nameof(BaseEntity.Id))!
                .SetValue(account, record.GetInt32(record.GetOrdinal("Id")));

            typeof(BaseEntity)
                .GetProperty(nameof(BaseEntity.CreatedAt))!
                .SetValue(account, record.GetDateTime(record.GetOrdinal("CreatedAt")));

            typeof(FinancialProduct)
                .GetProperty(nameof(FinancialProduct.Balance))!
                .SetValue(account, record.GetDecimal(record.GetOrdinal("Balance")));

            return account;
        }
    }
}
