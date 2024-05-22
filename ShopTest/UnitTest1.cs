using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Shop;
using Shop.DataBase;
using System.Collections.Generic;

namespace ShopTest
{
	[TestClass]
	public class ShopTest
	{
		StoreOperations storeOperations = new StoreOperations();
		[TestMethod]
		public void TestMethod_InputStorage()
		{
			List<Shop.DataBase.Storage> list = storeOperations.InputStorage();
			Assert.IsNotNull(list);
		}
		[TestMethod]
		public void TestMethod_InputHall()
		{
			List<Shop.DataBase.Hall> list1 = storeOperations.InputHall();
			Assert.IsNotNull(list1);
		}
		[TestMethod]
		public void TestMethod_Ticket()
		{
			List<Shop.DataBase.Basket> list = storeOperations.Ticket();
			Assert.IsNotNull(list);
		}
	}
}
