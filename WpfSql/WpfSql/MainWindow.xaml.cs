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
using System.Configuration;
using System.Data.Common;

namespace WpfSql
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        MySql msql = new MySql();

        public MainWindow()
        {
            InitializeComponent();
            TextBoxCons.Text = "Initzialized\n";
            OpenB.Visibility = System.Windows.Visibility.Visible;

        }

        public void OpenB_Click(object sender, RoutedEventArgs e)
        {
            msql.OpenConnection();
            OpenB.Visibility = System.Windows.Visibility.Hidden;
            TextBoxCons.Text = "Connected\n";
        }


        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            TextBoxCons.Text = msql.ReadD();
        }

        private void TestInsert_click(object sender, RoutedEventArgs e)
        {
            TextBoxCons.Text = msql.InsertD();
        }
    }
}
