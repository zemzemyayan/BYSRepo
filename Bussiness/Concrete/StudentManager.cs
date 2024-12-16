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
    public class StudentManager : IStudentService
    {

        private readonly IStudentRepository _studentRepository;

        public StudentManager(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void TAdd(Student entity)
        {
            _studentRepository.Add(entity);
        }

        public void TUpdate(Student entity)
        {
            _studentRepository.Update(entity);
        }

        public void TDelete(Student entity)
        {
            _studentRepository.Delete(entity);
        }

        public Student TGetById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public List<Student> TGetAll()
        {
            return _studentRepository.GetAll();
        }
    }
}
