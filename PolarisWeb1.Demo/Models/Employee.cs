using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PolarisWeb1.Demo.Models
{
    public class Employee
    {
        /// Primary Key - Auto-incremented
            public int Id { get; set; }


            [Required(AllowEmptyStrings = false)]
            [StringLength(6)]
            // [Index(IsUnique = true)]
            //[IndexColumn(IsUnique = true)] // .Net Core
            [MinLength(6, ErrorMessage = "Employee Code should be 6 Characters. Ex: M10054")]
            public string Code { get; set; }



            [Required(AllowEmptyStrings = false)]
            [StringLength(32)]
            [MinLength(3, ErrorMessage = "First Name should be 3 to 32 Characters")]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }


            [StringLength(32)]
            [MinLength(3, ErrorMessage = "Last Name should be 3 to 32 Characters")]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }


            [NotMapped]
            public string FullName
            {
                get
                {
                    return FirstName + " " + LastName;
                }
            }


            [Display(Name = "Date of Joining")]
            [DataType(DataType.DateTime), DisplayFormat(DataFormatString =  "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            public DateTime? DOJ { get; set; }


            [Required]
            [Phone]
            [RegularExpression(@"\d{10}", ErrorMessage = "10 digits numbers only -Example: 9512341234")]
            [StringLength(10)]
            //[MinLength(10, ErrorMessage = "Mobile Phone should be in 10 digits 1234567890 format")]
             public string Mobile { get; set; }


             [Required]
             [EmailAddress]
             [StringLength(128)]
             //[MinLength(128, ErrorMessage = "Email Phone should be in raj@mail.com format")]
             public string Email { get; set; }



             [DisplayFormat(NullDisplayText = "No Department")]
             [Display(Name = "Department")]
             public virtual int? DepartmentId { get; set; }


             [ForeignKey("DepartmentId")]
             public virtual Department Department { get; set; }
    }
}