using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace timetracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Timetracker";
            string title = @"
___________.__                 ___________                     __                 
\__    ___/|__| _____   ____   \__    ___/___________    ____ |  | __ ___________ 
  |    |   |  |/     \_/ __ \    |    |  \_  __ \__  \ _/ ___\|  |/ // __ \_  __ \
  |    |   |  |  Y Y  \  ___/    |    |   |  | \// __ \\  \___|    <\  ___/|  | \/
  |____|   |__|__|_|  /\___  >   |____|   |__|  (____  /\___  >__|_ \\___  >__|   
                    \/     \/                        \/     \/     \/    \/                ";

            Console.WriteLine(title);
            Console.WriteLine("\n\n");

            //Connection string
            string cs = @"server=172.16.71.1;userid=davidduenas;password=pwd123;database=David_Duenas_MDV229_Database_Month(ex:201905);port=8889";
            //Declare new connection
            MySqlConnection conn = null;

            //Ask for username
            Console.WriteLine("Enter First Name:\n");
            string userFirstNameInput = Console.ReadLine();

            Console.WriteLine("Enter Last Name:\n");
            string userLastNameInput = Console.ReadLine();

            //Ask for password
            Console.WriteLine("Enter Password:");
            string userPassword = Console.ReadLine();

            try
            {
                //Open a connection
                conn = new MySqlConnection(cs);
                conn.Open();

                //Declare data reader
                MySqlDataReader rdr = null;

                //SQL Statement 
                string stm = "SELECT user_firstname, user_lastname, user_password from time_tracker_users where user_firstname = @userfirstname and user_lastname = @userlastname  and user_password = @password; ";

                MySqlCommand cmd = new MySqlCommand(stm, conn);

                //Bind
                cmd.Parameters.AddWithValue("@userfirstname", userFirstNameInput);
                cmd.Parameters.AddWithValue("@userlastname", userLastNameInput);
                cmd.Parameters.AddWithValue("@password", userPassword);

                rdr = cmd.ExecuteReader();


                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        string username = rdr["user_firstname"] as string;
                        string password = rdr["user_password"] as string;

                        string input = "";
                        bool running = true;

                        Console.Clear();
                        Console.WriteLine(title);

                        Console.WriteLine("***Main Menu***\n\n");
                        Console.WriteLine("Welcome " + rdr["user_firstname"] as string + "\n\n");
                        Console.WriteLine("1. Enter Activity");
                        Console.WriteLine("2. View Tracked Data");
                        Console.WriteLine("3. Run Calculations\n\n");
                        Console.WriteLine("4. Exit");

                        Console.Write("Enter a selection: (1 - 4): ");

                        input = Console.ReadLine().ToLower();
                        Console.WriteLine();
                        //handle choices
                        switch (input)
                        {
                            case "1":
                            case "enter activity":
                                {
                                   
                                    Console.WriteLine(title);
                                    Console.WriteLine("\n\n");
                                    using (MySqlConnection conn2 = new MySqlConnection(cs))
                                    {
                                        conn2.Open();
                                        using (MySqlCommand command = new MySqlCommand("SELECT activity_category_id, category_description from activity_categories;", conn2))
                                        {
                                            using (MySqlDataReader rdr2 = command.ExecuteReader())
                                            {
                                                while (rdr2.Read())
                                                {
                                                    string activity_category_id = rdr2[0].ToString() as string;
                                                    string category_description = rdr2[1].ToString() as string;

                                                    Console.WriteLine("[" + activity_category_id + "]" + " " + category_description);
                                                }
                                            }
                                        }
                                        conn2.Close();
                                    }
                                   
                                                    Console.WriteLine("Enter [0-13]");
                                                    string userInput = Console.ReadLine();
                                                    Console.Clear();
                                                    if (userInput == "0")
                                                    {
                                        using (MySqlConnection conn2 = new MySqlConnection(cs))
                                        {
                                            conn2.Open();
                                            using (MySqlCommand activity_command = new MySqlCommand("SELECT activity_description_id, activity_description from activity_descriptions;", conn2))
                                            {
                                                using (MySqlDataReader rdr2 = activity_command.ExecuteReader())
                                                {
                                                    while (rdr2.Read())
                                                    {
                                                        string activity_description_id = rdr2[0].ToString() as string;
                                                        string activity_description = rdr2[1].ToString() as string;

                                                        Console.WriteLine("[" + activity_description_id + "]" + activity_description);
                                                        Console.WriteLine("\nPick a description for tracked activity");
                                                        string descriptionInput = Console.ReadLine();



                                                    }
                                                    
                                                }
                                                }
                                            }

                                      
                                    }
                                                    
 }
                                break;
                            case "2":
                            case "view tracked data":
                                {

                                }
                                break;
                            case "3":
                            case "run calculations":
                                {

                                }
                                break;
                            case "4":
                            case "exit":
                                {
                                    running = false;
                                }
                                break;
                            default:
                                return;


                        }
                    }
                }
                else
                {
                    Console.WriteLine("User not found...");
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







