using DataAccess.Abstarct;
using Entitiy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class InstructorRepository : IInstructorRepository
    {


        private readonly List<Instructor> _instructors = new();

        //yeni bir akademisyen ekler
        public void Add(Instructor entity)
        {
            _instructors.Add(entity);
        }

        // akademisyen bilgilerini günceller
        public void Update(Instructor entity)
        {
            var instructor = _instructors.FirstOrDefault(i => i.InstructorId == entity.InstructorId);
            if (instructor != null)
            {
                instructor.FirstName = entity.FirstName;
                instructor.LastName = entity.LastName;
                instructor.Email = entity.Email;
                instructor.Department = entity.Department;
            }
        }

        // bir akademisyen siler
        public void Delete(Instructor entity)
        {
            _instructors.Remove(entity);
        }

        // id degerine göre kayıt getirir
        public Instructor GetById(int id)
        {
            return _instructors.FirstOrDefault(i => i.InstructorId == id);
        }

        // tüm akademisyenleri getirir
        public List<Instructor> GetAll()
        {
            return _instructors;
        }

        //görevlerine göre akademisyen getirir
        public List<Instructor> GetInstructorsByDepartment(string department)
        {
            return _instructors.Where(i => i.Department == department).ToList();
        }
    
}
}
