using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Edumin.Models
{
    public class GenderModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenderId { get; set; }
        public string GenderName { get; set; }
    }
}
