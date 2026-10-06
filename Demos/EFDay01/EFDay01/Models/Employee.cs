using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EFDay01.Models
{
    // EF : smart ORM : Default behavior >> configure(Customize)

    // Mapping this ?
    // ways of mapping :
    // 1- Convention(Default of EF)(implicit)
    // prop : public - numeric - ID/EntityId 
    // Convention_based Mapping

    // Explicit Map / Configure EF behavior : How ?
    // 2- Data annotations : Direct Map prop (set of attributes >> Map and Validation)
    // attriute_based Mapping 
    // [Direct  Mapping]  >> [  ]

    // 3- FluentAPI : Map models by code
    // Code_based Mapping
    // Project : a must (Clean)


    // 4- Configuration class per Entity

    internal class Employee
    {
        public int Id { get; set; } // Primary key+Identity(1,1) - not allow null
        public string EmpName { get; set; } //nvarchar(max) - allow null
        public decimal Salary { get; set; } //not allow null(Required) - decimal(18,2) 
        public int? Age { get; set; } //allow null 
    }



    ////[Table("Employees", Schema = "HR")]

    //[Table("Emps")]
    //// implicit mapping
    //internal class Employee
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int EmpId { get; set; }
    //    [Required]
    //    [Column(TypeName = "varchar")]
    //    [StringLength(50)]
    //    public string EmpName { get; set; }
    //    [Column(TypeName = "money")]
    //    public decimal Salary { get; set; }

    //    // implicit mapping
    //    public int? Age { get; set; }
    //}
}
