using OnlineShop.Domain.ViewModels.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.ViewModels.Page
{
	public class ItemPagesViewModel
	{
		public List<ItemViewModel> Items { get; set; }
		public PageViewModel PageViewModel { get; set; }
	}
}
