﻿using DataAccess.Abstarct;
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
    public class StudentCourseRepository : IStudentCourseRepository
    {

        private readonly bysContext _context;
        private readonly DbSet<StudentCourse> _studentCourses;

        public StudentCourseRepository(bysContext context)
        {
            _context = context;
            _studentCourses = context.Set<StudentCourse>(); // DbSet<Course> veritabanı ile etkileşim sağlar
        }

        // yeni bir StudentCourse kaydı ekleme
        public void Add(StudentCourse studentCourse)
        {
            _studentCourses.Add(studentCourse);
        }

        // StudentCourse kaydı silme
        public void Delete(StudentCourse studentCourse)
        {
            _studentCourses.Remove(studentCourse);
        }

        // belli bir ders veya öğrenci id degerine göre StudentCourse kaydı getirme
        public StudentCourse GetByStudentAndCourseId(int studentId, int courseId)
        {
            return _studentCourses.FirstOrDefault(sc => sc.StudentId == studentId && sc.CourseId == courseId);
        }


        // id degerine ait öğrencinin aldığı tüm  StudentCourse kaydı getir group by
        public List<StudentCourse> GetCoursesByStudentId(int studentId)
        {
            return _studentCourses.Where(sc => sc.StudentId == studentId).ToList();
        }

        // Belirli bir derse kayıtlı tüm öğrencileri getir
        public List<StudentCourse> GetStudentsByCourseId(int courseId)
        {
            return _studentCourses.Where(sc => sc.CourseId == courseId).ToList();
        }
    }
}
