using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidaysApplication.Repository.IRepository
{
    public interface IUnitOfWork: IDisposable
    {
        IHolidayRepository Holidays { get; }
        int Complete();
        
    }
}
