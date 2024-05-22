using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PlaidShirts.Views;
using Shop;
using Shop.DataBase;

namespace PlaidShirts
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Logger logger = new Logger();
		PlaidShirtsEntities shirtsEntities = new PlaidShirtsEntities();
		public MainWindow()
		{
			InitializeComponent();
			dataGridProducts.ItemsSource = shirtsEntities.Product.ToList();
			dataGridProducts.IsReadOnly = true;
		}

		private void AddInBasket_Click(object sender, RoutedEventArgs e)
		{
			AddBasket();
		}
		private void AddToBasket_Click(object sender, RoutedEventArgs e)
		{
			AddBasket();
		}

		private void Basket_Click(object sender, RoutedEventArgs e)
		{
			logger.Action("Нажата кнопка ''Корзина'' ");
			BasketWin basketWin = new BasketWin();
			Close();
			basketWin.Show();
		}

		private void ListStorage_Click(object sender, RoutedEventArgs e)
		{
			logger.Action("Нажата кнопка ''Список товаров на складе'' ");
			ListStorage listStorage = new ListStorage();
			Close();
			listStorage.Show();
		}

		private void Panel_Click(object sender, RoutedEventArgs e)
		{
			logger.Action("Нажата кнопка ''Панель управления'' ");
			ControlPanelWin controlPanelWin = new ControlPanelWin();
			Close();
			controlPanelWin.Show();
		}
		public void AddBasket()
		{
			logger.Action("Нажата кнопка ''Добавить в корзину'' ");
			try
			{
				var m = dataGridProducts.SelectedItem as Product;
				try
				{
					var r = shirtsEntities.Basket.Where(y => y.idProduct == m.idProduct).Single();
					m.count--;
					r.count++;
					r.sum = r.count * m.price;
				}
				catch
				{
					m.count--;
					Basket basket = new Basket()
					{
						idProduct = m.idProduct,
						count = 1,
						price = int.Parse(m.price.ToString()),
						sum = m.price
					};
					shirtsEntities.Basket.Add(basket);
				}
				finally
				{
					shirtsEntities.SaveChanges();
				}
			}
			catch
			{
				MessageBox.Show("Вы не выбрали товар");
			}
			dataGridProducts.ItemsSource = shirtsEntities.Product.ToList();
		}

		private void ListHall_Click(object sender, RoutedEventArgs e)
		{
			logger.Action("Нажата кнопка ''Список товаров в зале'' ");
			ListHall hall = new ListHall();
			Close();
			hall.Show();
		}
	}
}
