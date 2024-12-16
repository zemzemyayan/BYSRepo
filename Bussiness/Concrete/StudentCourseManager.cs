using Bussiness.Abstarct;
using DataAccess.Abstarct;
using Entitiy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class StudentCourseManager : IStudentCourseService
    {

        private readonly IStudentCourseRepository _studentCourseRepository;

        public StudentCourseManager(IStudentCourseRepository studentCourseRepository)
        {
            _studentCourseRepository = studentCourseRepository;
        }

        public void TAdd(StudentCourse entity)
        {
            _studentCourseRepository.Add(entity);
        }


        public void TDelete(StudentCourse entity)
        {
            _studentCourseRepository.Delete(entity);
        }

        public List<StudentCourse> GetCoursesByStudentId(int studentId)
        {
            return _studentCourseRepository.GetCoursesByStudentId(studentId);
        }

        public List<StudentCourse> GetStudentsByCourseId(int courseId)
        {
            return _studentCourseRepository.GetStudentsByCourseId(courseId);
        }

        public void TUpdate(StudentCourse entity)
        {
            throw new NotImplementedException();
        }

        public StudentCourse TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<StudentCourse> TGetAll()
        {
            throw new NotImplementedException();
        }
    }
}
