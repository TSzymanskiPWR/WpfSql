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
                ret = "Connected";
            }
            catch(Exception e)
            {
                // TextBoxCons.Text(e.ToString());
                ret = "Error";
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
                return "Error";
            }
            return "Disconnected";
        }

        public string mySQLcmd(string cmdtext)
        {
            SqlCommand myCmd = new SqlCommand(this.cmdtext, mySQLconn);

            return cmdtext;
        }

        public string mySQLdataRead()
        {
            string dataRead = "";
            /*try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("select * from table",
                                                         mySQLconn);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    dataRead = myReader["Column1"].ToString();

                }
            }
            catch (Exception e)
            {
                dataRead = "Error";
            }*/

            SqlCommand command = new SqlCommand("SELECT * FROM MyDataTable WHERE FirstColumn = @0", mySQLconn);
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
            }



            return dataRead;
        }


    }




}
