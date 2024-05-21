using System.ComponentModel.DataAnnotations;

namespace MambaPractica.ViewModel
{
	public class CreateMambaVm
	{
		[Required]
		public string ImageUrl { get; set; }

		[Required,MinLength(3)]
		public string Name { get; set; }
		[Required, MinLength(3)]
		public string profession { get; set; }
		[Required, MinLength(3)]
		public string Icons { get; set; }
	}
}
