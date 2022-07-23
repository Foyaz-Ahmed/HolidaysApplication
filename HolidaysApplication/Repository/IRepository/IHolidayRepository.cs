using HolidaysApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidaysApplication.Repository.IRepository
{
    public interface IHolidayRepository : IGenericRepository<Holiday>
    {
        List<Holiday> GetHolidaysByCountryYear(string countryCode, string year, string fromDate, string toDate);
        bool checkDuplicacy(string date, string countryCode);
    }
}
