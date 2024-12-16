using Entitiy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstarct
{
    public interface IInstructorRepository : IEntityRepository<Instructor>
    {

        // Instructor özel metotlar buraya eklenebilir
        List<Instructor> GetInstructorsByDepartment(string department);
    }
}
