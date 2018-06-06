using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ClassLibraryFHIND.Entities;

namespace ClassLibraryFHIND.Data
{
    public class DatabaseConnection
    {
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Maatwerk\Freaky Day\FHIND MVC\FHIND MVC\App_Data\DatabaseFD.mdf;Integrated Security = True";
        private SqlConnection conn = new SqlConnection(connectionString);

        public int GetUserID(string email, string wachtwoord)
        {
            int UserID = -1;
            string query = "SELECT StudentID FROM Student WHERE (Email= @Email AND Wachtwoord= @Wachtwoord)";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Wachtwoord", wachtwoord);
            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UserID = reader.GetInt32(0);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            conn.Close();
            return UserID;
        }
        //new method
        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            string query = "SELECT * FROM Student";

            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Student student = new Student();

                        UserID = reader.GetInt32(0);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            conn.Close();

            return students;
        }

    }
}
