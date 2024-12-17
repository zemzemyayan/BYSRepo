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
    public class CourseManager : ICourseService
    {

        // bu katmana iş kuralları yazılır ama biz en temel metotları yazdık(crud)
        //Kullanıcı girişleri ya da bir işlemin gereksinimlerinin doğru olup olmadığını kontrol eder vb.

        private readonly ICourseRepository _courseRepository;

        public CourseManager(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void TAdd(Course entity)
        {
            _courseRepository.Add(entity);
        }

        public void TUpdate(Course entity)
        {
            _courseRepository.Update(entity);
        }

        public void TDelete(Course entity)
        {
            _courseRepository.Delete(entity);
        }

        public Course TGetById(int id)
        {
            return _courseRepository.GetById(id);
        }

        public List<Course> TGetAll()
        {
            return _courseRepository.GetAll();
        }


    }
}

