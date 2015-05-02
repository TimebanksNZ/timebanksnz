using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimebanksNZ.DAL;
using TimebanksNZ.DAL.Entities;

namespace TImebanksNZ.DAL.Mock
{
    public class MockRepository<T>: IRepository<T> where T : new()
    {
        public void Update(T entity)
        {
                       
        }

        public void Insert(T entity)
        {

        }

        public T Get(T entity)
        {
            return new T();
        }

        public void Delete(T entity)
        {
        }
    }
}
