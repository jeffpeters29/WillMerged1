using System.ComponentModel.DataAnnotations;
using System;
using Newtonsoft.Json;

namespace Qwill.ViewModels
{
    public class DateVm
    {
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }

        [JsonIgnore]
        public int Day { get; set; }
        [JsonIgnore]
        public int Month { get; set; }
        [JsonIgnore]
        public int Year { get; set; }

        public DateTime ToDate()
        {
            return new DateTime(Year,Month,Day);
        }
    }
}
