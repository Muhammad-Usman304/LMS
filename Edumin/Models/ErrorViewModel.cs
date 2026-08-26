using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Edumin.Models
{
	public class ErrorViewModel
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? RequestId { get; set; }

		public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
	}
}