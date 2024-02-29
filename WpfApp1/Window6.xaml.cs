using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window6.xaml
    /// </summary>
    public partial class Window6 : Window
    {
        AppDbContext context;
        User user { get; set; }
        List<CartItem> cartItems { get; set; }
        public Window6(User u)
        {
            InitializeComponent();
            context = new AppDbContext();
            user = context.Users.Include(x => x.CartItems).Where(x => x.Id == u.Id).FirstOrDefault();
            cartItems = context.CartItems.Include(x => x.Product).Where(x => user.CartItems.Contains(x)).ToList();
            UpdateMenu();
        }

        private void UpdateMenu()
        {
            bool e = false;
            foreach (Product product in context.Products)
            {
                Grid grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100) });
                grid.RowDefinitions.Add(new RowDefinition() {  Height = new GridLength(100) });
                grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(30) });

                Image image = new Image();
                try
                {
                    image.Source = new BitmapImage(new Uri(Path.Combine(Environment.CurrentDirectory, "Pictures", product.Photo)));
                }
                catch
                {
                    e = true;
                }
                image.SetValue(Grid.RowProperty, 0);

                Button button = new Button();
                button.Content = "Добавить";
                button.Foreground = Brushes.Black;
                var converter = new BrushConverter();
                button.Background = (Brush)converter.ConvertFrom("#EE9B01");
                button.FontWeight = FontWeights.Bold;
                button.FontSize = 20;
                button.Name = $"p_{product.Id}";
                button.Click += new RoutedEventHandler(AddItem);
                button.SetValue(Grid.RowProperty, 1);

                grid.Children.Add(image);
                grid.Children.Add(button);

                wp_menu.Children.Add(grid);
                MessageBox.Show("-");
            }
            if (e) MessageBox.Show("Возникли ошибки при загрузке изображений, проверьте имена файлов");
        }

        private void AddItem(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
  