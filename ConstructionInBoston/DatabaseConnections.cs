using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using ConstructionInBoston.Models;

namespace ConstructionInBoston
{
    public static class DatabaseConnections
    {
        private static string _connectionString;

        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;
                }

                return _connectionString;
            }
        }

        public static T ConvertFromDBVal<T>(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return default(T); // returns the default value for the type
            }

            return (T)obj;
        }

        /* Projects */
        public static List<Project> GetProjects(string id)
        {
            var results = new List<Project>();

            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("sp_GetProjects", conn) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter("project_id", string.Empty));
                    conn.Open();
                    var reader = command.ExecuteReader();
                    foreach (DbDataRecord row in reader)
                    {
                        var proj = new Project
                        {
                            Name = ConvertFromDBVal<string>(row[0]),
                            Address = ConvertFromDBVal<string>(row[1]),
                            Architect = ConvertFromDBVal<string>(row[6]),
                            Contractor = ConvertFromDBVal<string>(row[8]),
                            Developer = ConvertFromDBVal<string>(row[7]),
                            Floors = ConvertFromDBVal<int>(row[3]),
                            SquareFootage = ConvertFromDBVal<int>(row[4]),
                            PermitNumber = ConvertFromDBVal<string>(row[5]),
                            Status = ConvertFromDBVal<string>(row[2]),
                            Neighborhood = ConvertFromDBVal<string>(row[9]),
                            ImagePath = ConvertFromDBVal<string>(row[10])
                        };

                        results.Add(proj);
                    }

                    conn.Close();
                }

            }

            return results;
        }

        public static bool AddProject(Project proj)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("sp_AddProject", conn) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter("name", proj.Name));
                    command.Parameters.Add(new SqlParameter("address", proj.Address));
                    command.Parameters.Add(new SqlParameter("floors", proj.Floors));
                    command.Parameters.Add(new SqlParameter("footage", proj.SquareFootage));
                    command.Parameters.Add(new SqlParameter("status", proj.Status));
                    command.Parameters.Add(new SqlParameter("neighborhood", proj.Neighborhood));
                    command.Parameters.Add(new SqlParameter("permit", proj.PermitNumber));
                    command.Parameters.Add(new SqlParameter("image", proj.ImagePath));
                    command.Parameters.Add(new SqlParameter("contractor", proj.Contractor));
                    command.Parameters.Add(new SqlParameter("developer", proj.Developer));
                    command.Parameters.Add(new SqlParameter("architect", proj.Architect));
                    conn.Open();
                    var result = command.ExecuteReader();                  
                    conn.Close();

                    return Convert.ToBoolean(result.RecordsAffected);
                }

            }
        }

        public static bool UpdateProject(Project proj)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("sp_UpdateProject", conn) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter("name", proj.Name));
                    command.Parameters.Add(new SqlParameter("address", proj.Address));
                    command.Parameters.Add(new SqlParameter("floors", proj.Floors));
                    command.Parameters.Add(new SqlParameter("footage", proj.SquareFootage));
                    command.Parameters.Add(new SqlParameter("status", proj.Status));
                    command.Parameters.Add(new SqlParameter("neighborhood", proj.Neighborhood));
                    command.Parameters.Add(new SqlParameter("permit", proj.PermitNumber));
                    command.Parameters.Add(new SqlParameter("image", proj.ImagePath));
                    command.Parameters.Add(new SqlParameter("contractor", proj.Contractor));
                    command.Parameters.Add(new SqlParameter("developer", proj.Developer));
                    command.Parameters.Add(new SqlParameter("architect", proj.Architect));
                    conn.Open();
                    var result = command.ExecuteReader();
                    conn.Close();

                    return Convert.ToBoolean(result.RecordsAffected);
                }

            }
        }

        public static bool DeleteProject(string id)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("sp_DeleteProject", conn) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter("name", id));
                    conn.Open();
                    var result = command.ExecuteReader();
                    conn.Close();

                    return Convert.ToBoolean(result.RecordsAffected);
                }

            }
        }


        /* Architects */
        public static List<Architect> GetArchitects(string id)
        {
            var results = new List<Architect>();

            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("sp_GetArchitects", conn) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter("architect_id", string.Empty));
                    conn.Open();
                    var reader = command.ExecuteReader();
                    foreach (DbDataRecord row in reader)
                    {
                        var arch = new Architect
                        {
                            Name = ConvertFromDBVal<string>(row[0]),
                            Address = ConvertFromDBVal<string>(row[1]),
                            YearEstablished = ConvertFromDBVal<int>(row[2]),
                            ImagePath = ConvertFromDBVal<string>(row[3])
                        };

                        results.Add(arch);
                    }

                    conn.Close();
                }

            }

            return results;
        }

        public static bool AddArchitect(Architect arch)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("sp_AddArchitect", conn) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter("name", arch.Name));
                    command.Parameters.Add(new SqlParameter("address", arch.Address));
                    command.Parameters.Add(new SqlParameter("year", arch.YearEstablished));
                    command.Parameters.Add(new SqlParameter("image", arch.ImagePath));
                    conn.Open();
                    var result = command.ExecuteReader();
                    conn.Close();

                    return Convert.ToBoolean(result.RecordsAffected);
                }

            }
        }

        public static bool UpdateArchitect(Architect arch)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("sp_UpdateArchitect", conn) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter("name", arch.Name));
                    command.Parameters.Add(new SqlParameter("address", arch.Address));
                    command.Parameters.Add(new SqlParameter("year", arch.YearEstablished));
                    command.Parameters.Add(new SqlParameter("image", arch.ImagePath));
                    conn.Open();
                    var result = command.ExecuteReader();
                    conn.Close();

                    return Convert.ToBoolean(result.RecordsAffected);
                }

            }
        }

        public static bool DeleteArchitect(string id)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("sp_DeleteArchitect", conn) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter("name", id));
                    conn.Open();
                    var result = command.ExecuteReader();
                    conn.Close();

                    return Convert.ToBoolean(result.RecordsAffected);
                }

            }
        }



        /* Contractors */
        public static List<Contractor> GetContractors(string id)
        {
            var results = new List<Contractor>();

            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("sp_GetContractors", conn) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter("contractor_id", id));
                    conn.Open();
                    var reader = command.ExecuteReader();
                    foreach (DbDataRecord row in reader)
                    {
                        var cont = new Contractor
                        {
                            Name = ConvertFromDBVal<string>(row[0]),
                            Address = ConvertFromDBVal<string>(row[1]),
                            YearEstablished = ConvertFromDBVal<int>(row[2]),
                            ImagePath = ConvertFromDBVal<string>(row[3])
                        };

                        results.Add(cont);
                    }

                    conn.Close();
                }

            }

            return results;
        }

        public static bool AddContractor(Contractor cont)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("sp_AddContractor", conn) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter("name", cont.Name));
                    command.Parameters.Add(new SqlParameter("address", cont.Address));
                    command.Parameters.Add(new SqlParameter("year", cont.YearEstablished));
                    command.Parameters.Add(new SqlParameter("image", cont.ImagePath));
                    conn.Open();
                    var result = command.ExecuteReader();
                    var boolRes = Convert.ToBoolean(result.RecordsAffected);
                    conn.Close();

                    return boolRes;
                }

            }
        }

        public static bool UpdateContractor(Contractor cont)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("sp_UpdateContractor", conn) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter("name", cont.Name));
                    command.Parameters.Add(new SqlParameter("address", cont.Address));
                    command.Parameters.Add(new SqlParameter("year", cont.YearEstablished));
                    command.Parameters.Add(new SqlParameter("image", cont.ImagePath));
                    conn.Open();
                    var result = command.ExecuteReader();
                    conn.Close();

                    return Convert.ToBoolean(result.RecordsAffected);
                }

            }
        }

        public static bool DeleteContractor(string id)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("sp_DeleteContractor", conn) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter("name", id));
                    conn.Open();
                    var result = command.ExecuteReader();
                    conn.Close();

                    return Convert.ToBoolean(result.RecordsAffected);
                }

            }
        }


        /* Developers */
        public static List<Developer> GetDevelopers(string id)
        {
            var results = new List<Developer>();

            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("sp_GetDevelopers", conn) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter("developer_id", string.Empty));
                    conn.Open();
                    var reader = command.ExecuteReader();
                    foreach (DbDataRecord row in reader)
                    {
                        var dev = new Developer
                        {
                            Name = ConvertFromDBVal<string>(row[0]),
                            Address = ConvertFromDBVal<string>(row[1]),
                            YearEstablished = ConvertFromDBVal<int>(row[2]),
                            ImagePath = ConvertFromDBVal<string>(row[3])
                        };

                        results.Add(dev);
                    }

                    conn.Close();
                }

            }

            return results;
        }

        public static bool AddDeveloper(Developer dev)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("sp_AddDeveloper", conn) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter("name", dev.Name));
                    command.Parameters.Add(new SqlParameter("address", dev.Address));
                    command.Parameters.Add(new SqlParameter("year", dev.YearEstablished));
                    command.Parameters.Add(new SqlParameter("image", dev.ImagePath));
                    conn.Open();
                    var result = command.ExecuteReader();
                    conn.Close();

                    return Convert.ToBoolean(result.RecordsAffected);
                }

            }
        }

        public static bool UpdateDeveloper(Developer dev)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("sp_UpdateDeveloper", conn) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter("name", dev.Name));
                    command.Parameters.Add(new SqlParameter("address", dev.Address));
                    command.Parameters.Add(new SqlParameter("year", dev.YearEstablished));
                    command.Parameters.Add(new SqlParameter("image", dev.ImagePath));
                    conn.Open();
                    var result = command.ExecuteReader();
                    conn.Close();

                    return Convert.ToBoolean(result.RecordsAffected);
                }

            }
        }

        public static bool DeleteDeveloper(string id)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("sp_DeleteDeveloper", conn) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter("name", id));
                    conn.Open();
                    var result = command.ExecuteReader();
                    conn.Close();

                    return Convert.ToBoolean(result.RecordsAffected);
                }

            }
        }

    }
}