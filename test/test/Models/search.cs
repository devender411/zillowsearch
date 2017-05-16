using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace test.Models
{
    public class StreetSearch
    {
		[Required(ErrorMessage = "Please enter street address")]
		[Display(Name = "Street:")]
		public string Street { get; set; }
		public string City { get; set; }
		public int Zip { get; set; }
	}
}
