using System;
using System.Data.SqlClient;

namespace ConsoleApp.MacOs
{
    public class TblNewOperationWithoutOrm
    {
        private string connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=3PM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //CRUD operation
        public void GetAll()
        {
            var con = new SqlConnection(connectionstring);
            string query = "select * from tblnew";
            var cmd = new SqlCommand(query, con);
            con.Open();
            try
            {
                var result = cmd.ExecuteReader();
                while (result.Read())
                {
                    var id = result.GetInt32(0);
                    var address = result.GetString(1);
                    var age = result.GetInt32(2);
                    var firstname = result.GetString(3);
                    var lastname = result.GetString(4);
                    Console.WriteLine($"Id={id}, Name={firstname} {lastname}, Address={address}, Age={age}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            con.Close();
        }

        public void GetById()
        {
            Console.WriteLine("Enter the Id of person");
            var personid = Console.ReadLine();

            var con = new SqlConnection(connectionstring);
            string query = $"select * from tblnew where id={personid}";
            var cmd = new SqlCommand(query, con);
            con.Open();
            try
            {
                var result = cmd.ExecuteReader();
                while (result.Read())
                {
                    var id = result.GetInt32(0);
                    var address = result.GetString(1);
                    var age = result.GetInt32(2);
                    var firstname = result.GetString(3);
                    var lastname = result.GetString(4);
                    Console.WriteLine($"Id={id}, Name={firstname} {lastname}, Address={address}, Age={age}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            con.Close();
        }

        public void Create()
        {
            Console.WriteLine("Enter the first name of person");
            var fname = Console.ReadLine();
            Console.WriteLine("Enter the last name of person");
            var lname = Console.ReadLine();
            Console.WriteLine("Enter the Adress of person");
            var address = Console.ReadLine();
            Console.WriteLine("Enter the age of person");
            var age = Console.ReadLine();

            var con = new SqlConnection(connectionstring);
            string query = $"insert into tblnew (firstname,lastname,address,age) values ('{fname}','{lname}', '{address}', '{age}')";
            var cmd = new SqlCommand(query, con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            con.Close();
        }

        public void Edit()
        {
            Console.WriteLine("Enter the id of person");
            var id = Console.ReadLine();
            Console.WriteLine("Enter the first name of person");
            var fname = Console.ReadLine();
            Console.WriteLine("Enter the last name of person");
            var lname = Console.ReadLine();
            Console.WriteLine("Enter the Adress of person");
            var address = Console.ReadLine();
            Console.WriteLine("Enter the age of person");
            var age = Convert.ToInt32(Console.ReadLine());

            var con = new SqlConnection(connectionstring);
            string query = $"update tblnew set firstname='{fname}', lastname='{lname}',address='{address}',age='{age}' where id={id}";
            var cmd = new SqlCommand(query, con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            con.Close();
        }

        public void Delete()
        {
            Console.WriteLine("Enter the id of person");
            var id = Console.ReadLine();

            var con = new SqlConnection(connectionstring);
            string query = $"delete from tblnew where id={id}";
            var cmd = new SqlCommand(query, con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            con.Close();
        }
    }
}