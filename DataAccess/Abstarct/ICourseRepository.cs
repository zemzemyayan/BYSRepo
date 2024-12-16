using Entitiy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstarct
{
    public interface ICourseRepository : IEntityRepository<Course>
    {


        // Course özel metotlar buraya eklenebilir
        List<Course> GetCoursesByInstructorId(int instructorId);
    }
}
