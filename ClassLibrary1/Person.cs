using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    public class Manager
    {
        private string _connectionString;

        public Manager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Person> GetAllPeople()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM People";
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Person> people = new List<Person>();
            while (reader.Read())
            {
                people.Add(new Person
                {
                    Id = (int)reader["id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"]
                });
            }
            connection.Close();
            connection.Dispose();
            return people;
        }

        public void AddPeople(List<Person> people)
        {
            foreach (Person p in people)
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = @"INSERT INTO People VALUES (@firstName, @lastName, @age)";
                cmd.Parameters.AddWithValue("@firstName", p.FirstName);
                cmd.Parameters.AddWithValue("@lastName", p.LastName);
                cmd.Parameters.AddWithValue("@age", p.Age);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                connection.Dispose();
            }
        }
    }
}
