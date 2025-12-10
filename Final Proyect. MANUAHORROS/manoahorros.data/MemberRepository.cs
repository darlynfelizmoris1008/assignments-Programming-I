using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using manuahorros.D;

namespace manuahorros.data
{
    public class MemberRepository
    {
        public int Add(Member member)
        {
            try
            {
                using var connection = DbConnectionFactory.CreateOpenConnection();
                using var command = connection.CreateCommand();

                command.CommandText = @"
                    INSERT INTO Members (FullName, StudentId, Email, Phone, JoinedAt, IsActive, CreatedAt)
                    VALUES (@FullName, @StudentId, @Email, @Phone, @JoinedAt, @IsActive, @CreatedAt);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);
                ";

                AddParam(command, "@FullName", member.FullName);
                AddParam(command, "@StudentId", member.StudentId);
                AddParam(command, "@Email", string.IsNullOrWhiteSpace(member.Email) ? DBNull.Value : member.Email);
                AddParam(command, "@Phone", string.IsNullOrWhiteSpace(member.Phone) ? DBNull.Value : member.Phone);
                AddParam(command, "@JoinedAt", member.JoinedAt);
                AddParam(command, "@IsActive", member.IsActive);
                AddParam(command, "@CreatedAt", member.CreatedAt);

                var result = command.ExecuteScalar();
                var newId = (int)(result ?? 0);

                typeof(BaseEntity)
                    .GetProperty(nameof(BaseEntity.Id))!
                    .SetValue(member, newId);

                return newId;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error in Add(Member):");
                Console.WriteLine(ex.Message);
                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error in Add(Member):");
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public Member? GetById(int id)
        {
            try
            {
                using var connection = DbConnectionFactory.CreateOpenConnection();
                using var command = connection.CreateCommand();

                command.CommandText = @"
                    SELECT Id, FullName, StudentId, Email, Phone, JoinedAt, IsActive, CreatedAt
                    FROM Members
                    WHERE Id = @Id;
                ";

                AddParam(command, "@Id", id);

                using var reader = command.ExecuteReader();

                if (!reader.Read())
                    return null;

                return MapMember(reader);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error in GetById:");
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error in GetById:");
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<Member> GetAll()
        {
            var members = new List<Member>();

            try
            {
                using var connection = DbConnectionFactory.CreateOpenConnection();
                using var command = connection.CreateCommand();

                command.CommandText = @"
                    SELECT Id, FullName, StudentId, Email, Phone, JoinedAt, IsActive, CreatedAt
                    FROM Members;
                ";

                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    members.Add(MapMember(reader));
                }

                return members;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error in GetAll:");
                Console.WriteLine(ex.Message);
                return members;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error in GetAll:");
                Console.WriteLine(ex.Message);
                return members;
            }
        }

        public bool Update(Member member)
        {
            try
            {
                using var connection = DbConnectionFactory.CreateOpenConnection();
                using var command = connection.CreateCommand();

                command.CommandText = @"
                    UPDATE Members
                    SET FullName = @FullName,
                        StudentId = @StudentId,
                        Email = @Email,
                        Phone = @Phone,
                        JoinedAt = @JoinedAt,
                        IsActive = @IsActive
                    WHERE Id = @Id;
                ";

                AddParam(command, "@Id", member.Id);
                AddParam(command, "@FullName", member.FullName);
                AddParam(command, "@StudentId", member.StudentId);
                AddParam(command, "@Email", string.IsNullOrWhiteSpace(member.Email) ? DBNull.Value : member.Email);
                AddParam(command, "@Phone", string.IsNullOrWhiteSpace(member.Phone) ? DBNull.Value : member.Phone);
                AddParam(command, "@JoinedAt", member.JoinedAt);
                AddParam(command, "@IsActive", member.IsActive);

                var rows = command.ExecuteNonQuery();
                return rows > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error in Update(Member):");
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error in Update(Member):");
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
                    DELETE FROM Members
                    WHERE Id = @Id;
                ";

                AddParam(command, "@Id", id);

                var rows = command.ExecuteNonQuery();
                return rows > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error in Delete(Member):");
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error in Delete(Member):");
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

        private static Member MapMember(IDataRecord record)
        {
            var member = new Member
            {
                FullName = record.GetString(record.GetOrdinal("FullName")),
                StudentId = record.GetString(record.GetOrdinal("StudentId")),
                Email = record.IsDBNull(record.GetOrdinal("Email"))
                    ? string.Empty
                    : record.GetString(record.GetOrdinal("Email")),
                Phone = record.IsDBNull(record.GetOrdinal("Phone"))
                    ? string.Empty
                    : record.GetString(record.GetOrdinal("Phone")),
                JoinedAt = record.GetDateTime(record.GetOrdinal("JoinedAt")),
                IsActive = record.GetBoolean(record.GetOrdinal("IsActive"))
            };

            typeof(BaseEntity)
                .GetProperty(nameof(BaseEntity.Id))!
                .SetValue(member, record.GetInt32(record.GetOrdinal("Id")));

            typeof(BaseEntity)
                .GetProperty(nameof(BaseEntity.CreatedAt))!
                .SetValue(member, record.GetDateTime(record.GetOrdinal("CreatedAt")));

            return member;
        }
    }
}
