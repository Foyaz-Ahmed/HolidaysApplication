using HolidaysApplication.Data;
using HolidaysApplication.Models;
using HolidaysApplication.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidaysApplication.Repository
{
    public class HolidayRepository: GenericRepository<Holiday>, IHolidayRepository
    {
        public HolidayRepository(ApplicationDbContext context) : base(context)
        {
        }

        public bool checkDuplicacy(string date, string countryCode)
        {
            var getDate = Convert.ToDateTime(date);
            var f = ((DateTime)getDate).ToString(@"yyyy-MM-dd");
            bool check = _context.Holidays.Any(x => x.Date.Date.ToString() == f.ToString() && x.CountryCode == countryCode);
            return check; 
        }

        public  List<Holiday> GetHolidaysByCountryYear(string countryCode, string year, string fromDate, string toDate)
        {
            if (countryCode != null)
            {
                var concatYearfromDate = (fromDate + "/" + year);
                var frmDt = Convert.ToDateTime(concatYearfromDate);
                var fDate = ((DateTime)frmDt).ToString(@"yyyy-MM-dd");
                var checkf = Convert.ToDateTime(fDate);
                var FromDateRange = checkf.Date;

                var concatYeartoDate = (toDate + "/" + year);
                var toDt = Convert.ToDateTime(concatYeartoDate);
                var tDate = ((DateTime)toDt).ToString(@"yyyy-MM-dd");

                var checkt = Convert.ToDateTime(tDate);
                var FromToRange = checkt.Date;

                var list =  _context.Holidays.Where(e => e.CountryCode == countryCode && e.Date.Year == Convert.ToInt32(year)
                    && (e.Date.Date) >= FromDateRange && (e.Date.Date) <= FromToRange).ToList();
                return list;
            }
            else
            {
                return null;
            }
        }
    }
}
