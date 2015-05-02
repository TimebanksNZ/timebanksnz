using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TimebanksNZ.DAL.Entities;

namespace TimebanksNZ.DAL
{
    public interface IRepository<T>
    {
        void Update(T entity);
        void Insert(T entity);
        T Get(T entity);
        void Delete(T entity);
    }

}
