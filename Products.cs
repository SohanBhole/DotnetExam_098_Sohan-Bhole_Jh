using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _210940520098.Models
{
    public class Products
    {
        [Key]
        public int ProductId { set; get; }

        [Required(ErrorMessage="Please Enter Product Name")]
        public string ProductName { set; get; }

        [Required(ErrorMessage ="Enter Rate")]
        public decimal Rate { set; get; }
        
        [Required(ErrorMessage ="Description Please!")]
        public string Description{ set; get; }

        [Required(ErrorMessage ="Category name Please!")]
        public string CategoryName { set; get;}

    }
}