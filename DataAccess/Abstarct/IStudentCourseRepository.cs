using Entitiy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstarct
{
    public interface IStudentCourseRepository
    {

        void Add(StudentCourse studentCourse);
        void Delete(StudentCourse studentCourse);
        StudentCourse GetByStudentAndCourseId(int studentId, int courseId);
        List<StudentCourse> GetCoursesByStudentId(int studentId);
        List<StudentCourse> GetStudentsByCourseId(int courseId);
    }
}
