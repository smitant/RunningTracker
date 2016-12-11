using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Threading;

namespace RunningTracker.Models.DataEntryModels
{
    
    public class DataEntryViewModel
    {
        DateTime currentDate = DateTime.Now;


        [Key]
        public int ID { get; set; }
        [Required]
        [Range(10, 300, ErrorMessage = "Heart value must be reasonable, ie; 10-300 bps")]
        public int HeartrateMin { get; set; }
        [Required]
        [Range(10, 300, ErrorMessage = "Heart value must be reasonable, ie; 10-300 bps")]
        public int HeartrateMax { get; set; }
        [Required]
        [Range(10, 300, ErrorMessage = "Heart value must be reasonable, ie; 10-300 bps")]
        public int HeartrateAvg { get; set; }
        [Range(0, 100000, ErrorMessage = "steps must be reasonable, ie; non-negative and <100000")]
        public int Steps { get; set; }
        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [CustomDateRange(ErrorMessage = "Cannot be a date in the future now 100 years in the past")]
        public DateTime Date { get; set; }
        [ForeignKey("UserName")]
        public string Username { get; set; }




    }


    public class CustomDateRangeAttribute : RangeAttribute
    {

        public CustomDateRangeAttribute() : base(typeof(DateTime), DateTime.Now.AddYears(-100).ToString(), DateTime.Now.ToString())
        { }
    }

}
