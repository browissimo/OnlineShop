using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entity
{
	public class Size
	{
		public int Id { get; set; }
		public int Value { get; set; } = 0;
		public List<Item> items { get; set; } = new ();
		public List<ItemColor> itemColorsSizes { get; set; } = new();
	}
}
