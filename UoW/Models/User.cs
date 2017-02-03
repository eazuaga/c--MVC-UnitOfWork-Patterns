using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UoW.Models
{
    public class User
    {
        [Key]
        //[DatabaseGenerated(databaseGeneratedOption:)]
        public int ID { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
    }
}