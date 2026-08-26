using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Edumin.Models
{
    public class ClassModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassId { get; set; }
        public string ClassName { get; set; }
    }
}
