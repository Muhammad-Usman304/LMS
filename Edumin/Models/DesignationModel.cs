using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Edumin.Models
{
    public class DesignationModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
    }
}
