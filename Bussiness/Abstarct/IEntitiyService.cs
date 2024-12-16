using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstarct
{
    public interface IEntitiyService<T> where T : class, new()
    {
        void TAdd(T entity);
        void TUpdate(T entity);
        void TDelete(T entity);
        T TGetById(int id);
        List<T> TGetAll();
    }
}
