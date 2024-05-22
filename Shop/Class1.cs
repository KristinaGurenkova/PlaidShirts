using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.DataBase;

namespace Shop
{
	public class StoreOperations
	{
		PlaidShirtsEntities shirtsEntities = new PlaidShirtsEntities();
		public List<DataBase.Hall> InputHall()
		{
			var listProd = shirtsEntities.Hall.ToList();
			return listProd;
		}
		public List<DataBase.Storage> InputStorage()
		{
			var listProd = shirtsEntities.Storage.ToList();
			return listProd;
		}
		public List<DataBase.Basket> Ticket()
		{
			var listProd = shirtsEntities.Basket.ToList();
			return listProd;
		}
	}
}
