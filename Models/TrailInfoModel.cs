using System.ComponentModel.DataAnnotations;

namespace Lost_in_the_Woods.Models
{
    public abstract class BaseEntity {}
    public class TrailInfo : BaseEntity
    {
        [Key]
        public long Id { get; set; }
 
        [Display(Name = "Trail Name: ")]
        [Required(ErrorMessage = "Trail Name is required!")]
        [MinLength(2, ErrorMessage = "Trail Name must contain at least 2 characters!")]
        public string Name { get; set; }

        [Display(Name = "Description: ")]
        [Required(ErrorMessage = "Trail Description is required!")]
        [MinLength(2, ErrorMessage = "Trail Description must contain at least 2 characters!")]
        public string Description { get; set; }

        [Display(Name = "Trail Length: ")]
        [Required(ErrorMessage = "Trail Length is required!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:n1}")]
        public double Length { get; set; }
 
        [Display(Name = "Elevation Change: ")]
        [Required(ErrorMessage = "Elevation Change is required!")]
        public int Gain { get; set; }

        [Display(Name = "Longitude")]
        [Required(ErrorMessage = "Longitude is required!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:n0}")]
        public double Long { get; set; }

        [Display(Name = "Latitude")]
        [Required(ErrorMessage = "Latitude is required!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:n0}")]
        public double Lat { get; set; }

    }
}