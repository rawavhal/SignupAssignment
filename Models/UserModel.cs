using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Signup.Attributes;

namespace Signup.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Please Enter Name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Username.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter Password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name="Confirm Password")]
        [Required(ErrorMessage = "Please Enter Confirm Password.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password should match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage ="Please enter Contact Number.")]
        [RegularExpression("[6,7,8,9][0-9]{9}")]
        [StringLength(10, MinimumLength =10,ErrorMessage ="Please enter 10 digits.")]
        public string Contact { get; set; }

        [Required(ErrorMessage ="Please select Country.")]
        public string Country { get; set; }
        public List<Country> CountryList { get; set; }

        [Required(ErrorMessage = "Please select City.")]
        public string City { get; set; }
        public List<City> CityList { get; set; }

        [Required(ErrorMessage = "Please select Gender.")]        
        public string Gender { get; set; }      

        [ValidateCheckBox(ErrorMessage ="Please Accept Terms.")]
        [Display(Name ="Accept Terms")]
        public bool Terms { get; set; }

    }

    public class Country
    {
        public int CountryId { get; set; }

        public string CountryName { get; set; }
    }

    public class City
    {
        public int CountryId { get; set; }

        public int CityId { get; set; }

        public string CityName { get; set; }
    }
   
}
