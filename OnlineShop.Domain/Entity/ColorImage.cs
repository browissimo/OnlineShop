using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entity
{
	public class ColorImage
	{
		public int Id { get; set; }
		//public string Name { get; set; }
		public string Url { get; set; }

		public int ItemColorId { get; set; }
		public ItemColor ItemColor { get; set; }

	}
}
