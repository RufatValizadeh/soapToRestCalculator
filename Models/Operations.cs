using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rufat_Soap_to_Rest.Models
{
    public class Operations
    {
        [Key]
        public int Id { get; set; }
        public DateTime Insert_Date { get; set; } = DateTime.Now;

        public ICollection<Logs> Logs { get; set; }
    }
}
