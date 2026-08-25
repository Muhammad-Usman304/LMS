using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Edumin.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string RollNo { get; set; }
        public int ClassId { get; set; }
        public int GenderId { get; set; }
        public string MobileNumber { get; set; }
        public string ParentName { get; set; }
        public string ParentMobileNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }

        [ForeignKey("ClassId")]
        public ClassModel? Class { get; set; }

        [ForeignKey("GenderId")]
        public GenderModel? Gender { get; set; }
    }
}