using Shop;
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

namespace PlaidShirts.Views
{
	/// <summary>
	/// Логика взаимодействия для ListStorage.xaml
	/// </summary>
	public partial class ListStorage : Window
	{
		StoreOperations storeOperations = new StoreOperations();
		Logger logger = new Logger();
		public ListStorage()
		{
			InitializeComponent();
			dataGridProducts.ItemsSource = storeOperations.InputStorage();
		}
		private void Back_Click(object sender, RoutedEventArgs e)
		{
			logger.Action("Нажата кнопка ''На главную страницу'' ");
			MainWindow main = new MainWindow();
			Close();
			main.Show();
		}
	}
}
