using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Form1
{
    class StudentManagement
    {
        public PM13894[] GetStudents()
        {
            var db = new OOPCSEntities();
            return db.PM13894.ToArray();
        }

        public void AddStudent(string name, string code, string hometown, bool gender)
        {
            var newStudent = new PM13894();
            newStudent.Name = name;
            newStudent.Hometown = hometown;
            newStudent.Code = code;
            newStudent.Gender = gender;

            var db = new OOPCSEntities();
            db.PM13894.Add(newStudent);
            db.SaveChanges();        
        }

        public void EditStudent(int id, string name, string code, string hometown, bool gender)
        {
            var db = new OOPCSEntities();
            var oldStudent = db.PM13894.Find(id);

            oldStudent.Name = name;
            oldStudent.Code = code;
            oldStudent.Hometown = hometown;
            oldStudent.Gender = gender;
            db.Entry(oldStudent).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var db = new OOPCSEntities();
            var student = db.PM13894.Find(id);
            db.PM13894.Remove(student);
            db.SaveChanges();
        }

        public PM13894 GetStudent(int id)
        {
            var db = new OOPCSEntities();
            return db.PM13894.Find(id);
        }
    }
}
