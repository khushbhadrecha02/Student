using System.Data;

namespace StudentDemo.Areas.MST_Student.Models
{
    public class MST_StudentModel
    {
        public int?  StudentID { get; set; }
        public int BranchID { get; set; }
        public int CityID { get; set; }
        public string StudentName { get; set; }
        public string MobileNoStudent { get; set; }
        public string MobileNoFather { get; set; }
        public string Address { get; set;}
        public DateTime BirthDate { get; set; }
        public int age { get; set; }
        public string IsActive { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public IFormFile File { get; set; }
        public string PhotoPath { get; set; }
    }
    public class MST_Student_SearchModel
    {

        public string? StudentName { get; set; }
        public int? CityID { get; set; }
        public int? BranchID { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public string? IsActive { get; set; }
        public string PhotoPath { get; set; }
    }
    public class MST_Student_ViewModel
    {
        public DataTable StudentDataTable { get; set; }
        public MST_Student_SearchModel SearchModel { get; set; }
    }
}
