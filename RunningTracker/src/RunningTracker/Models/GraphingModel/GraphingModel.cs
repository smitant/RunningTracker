using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models.GraphingModel
{
    public class GraphingModel
    {
        [Key]
        public int ID { get; set; }
        public int HeartrateMin { get; set; }
        public int HeartrateMax { get; set; }
        public int HeartrateAvg { get; set; }
        public int Steps { get; set; }
        public DateTime Date { get; set; }

    }
}
