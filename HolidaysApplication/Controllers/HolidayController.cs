using HolidaysApplication.Models;
using HolidaysApplication.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidaysApplication.Controllers
{
    public class HolidayController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HolidayController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddHolidays([FromForm] List<Holiday> prm)
        {

            if (prm == null)
            {
                prm = new List<Holiday>();
            }

            //Loop and insert list of records.
            foreach (Holiday holiday in prm)
            {
                //check duplicate data
                bool check = checkDuplicacy(holiday.Date.ToString(), holiday.CountryCode);
                if (!check)
                {
                    _unitOfWork.Holidays.Add(holiday);
                }
                _unitOfWork.Complete();
            }
             
            return new JsonResult(new {Status = "Successfully Added to the Databse" });
        }

        [HttpGet]
        public  IActionResult GetAll(string countryCode, string year, string fromDate, string toDate)
        {
            var listOfHolidays =  _unitOfWork.Holidays.GetHolidaysByCountryYear(countryCode, year, fromDate, toDate);
            return Json(listOfHolidays);
        }
        public bool checkDuplicacy (string date, string countryCode)
        {
            var checkData = _unitOfWork.Holidays.checkDuplicacy(date, countryCode);

            return checkData;
        }

    }
}
