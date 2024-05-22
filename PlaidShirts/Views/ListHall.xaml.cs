using Shop.DataBase;
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
	/// Логика взаимодействия для ListHall.xaml
	/// </summary>
	public partial class ListHall : Window
	{
		PlaidShirtsEntities shirtsEntities = new PlaidShirtsEntities();
		Logger logger = new Logger();
		public ListHall()
		{
			InitializeComponent();
			dataGridProducts.ItemsSource = shirtsEntities.Hall.ToList();
			dataGridProducts.IsReadOnly = true;
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
