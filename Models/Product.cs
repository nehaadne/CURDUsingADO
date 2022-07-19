using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CURDUsingADO.Models
{
    //BO - business object / model class
    [Table("Product")]
    public class Product //POCO class(plain old c#/clr object)
    {
        [Key]
        [ScaffoldColumn(false)] //Identity
        public int Pid { get; set; }
        [Required(ErrorMessage ="Product name is required")]
        [DataType(DataType.Text)]
        [Display(Name ="Product Name")]
        public string Pname { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Product Price")]
        [Range(minimum:1,maximum:50000)]

        public double Price { get; set; }
    }
}
