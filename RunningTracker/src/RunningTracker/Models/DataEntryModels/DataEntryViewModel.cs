using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunningTracker.Models.DataEntryModels
{
    public class DataEntryViewModel
    {
        [Key]
        public int ID { get; set; }
        public int Heartrate { get; set; }
        public int Steps { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [ForeignKey("UserName")]
        public string Username { get; set; }




}
}
