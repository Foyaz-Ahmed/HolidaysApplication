using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HolidaysApplication.Models
{
    public class Holiday
    {
        [Key]
        public int  Id {set; get;}
        [DataType(DataType.Date)]
        public DateTime Date { set; get; }
        public string LocalName { set; get; }
        public string Name { set; get; }
        public string CountryCode { set; get; }
        public bool Fixed { set; get; }
        public bool Global { set; get; }
        public string Counties { set; get; }
        public string LaunchYear { set; get; }
        public string Types { set; get; }

    }
}
