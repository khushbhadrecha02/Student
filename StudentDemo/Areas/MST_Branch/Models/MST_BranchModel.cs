using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace StudentDemo.Areas.MST_Branch.Models
{
    public class MST_BranchModel
    {
        
        public int? BranchID { get; set; }
        [Required]
        [DisplayName("Branch Name")]
        public string BranchName { get; set; }
        [Required]
        [DisplayName("Branch Code")]
        public string BranchCode { get; set; }

    }
    public class MST_Branch_DropDownModel
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
    }
    public class MST_Branch_SearchModel
    {

        public string? BranchName { get; set; }
        public string? BranchCode { get; set; }
    }
    public class MST_Branch_ViewModel
    {
        public DataTable BranchDataTable { get; set; }
        public MST_Branch_SearchModel SearchModel { get; set; }
    }
}
