using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.MacOs
{
    public class StudentOperation
    {
        private DefaultContext db = new DefaultContext();

        //CRUD operation
        public List<Student> GetAll()
        {
            return db.Students.ToList();
        }

        public Student GetById(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            else
            {
                return db.Students.Find(id);
            }
        }

        public bool Create(Student student)
        {
            try
            {
                db.Students.Add(student);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Edit(Student student)
        {
            try
            {
                var existing = db.Students.Find(student.Id);
                if (existing == null)
                {
                    return false;
                }
                else
                {
                    existing.Name = student.Name;
                    existing.Email = student.Email;
                    db.Entry(existing).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var existing = db.Students.Find(id);
                if (existing == null)
                {
                    return false;
                }
                else
                {
                    db.Students.Remove(existing);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}