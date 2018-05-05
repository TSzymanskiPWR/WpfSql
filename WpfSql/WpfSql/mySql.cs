using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;

namespace WpfSql
{
    public class MySql
    {
        string provider = ConfigurationManager.AppSettings["provider"];
        string connectionString = ConfigurationManager.AppSettings["connectionString"];
        DbProviderFactory factory { get; set; }
        public DbConnection connection { get; set; }
        
        public void OpenConnection()
        {
            //connection = factory.CreateConnection();

                if (connection == null)
                {
                    //TextBoxCons.Text = "Notconnected\n";
                    return;

                }
                connection.ConnectionString = connectionString;
                connection.Open();


        }

        public string ReadD()
        {
            DbCommand command = factory.CreateCommand();
            string carryData = "";
            if (command == null)
            {
                //TextBoxCons.Text = "Command error\n";
                return "CMD error";
            }

            command.Connection = connection;
            command.CommandText = "Select * From Products";
            using (DbDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    carryData += ($"{dataReader["Id"]}" + $"{dataReader["Product"]}" + "\n");
                }
                return carryData;
            }

        }

        public string InsertD()
        {
            DbCommand command = factory.CreateCommand();
           // string carryData = "";
            if (command == null)
            {
                //TextBoxCons.Text = "Command error\n";
                return "CMD error";
            }

            command.Connection = connection;
            command.CommandText = "INSERT INTO Products (Id, Product, Price) VALUES ('8', 'Lawenda', '5.4') ";

            command.ExecuteNonQuery();
            return "ok";
        }



        public MySql()
        {
        this.factory = DbProviderFactories.GetFactory(provider);
        this.connection = factory.CreateConnection();
        }

    }




}
