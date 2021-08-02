using System;

namespace ConsoleApp.MacOs
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Console DB App");
            var res = "n";
            do
            {
                TblNewOperationWithoutOrm tbl = new TblNewOperationWithoutOrm();
                Console.WriteLine("Press \n1 to Get All Students");
                Console.WriteLine("2 to Get by Id");
                Console.WriteLine("3 to Create Student");
                Console.WriteLine("4 to Edit Student");
                Console.WriteLine("5 to Delete Student");
                var choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        //GetAll();
                        tbl.GetAll();
                        break;

                    case 2:
                        //GetById();
                        tbl.GetById();
                        break;

                    case 3:
                        //Create();
                        tbl.Create();
                        break;

                    case 4:
                        //Edit();
                        tbl.Edit();
                        break;

                    case 5:
                        //Delete();
                        tbl.Delete();
                        break;

                    default:
                        break;
                }

                Console.WriteLine("Do you want to continue more (Y/N)?");
                res = Console.ReadLine();
            } while (res.ToUpper() == "Y");
        }

        private static StudentOperation SOps = new StudentOperation();

        private static void GetAll()
        {
            var data = SOps.GetAll();
            foreach (var item in data)
            {
                Console.WriteLine($"Id => {item.Id}, Name => {item.Name}, Email => {item.Email}");
            }
        }

        private static void GetById()
        {
            Console.WriteLine("Enter the Id of student");
            var id = Convert.ToInt32(Console.ReadLine());
            var student = SOps.GetById(id);
            if (student == null)
            {
                Console.WriteLine("No record found with this value");
            }
            else
            {
                Console.WriteLine($"Id => {student.Id}, Name => {student.Name}, Email => {student.Email}");
            }
        }

        private static void Create()
        {
            Student s = new Student();
            Console.WriteLine("Enter the Name of student");
            s.Name = Console.ReadLine();
            Console.WriteLine("Enter the Email of student");
            s.Email = Console.ReadLine();

            var res = SOps.Create(s);
            if (res)
            {
                Console.WriteLine("Added successfully");
            }
            else
            {
                Console.WriteLine("Record not added");
            }
        }

        private static void Edit()
        {
            Student s = new Student();
            Console.WriteLine("Enter the Id of student");
            s.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the new Name of student");
            s.Name = Console.ReadLine();
            Console.WriteLine("Enter the new Email of student");
            s.Email = Console.ReadLine();

            var res = SOps.Edit(s);
            if (res)
            {
                Console.WriteLine("updated successfully");
            }
            else
            {
                Console.WriteLine("Record not updated");
            }
        }

        private static void Delete()
        {
            Console.WriteLine("Enter the Id of student");
            var Id = Convert.ToInt32(Console.ReadLine());

            var res = SOps.Delete(Id);
            if (res)
            {
                Console.WriteLine("deleted successfully");
            }
            else
            {
                Console.WriteLine("Record not deleted");
            }
        }
    }
}