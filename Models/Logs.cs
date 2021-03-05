using System;
using System.ComponentModel.DataAnnotations;

namespace Rufat_Soap_to_Rest.Models
{
    public class Logs
    {
        [Key]
        public int Id { get; set; }
        public int Parent_Id { get; set; }
        public DateTime Insert_Date { get; set; } = DateTime.Now;
        public string Value { get; set; }

        public Operations Operation { get; set; }
    }
}
