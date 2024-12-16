using DataAccess.Abstarct;
using Entitiy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class CourseRepository : ICourseRepository
    {

        private readonly List<Course> _courses = new();

        // kurs ekleme
        public void Add(Course entity)
        {
            _courses.Add(entity);
        }

        // kurs günvcelleme
        public void Update(Course entity)
        {
            var course = _courses.FirstOrDefault(c => c.CourseId == entity.CourseId);
            if (course != null)
            {
                course.CourseName = entity.CourseName;
                course.Credits = entity.Credits;
                course.InstructorId = entity.InstructorId;
            }
        }

        // kurs kaydı silme
        public void Delete(Course entity)
        {
            _courses.Remove(entity);
        }

        //ıd göre kurs getirme
        public Course GetById(int id)
        {
            return _courses.FirstOrDefault(c => c.CourseId == id);
        }

        //tüm kursları listeleme
        public List<Course> GetAll()
        {
            return _courses;
        }

        // akademisyen ıd degerine göre kurs listeleme
        public List<Course> GetCoursesByInstructorId(int instructorId)
        {
            return _courses.Where(c => c.InstructorId == instructorId).ToList();
        }
    }
}
