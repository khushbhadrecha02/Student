using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;

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



    }
    public class LOC_Country_DropDownModel
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; } 
    }
    public class LOC_Country_SearchModel
    {
        
        public  string? CountryName { get; set; }
        public string? CountryCode { get; set; }
    }
    public class LOC_Country_ViewModel
    {
        public DataTable CountryDataTable { get; set; }
        public LOC_Country_SearchModel SearchModel { get; set; }
    }

}
