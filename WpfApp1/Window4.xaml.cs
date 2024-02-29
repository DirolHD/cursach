using Microsoft.EntityFrameworkCore;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        AppDbContext context;
        User user { get; set; }
        public Window4(User u)
        {
            InitializeComponent();
            context = new AppDbContext();
            user = context.Users.Include(x => x.CartItems).Where(x => x.Id == u.Id).FirstOrDefault();
        }

       

        private void b_catalog_Click(object sender, RoutedEventArgs e)
        {
            Window6 window6 = new Window6(user);
            window6.Show();
            this.Close();
        }

        private void b_logoff_Click(object sender, RoutedEventArgs e)
        {

        }

        private void b_buy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void b_clear_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
