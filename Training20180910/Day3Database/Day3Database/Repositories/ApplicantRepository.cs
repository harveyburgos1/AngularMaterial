using Day3Database.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Day3Database.Repositories
{
    public class ApplicantRepository
    {
        private readonly string connectionString =
            "Server=.;Database=OnlineStoreDB;Integrated Security=true;";
        private readonly string insertStatement = @"INSERT INTO [Applicant] 
                            (
                                ApplicantID, 
                                FirstName, 
                                MiddleName, 
                                LastName,
                                BirthDate 
                            )
                            VALUES 
                            (
                                @applicantID,
                                @firstName,
                                @middleName,
                                @lastName,
                                @birthDate
                            )";
        private readonly string updateStatement = @"UPDATE [Applicant] 
                            SET
                                FirstName = @firstName, 
                                MiddleName = @middleName, 
                                LastName = @lastName,
                                BirthDate = @birthDate
                            WHERE ApplicantID = @applicantID";
                            
        private readonly string deleteStatement = 
                    @"DELETE FROM [Applicant] 
                      WHERE ApplicantID = @applicantID";
        private readonly string retrieveStatement =
                    @"SELECT 
                        ApplicantID,
                        FirstName,
                        MiddleName,
                        LastName,
                        BirthDate
                      FROM [Applicant] " ;
        private readonly string retrieveFilter =  
                     @"WHERE ApplicantID = @applicantID";
        public Applicant Create(Applicant newApplicant)
        {
            // TODO: Use validations here.
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = insertStatement;
                    command.Parameters.Add("@applicantID", SqlDbType.UniqueIdentifier)
                                      .Value = newApplicant.ApplicantId;
                    command.Parameters.Add("@firstName", SqlDbType.NVarChar, 50)
                                      .Value = newApplicant.FirstName;
                    command.Parameters.Add("@middleName", SqlDbType.NVarChar, 50)
                                      .Value = newApplicant.MiddleName;
                    command.Parameters.Add("@lastName", SqlDbType.NVarChar, 50)
                                      .Value = newApplicant.LastName;
                    command.Parameters.Add("@birthDate", SqlDbType.Date)
                                      .Value = newApplicant.BirthDate;
                    command.ExecuteNonQuery();

                    return newApplicant;
                }

               
            }
        }

        public void Delete(Guid id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = deleteStatement;
                    command.Parameters.Add("@applicantID", SqlDbType.UniqueIdentifier)
                                      .Value = id;
                    command.ExecuteNonQuery();
                }
            }
        }

        public Applicant Update(Applicant applicant)
        {
            // TODO: Use validations here.
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = updateStatement;
                    command.Parameters.Add("@applicantID", SqlDbType.UniqueIdentifier)
                                      .Value = applicant.ApplicantId;
                    command.Parameters.Add("@firstName", SqlDbType.NVarChar, 50)
                                      .Value = applicant.FirstName;
                    command.Parameters.Add("@middleName", SqlDbType.NVarChar, 50)
                                      .Value = applicant.MiddleName;
                    command.Parameters.Add("@lastName", SqlDbType.NVarChar, 50)
                                      .Value = applicant.LastName;
                    command.Parameters.Add("@birthDate", SqlDbType.Date)
                                      .Value = applicant.BirthDate;
                    command.ExecuteNonQuery();

                    return applicant;
                }


            }
        }

        public Applicant Retrieve(Guid id)
        {
            Applicant applicant = null;
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = retrieveStatement + retrieveFilter;
                    command.Parameters.Add("@applicantID", SqlDbType.UniqueIdentifier)
                                      .Value = id;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            applicant = new Applicant();
                            applicant.ApplicantId = reader.GetGuid(0);
                            applicant.FirstName = reader.GetString(1);
                            applicant.MiddleName = reader.GetString(2);
                            applicant.LastName = reader.GetString(3);
                            applicant.BirthDate = reader.GetDateTime(4);

                            break;
                        }
                    }
                }
            }
            return applicant;
        }

        public List<Applicant> Retrieve()
        {
            var applicants = new List<Applicant>();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = retrieveStatement;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var applicant = new Applicant();
                            applicant.ApplicantId = reader.GetGuid(0);
                            applicant.FirstName = reader.GetString(1);
                            applicant.MiddleName = reader.GetString(2);
                            applicant.LastName = reader.GetString(3);
                            applicant.BirthDate = reader.GetDateTime(4);

                            applicants.Add(applicant);
                        }
                    }
                }
            }
            return applicants;
        }
    }
}
