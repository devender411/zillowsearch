using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyModels
{
    public class PropertySet
    {
		public PropertySet()
		{
			address = new Address();
			estimate = new zestimate();
		}
		public Address address{ get; set; }
		public zestimate estimate { get; set; }
	}
}
