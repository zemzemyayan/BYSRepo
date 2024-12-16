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
    public class InstructorManager : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorManager(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public void TAdd(Instructor entity)
        {
            _instructorRepository.Add(entity);
        }

        public void TUpdate(Instructor entity)
        {
            _instructorRepository.Update(entity);
        }

        public void TDelete(Instructor entity)
        {
            _instructorRepository.Delete(entity);
        }

        public Instructor TGetById(int id)
        {
            return _instructorRepository.GetById(id);
        }

        public List<Instructor> TGetAll()
        {
            return _instructorRepository.GetAll();
        }

    }
}
