using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PolarisWeb1.Demo.Models
{
    public class Department
    {
        public int Id { get; set; }
        //public int DepartmentId { get; set; }
        //[Required(AllowEmptyStrings = true)]
        [Required(AllowEmptyStrings = false,ErrorMessage = "Department Name is required !")]
        [StringLength(64, ErrorMessage = "Maximum of 64 Characters only !")]
        [MinLength(2, ErrorMessage = "Minimum of 2 Characters required !")]
        [Index(IsUnique = true)]
        //[IndexColumn(IsUnique = true)] // .Net Core
        [Display(Name = " Department Name")]
        public string Name
        {
            get; set;
        }
    }
}