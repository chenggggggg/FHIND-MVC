﻿using System;
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

            string query = "SELECT Student.StudentID, Student.email, Student.wachtwoord, Student.voornaam, Student.achternaam, Student.tussenvoegsel, Student.studentnummer, Student.leerjaar, Student.specialiteiten, Profiel.ProfielNaam, Specialisaties.SpecialisatieNaam FROM Student LEFT JOIN Profiel ON Student.ProfielID = Profiel.ProfielID LEFT JOIN Specialisaties on Student.SpecialisatieID = Specialisaties.SpecialisatieID";

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
                        string profielnaam = string.Empty;
                        if (!reader.IsDBNull(9))
                        {
                            profielnaam = reader.GetString(9);
                        }               
                        string specialisatienaam = string.Empty;
                        if (!reader.IsDBNull(10))
                        {
                            specialisatienaam = reader.GetString(10);
                        }
                        
                        Student student = new Student(studentid, email, wachtwoord, voornaam, achternaam, tussenvoegsel, studentnummer, leerjaar, specialiteiten, profielnaam, specialisatienaam);
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

        public List<Student> getStudentsOfCurrentTime(List<Student> alleStudenten, string lokaalnummer)
        {
            DateTime currentTime = DateTime.Now;
            List<Student> aanwezigeStudenten = new List<Student>();
            aanwezigeStudenten = alleStudenten;

            string query = "SELECT * FROM Student_vak";

            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int StudentID = reader.GetInt32(0);
                        int VakID = reader.GetInt32(1);
                        DateTime VanTijd = reader.GetDateTime(2);
                        DateTime TotTijd = reader.GetDateTime(3);
                        string expectedlokaal = reader.GetString(4);

                        foreach (Student s in aanwezigeStudenten.ToList())
                        {
                            if (s.StudentID == StudentID)
                            {
                                if ((currentTime < VanTijd && currentTime < TotTijd) || (currentTime > VanTijd && currentTime > TotTijd) || expectedlokaal != lokaalnummer)
                                {
                                    aanwezigeStudenten.Remove(s);
                                }                                
                            }
                        }                      
                                                                        
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            conn.Close();
            return aanwezigeStudenten;
        }
        }
}
