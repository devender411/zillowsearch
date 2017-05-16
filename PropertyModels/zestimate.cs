using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyModels
{
    public class zestimate
	{
		public int MyProperty { get; set; }
		public string Currency { get; set; }
		public DateTime UpdatedDate { get; set; }
		public int Oneweekchange { get; set; }

		public int valueChangeDuration { get; set; }
		public string valueChangeCurrency { get; set; }
		public int valueChangeAmount { get; set; }
		public int valuationRangeLow { get; set; }
		public int valuationRangeHigh { get; set; }
		public int percentile { get; set; }
	
    }
}
