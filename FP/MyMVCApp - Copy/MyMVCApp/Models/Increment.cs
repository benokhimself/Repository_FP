using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MyMVCApp.Models
{
    public class Increment
    {

        public int ID { get; set; } 
        [Range(0, 10)]
        public int counter { get; set; }
    }
    public class EmpDBContext:DbContext
    {
        //public EmpDBContext()
        //{ }

        public DbSet<Increment> Increment { get; set; }
    }
 
}