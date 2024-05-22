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
	/// Логика взаимодействия для TicketWin.xaml
	/// </summary>
	public partial class TicketWin : Window
	{
	    StoreOperations storeOperations = new StoreOperations();
		PlaidShirtsEntities shirtsEntities = new PlaidShirtsEntities();
		Logger logger = new Logger();
		public TicketWin()
		{
			InitializeComponent();
			dataGridProducts.ItemsSource = storeOperations.Ticket();
			dataGridProducts.IsReadOnly = true;
			sumTxt.Text = "Сумма: " + Counting();
		}
		private void Back_Click(object sender, RoutedEventArgs e)
		{
			logger.Action("Нажата кнопка ''На главную страницу''");
			MainWindow mainWindow = new MainWindow();
			var x = shirtsEntities.Basket.ToList();
			shirtsEntities.Basket.RemoveRange(x);
			shirtsEntities.SaveChanges();
			Close();
			mainWindow.Show();
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
	}
}
