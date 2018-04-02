using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WpfSql
{
    public class mySql
    {
        string cmdtext;
        SqlConnection mySQLconn = new SqlConnection("user id=TS;" +
                                       "password=mysql;server=DESKTOP-S42SNTJ\\MYSQLINSTANCE;" +
                                       "Trusted_Connection=yes;" +
                                       "database=MySQL; " +
                                       "connection timeout=5");


        public string mySQLopen()
        {
            string ret = "";
            try
            {
                mySQLconn.Open();
                ret = "Connected\n";
            }
            catch(Exception e)
            {
                // TextBoxCons.Text(e.ToString());
                ret = "Error\n";
            }
            return ret;
}

        public string mySQLclose()
        {
            try
            {
                mySQLconn.Close();
            }
            catch (Exception e)
            {
                return "Error\n";
            }
            return "Disconnected\n";
        }

        public string mySQLcmd()
        {

            SqlCommand insertCommand = new SqlCommand("INSERT INTO MyTab (Name, Number) VALUES ('test string', 1234)", mySQLconn);

            // In the command, there are some parameters denoted by @, you can 
            // change their value on a condition, in my code they're hardcoded.

            //insertCommand.Parameters.Add(new SqlParameter("0", "test string"));
            //insertCommand.Parameters.Add(new SqlParameter("1", 12345));
            
            return "Inserted cmd\n";

        }

        public string mySQLdataRead()
        {
            string dataRead = "";
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("select * from MyTab", mySQLconn);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    dataRead += myReader["Name"].ToString();
                    dataRead += "\nRead\n";
                }
            }
            catch (Exception e)
            {
                dataRead += "ErrorInsert";
            }
            /*
            SqlCommand command = new SqlCommand("SELECT * FROM MySQL.dbo.MyTab WHERE Name = @0", mySQLconn);
            // Add the parameters.
            command.Parameters.Add(new SqlParameter("0", 1));

            using (SqlDataReader reader = command.ExecuteReader())
            {
                dataRead += "FirstColumn\tSecond Column\t";
                while (reader.Read())
                {
                    dataRead += String.Format("{0} \t | {1} \t |",
                        reader[0], reader[1]);
                }
                dataRead += "\n Done";
            }
            */


            return dataRead;
        }


    }




}
