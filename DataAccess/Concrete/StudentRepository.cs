using DataAccess.Abstarct;
using Entitiy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class StudentRepository : IStudentRepository
    {
        private readonly List<Student> _students = new();

        // yeni bir öğrenci ekler
        public void Add(Student entity)
        {
            _students.Add(entity);
        }

        // öğrenci bilgilerini günceller
        public void Update(Student entity)
        {
            var student = _students.FirstOrDefault(s => s.StudentId == entity.StudentId);
            if (student != null)
            {
                student.FirstName = entity.FirstName;
                student.LastName = entity.LastName;
                student.Email = entity.Email;
                student.Password = entity.Password;
            }
        }

        //bir öğrenci siler
        public void Delete(Student entity)
        {
            _students.Remove(entity);
        }

        //öğrenci ıd degerine göre getirir
        public Student GetById(int id)
        {
            return _students.FirstOrDefault(s => s.StudentId == id);
        }

        // tüm öğrencileri getirir
        public List<Student> GetAll()
        {
            return _students;
        }

        // öğrencin aldığı kurs ıd degerine göre getirir
        public List<Student> GetStudentsByCourseId(int courseId)
        {
            return _students.Where(s => s.CoursesSelected.Any(c => c.CourseId == courseId)).ToList();
        }
    }
}
