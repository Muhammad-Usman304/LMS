using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Edumin.Models
{
    public class TeacherModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public DateTime JoiningDate { get; set; }

        public string Password { get; set; }
        public string MobileNumber { get; set; }

        public int GenderId { get; set; }
        public int DesignationId { get; set; }
        public int DepartmentId { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public string Education { get; set; }

        public string? ProfileImagePath { get; set; }

        // List/Grid View ke liye display fields
        public string? GenderName { get; set; }
        public string? DesignationName { get; set; }
        public string? DepartmentName { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
