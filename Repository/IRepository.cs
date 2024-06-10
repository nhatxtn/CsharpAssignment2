using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T GetById(int id);
        T GetById(params object[] keyValues); // Chỉnh sửa phương thức GetById cho composite key
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }

}
