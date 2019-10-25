
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace timetracker
{


    class Login
    {
        public static string cs = @"server=172.16.71.1;userid=davidduenas;password=pwd123;database=David_Duenas_MDV229_Database_Month(ex:201910);port=8889";
        //Declare new connection

        public static string user_firstname;
        public static string user_lastname;
        public static string user_password;
        public static string user_id;

        public static void TryLogin()
        {
            MySqlConnection conn = null;

            Console.WriteLine("Enter Username: ");
            user_firstname = Console.ReadLine();

            Console.WriteLine("Enter Password: ");
            user_password = Console.ReadLine();

            try
            {

                conn = new MySqlConnection(cs);
                conn.Open();
                MySqlDataReader rdr = null;
                string loginStatement = "SELECT user_firstname, user_lastname, user_password, user_id from time_tracker_users where user_firstname = @user_firstname AND user_password = @user_password;";
                MySqlCommand cmd = new MySqlCommand(loginStatement, conn);

                cmd.Parameters.AddWithValue("@user_firstname", user_firstname);
                cmd.Parameters.AddWithValue("@user_password", user_password);
                rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        user_firstname = rdr[0].ToString() as string;
                        user_lastname = rdr[1].ToString() as string;
                        user_password = rdr[2].ToString() as string;
                        user_id = rdr[3].ToString() as string;

                        if (user_firstname == rdr[0].ToString() as string && user_password == rdr[2].ToString() as string)
                        {
                            Console.WriteLine("Thank you for logging in " + user_firstname + ", press any key to continue.... ");
                            Console.ReadKey();
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(Header.ShowHeader());
                    Console.WriteLine("User not found...Please try again. \n\n");
                    Console.WriteLine("Enter Username: ");
                    user_firstname = Console.ReadLine();

                    Console.WriteLine("Enter Password: ");
                    user_password = Console.ReadLine();
                }



                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        user_firstname = rdr[0].ToString() as string;
                        user_lastname = rdr[1].ToString() as string;
                        user_password = rdr[2].ToString() as string;
                        user_id = rdr[3].ToString() as string;

                        if (user_firstname == rdr[1].ToString() as string && user_password == rdr[2].ToString() as string)
                        {
                            Console.WriteLine("Thank you for logging in " + user_firstname + ", press any key to continue.... ");
                            Console.ReadKey();
                        }


                        else
                        {
                            Console.Clear();
                            Console.WriteLine(Header.ShowHeader());
                            Console.WriteLine("User not found...Please try again. \n\n");
                            Console.WriteLine("Enter Username: ");
                            user_firstname = Console.ReadLine();

                            Console.WriteLine("Enter Password: ");
                            user_password = Console.ReadLine();
                        }

                    }
                }
            }



            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }


        }

    }

}
