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
using System.Windows.Shapes;
using Shop;
using Shop.DataBase;

namespace PlaidShirts.Views
{
	/// <summary>
	/// Логика взаимодействия для BasketWin.xaml
	/// </summary>
	public partial class BasketWin : Window
	{
		PlaidShirtsEntities shirtsEntities = new PlaidShirtsEntities();
		Logger logger = new Logger();
		public BasketWin()
		{
			InitializeComponent();
			Update();
			dataGridProducts.IsReadOnly = true;
		}
		public void Update()
		{
			dataGridProducts.ItemsSource = shirtsEntities.Basket.ToList();
			sumTxt.Text = " К формлению:  " + Counting();
		}
		private void TicketBt_Click(object sender, RoutedEventArgs e)
		{
			logger.Action("Нажата кнопка ''Получить чек''");
			TicketWin ticket = new TicketWin();
			Close();
			ticket.Show();
		}
		public string Counting()
		{
			double sum = 0;
			var list = new List<double?>();
			list = shirtsEntities.Basket.Select(m => m.sum).ToList();
			foreach (double summ in list)
			{
				sum += summ;
			}
			return sum.ToString();
		}
		private void Delete_Click(object sender, RoutedEventArgs e)
		{
			logger.Action("Нажата кнопка ''Удалить из корзины''");
			try
			{
				var m = dataGridProducts.SelectedItem as Basket;
				try
				{
					var r = shirtsEntities.Product.Where(y => y.idProduct == m.idProduct).Single();
					r.count++;
					m.count--;
					m.sum -= r.price;
				}
				catch
				{}
				finally
				{
					if (m.count == 0)
					{
						shirtsEntities.Basket.Remove(m);
					}
					shirtsEntities.SaveChanges();
				}
			}
			catch
			{
				MessageBox.Show("Вы не выбрали товар");
			}
			Update();
		}
		private void Back_Click(object sender, RoutedEventArgs e)
		{
			logger.Action("Нажата кнопка ''На главную страницу''");
			MainWindow mainWindow = new MainWindow();
			Close();
			mainWindow.Show();
		}
	}
}
