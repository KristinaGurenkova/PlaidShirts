using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.DataBase;

namespace Shop
{
	/// <summary>
	/// Класс Shop предназначен для работы с базой данных
	/// </summary>
	public class StoreOperations
	{
		PlaidShirtsEntities shirtsEntities = new PlaidShirtsEntities();
		/// <summary>
		/// Метод InputHall предназначен для вывода списка товаров в зале
		/// </summary>
		public List<DataBase.Hall> InputHall()
		{
			var listProd = shirtsEntities.Hall.ToList();
			return listProd;
		}
		/// <summary>
		/// Метод InputStorage предназначен для вывода списка товаров на складе
		/// </summary>
		public List<DataBase.Storage> InputStorage()
		{
			var listProd = shirtsEntities.Storage.ToList();
			return listProd;
		}
		/// <summary>
		/// Метод Ticket предназначен для формирования чека
		/// </summary>
		public List<DataBase.Basket> Ticket()
		{
			var listProd = shirtsEntities.Basket.ToList();
			return listProd;
		}
	}
}
