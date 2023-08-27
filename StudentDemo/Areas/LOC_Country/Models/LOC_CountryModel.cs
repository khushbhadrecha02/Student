using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentDemo.Areas.LOC_Country.Models
{
    public class LOC_CountryModel
    {
        
        public int? CountryID { get; set; }
        [Required]
        [DisplayName("Country Name")]
        public string CountryName { get; set; }
        [Required]
        [DisplayName("Country Code")]
        public string CountryCode { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

    }
    public class LOC_Country_DropDownModel
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; } 
    }
    public static class LOC_Country_SearchModel
    {
        public static string CountryName { get; set; }
        public static string CountryCode { get; set; }
    }
}
