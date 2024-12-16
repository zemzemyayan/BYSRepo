using Entitiy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstarct
{
    public interface IStudentRepository : IEntityRepository<Student>
    {
        // Student özel metotlar buraya eklenebilir
        List<Student> GetStudentsByCourseId(int courseId);

    }
}
