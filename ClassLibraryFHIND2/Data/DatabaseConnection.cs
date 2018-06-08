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
        //Calvin:
        //private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Maatwerk\Freaky Day\FHIND MVC\FHIND MVC\App_Data\DatabaseFD.mdf;Integrated Security = True";
        //Kylie:
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kylie\Documents\Git\FHIND-MVC\Database\DatabaseFD.mdf;Integrated Security = True";
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


                        int studentid = reader.GetInt32(0);
                        string email = reader.GetString(1);
                        string wachtwoord = reader.GetString(2);
                        string voornaam = reader.GetString(3);
                        string achternaam = reader.GetString(4);
                        string tussenvoegsel = string.Empty;
                        if (!reader.IsDBNull(5))
                        {
                            tussenvoegsel = reader.GetString(5);
                        }
                        int studentnummer = reader.GetInt32(6);
                        int leerjaar = reader.GetInt32(7);
                        string specialiteiten = string.Empty;
                        if (!reader.IsDBNull(8))
                        {
                            specialiteiten = reader.GetString(8);
                        }
                        int profielid = -1;
                        if (!reader.IsDBNull(9))
                        {
                            profielid = reader.GetInt32(9);
                        }               
                        int specialisatieid = reader.GetInt32(10);
                        
                        Student student = new Student(studentid, email, wachtwoord, voornaam, achternaam, tussenvoegsel, studentnummer, leerjaar, specialiteiten, profielid, specialisatieid);
                        students.Add(student);                        
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
