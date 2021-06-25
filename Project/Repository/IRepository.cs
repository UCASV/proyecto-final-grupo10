using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public interface IRepository <T>
    {
        List<T> GetAll();

        void Create(T item);

        void Delete(T item);

        void Update(T item);
    }
}
