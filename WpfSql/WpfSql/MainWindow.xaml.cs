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

 

        public MainWindow()
        {

            InitializeComponent();








        }

        public void OpenB_Click(object sender, RoutedEventArgs e)
        {
            string provider = ConfigurationManager.AppSettings["provider"];
            string connectionString = ConfigurationManager.AppSettings["connectionString"];
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);

            using (DbConnection connection = factory.CreateConnection())
            {
                if(connection == null)
                {
                    TextBoxCons.Text = "Notconnected\n";
                    return;

                }
                connection.ConnectionString = connectionString;
                connection.Open();

                DbCommand command = factory.CreateCommand();

                if (command == null)
                {
                    TextBoxCons.Text = "Command error\n";
                    return;
                }

                command.Connection = connection;
                command.CommandText = "Select * From Products";
                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    while(dataReader.Read())
                    {
                        TextBoxCons.Text += ($"{dataReader["Id"]}" + $"{dataReader["Product"]}");
                    }

                }

            }

        }

        private void ReadData_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
