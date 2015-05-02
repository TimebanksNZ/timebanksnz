using System.Collections.Generic;
using TimebanksNZ.DAL;
using TimebanksNZ.DAL.Entities;

namespace TimebanksNZ
{
    /// <summary>
    /// Customized methods for Timebank data access
    /// </summary>
    public interface ITimebankRepository : IRepository<Timebank>
    {
        List<Timebank> GetAll();
    }
}