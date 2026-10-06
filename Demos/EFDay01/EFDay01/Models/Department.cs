using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDay01.Models
{
    // Map  : FluentAPI
    // Code : OnModelCreating In DbContext
    //[Table("Depts")]
    internal class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
