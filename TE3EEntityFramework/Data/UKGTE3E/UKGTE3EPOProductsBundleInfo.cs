using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Data.UKGTE3E
{
    public class UKGTE3EPOProductsBundleInfo
    {
		public Guid ProductBundle_CCCID { get; set; }
		public string BundleCode { get; set; } = "";
		public string BundleDescription { get; set; } = "";
		public Guid ProductCodeID { get; set; } 
		public string ProductCode { get; set; } = "";
		public string ProductDescription { get; set; } = "";
		public string Category { get; set; } 
		public string ProductType { get; set; } = "";
		public string UOM { get; set; } = "";
		public string Manufacturer { get; set; } = "";
		public string ModelNum { get; set; } = "";
		public string Amount_CCC { get; set; } = "";
		public string Quantity { get; set; } = "";
		public string CurrentPONum { get; set; } = "";
	}

}
