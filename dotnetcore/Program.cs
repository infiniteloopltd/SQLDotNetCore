using System;
using System.Data;
using System.Data.SqlClient;

namespace dotnetcore
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString =
                "data source=localhost; Initial Catalog=Library; Integrated Security=True;";
            var connection = new SqlConnection(connectionString);
            connection.Open();
            const string sql = "select * from students";
            var adapter = new SqlDataAdapter(sql, connection);
            var students = new DataSet();
            adapter.Fill(students, "students");
            foreach (DataRow student in students.Tables["students"].Rows)
            {
                Console.WriteLine(student["FirstName"] + " " + student["Surname"]);
            }
            connection.Close();
            Console.ReadLine();
        }
    }
}
