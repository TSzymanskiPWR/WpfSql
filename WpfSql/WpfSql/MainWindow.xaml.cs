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

namespace WpfSql
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        mySql msql = new mySql();
        public MainWindow()
        {
            InitializeComponent();

        }

        public void OpenB_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxCons.Text != "Connected")
            { TextBoxCons.Text = msql.mySQLopen(); }
            else { TextBoxCons.Text = msql.mySQLclose(); }
        }

        private void ReadData_Click(object sender, RoutedEventArgs e)
        {
            TextBoxCons.Text += msql.mySQLdataRead();
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            TextBoxCons.Text += msql.mySQLcmd();
            //TextBoxCons.Text += msql.mySQLdataRead();
        }
    }
}
