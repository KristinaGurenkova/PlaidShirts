using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Xml.Linq;
using Shop;
using Shop.DataBase;

namespace PlaidShirts.Views
{
	/// <summary>
	/// Логика взаимодействия для ControlPanelWin.xaml
	/// </summary>
	public partial class ControlPanelWin : Window
	{
		PlaidShirtsEntities shirtsEntities = new PlaidShirtsEntities();
		Logger logger = new Logger();
		public ControlPanelWin()
		{
			InitializeComponent();
			dataGridProducts.ItemsSource = shirtsEntities.Product.ToList();
			dataGridProducts.IsReadOnly = true;
		}
		private void Add_Click(object sender, RoutedEventArgs e)
		{
			logger.Action("Нажата кнопка ''Добавить''");
			try
			{
				Product product = new Product()
				{
					nameProduct = nameTxt.Text,
					barcode = int.Parse(barcodeTxt.Text),
					price = int.Parse(priceTxt.Text),
					idManufacturer = 1,
					idType = 1,
					count = int.Parse(countProduct.Text)
				};
				int barc = int.Parse(barcodeTxt.Text);
				shirtsEntities.Product.Add(product);
				shirtsEntities.SaveChanges();
				var idProd = shirtsEntities.Product.Where(y => y.barcode == barc).Select(n => n.idProduct).Single();
				Storage storage = new Storage()
				{
					idProduct = idProd,
					countProduct = int.Parse(countProduct.Text),
				};
				shirtsEntities.Storage.Add(storage);
				shirtsEntities.SaveChanges();
				dataGridProducts.ItemsSource = shirtsEntities.Product.ToList();
			}
			catch
			{
				MessageBox.Show("Не все данные были введены корректно");
			}
		}
		private void Change_Click(object sender, RoutedEventArgs e)
		{
			logger.Action("Нажата кнопка ''Изменить''");
			try
			{
				var p = dataGridProducts.SelectedItem as Product;
				p.nameProduct = nameTxt.Text;
				p.barcode = Convert.ToInt32(barcodeTxt.Text);
				p.idManufacturer = 1;
				p.price = Convert.ToInt32(priceTxt.Text);
				p.count = Convert.ToInt32(countProduct.Text);
				shirtsEntities.SaveChanges();
			}
			catch
			{
				MessageBox.Show("Не все данные были введены корректно");
			}
			dataGridProducts.ItemsSource = shirtsEntities.Product.ToList();
		}
		private void Delete_Click(object sender, RoutedEventArgs e)
		{
			logger.Action("Нажата кнопка ''Удалить''");
			try
			{
				var x = dataGridProducts.SelectedItem as Product;
				shirtsEntities.Product.Remove(x);
				shirtsEntities.SaveChanges();
				dataGridProducts.ItemsSource = shirtsEntities.Product.ToList();
			}
			catch
			{
				MessageBox.Show("Товар не был выбран");
			}
		}

		private void InHall_Click(object sender, RoutedEventArgs e)
		{
			logger.Action("Нажата кнопка ''Переместить в зал''");
			var x = dataGridProducts.SelectedItem as Product;
			var s = shirtsEntities.Storage.Where(m => m.idProduct == x.idProduct).Single();
			try
			{
				if (x.count == 0)
				{
					MessageBox.Show("Весь товар в зале");
				}
				else
				{
					var r = shirtsEntities.Hall.Where(y => y.idProduct == x.idProduct).Single();
					r.countProduct += int.Parse(coutInHallTxt.Text);
					x.count -= int.Parse(coutInHallTxt.Text);
					s.countProduct -= int.Parse(coutInHallTxt.Text);
				}
			}
			catch
			{
				Hall hall = new Hall()
				{
					idProduct = x.idProduct,
					countProduct = Convert.ToInt32(coutInHallTxt.Text)
				};
				shirtsEntities.Hall.Add(hall);
				x.count -= int.Parse(coutInHallTxt.Text);
				s.countProduct -= int.Parse(coutInHallTxt.Text);
				shirtsEntities.SaveChanges();
			}
			finally
			{
				shirtsEntities.SaveChanges();
			}
			dataGridProducts.ItemsSource = shirtsEntities.Product.ToList();
		}

		private void Back_Click(object sender, RoutedEventArgs e)
		{
			logger.Action("Нажата кнопка ''На главную страницу''");
			MainWindow mainWindow = new MainWindow();
			Close();
			mainWindow.Show();
		}
		private void dataGridProducts_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
		{
			try
			{
				var p = dataGridProducts.SelectedItem as Product;
				nameTxt.Text = p.nameProduct;
				priceTxt.Text = p.price.ToString();
				barcodeTxt.Text = p.barcode.ToString();
				countProduct.Text = p.count.ToString();
			}
			catch {}
		}
	}
}
