using DataAccess.Abstarct;
using DataAccess.Context;
using Entitiy.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class CourseRepository : ICourseRepository
    {

        private readonly bysContext _context;
        private readonly DbSet<Course> _courses;

        public CourseRepository(bysContext context)
        {
            _context = context;
            _courses = context.Set<Course>(); // DbSet<Course> veritabanı ile etkileşim sağlar
        }
        
       

        // kurs ekleme
        public void Add(Course entity)
        {
            _courses.Add(entity);
            _context.SaveChanges();
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
            _context.SaveChanges();
        }

        // kurs kaydı silme
        public void Delete(Course entity)
        {
            _courses.Remove(entity);
            _context.SaveChanges();
        }

        //ıd göre kurs getirme
        public Course GetById(int id)
        {
            return _courses.FirstOrDefault(c => c.CourseId == id);
        }

        //tüm kursları listeleme
        public List<Course> GetAll()
        {
            return _courses.ToList(); ;
        }

        // akademisyen ıd degerine göre kurs listeleme
        public List<Course> GetCoursesByInstructorId(int instructorId)
        {
            return _courses.Where(c => c.InstructorId == instructorId).ToList();
        }
    }
}
