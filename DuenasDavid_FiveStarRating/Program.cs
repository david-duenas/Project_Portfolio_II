using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data;
namespace ConvertedJSON
{
    class Program
    {
       public static void DisplayMenu()
        {
            

            Console.WriteLine("1 | Convert The Restaurant Profile Table From SQL to JSON");
            Console.WriteLine("2 | Showcase Our 5 Star Rating System");
            Console.WriteLine("3 | Showcase Our Animated Bar Graph Review System");
            Console.WriteLine("4 | Play A Card Game");
            Console.WriteLine("5 | Exit");

            

            
        }

        public static void DisplayStarMenu()
        {
            Console.WriteLine("1 | List Restaurants Alphabetically");
            Console.WriteLine("2 | List Restaurants in Reverse Alphabetical");
            Console.WriteLine("3 | Sort Restaurants From Best to Worst");
            Console.WriteLine("4 | Sort Restaurants From Worst to Best");
            Console.WriteLine("5 | Show Only X and Up");
        }

        public static void DisplayStarSubMenu()
        {
            Console.WriteLine("1 | Show the Best (5 Stars)");
            Console.WriteLine("2 | Show 4 Stars and Up");
            Console.WriteLine("3 | Show 3 Stars and Up");
            Console.WriteLine("4 | Show the Worst (1 Star)");
            Console.WriteLine("5 | Show Unrated");
            Console.WriteLine("6 | Back");
        }

    

        //strings to hold sql fields
        public static string Id;
        public static string RestaurantName;
        public static string Address;
        public static string Phone;
        public static string HoursOfOperation;
        public static string Price;
        public static string USACityLocation;
        public static string Cuisine;
        public static string FoodRating;
        public static string ServiceRating;
        public static string AmbienceRating;
        public static string ValueRating;
        public static string OverallRating;
        public static string OverallPossibleRating;

        public MySqlConnection conn = null;
        public string stm;
        public MySqlDataReader rdr;
        public MySqlCommand cmd;

        static void Main(string[] args)
        {
          //Connection String
            string cs = @"server=172.16.71.1;userid=dbremoteuser;password=password;database=SampleRestaurantDatabase;port=8889";

          


            //output location...
            string _directory = @"../../output/";

            //create the actual directory
            Directory.CreateDirectory(_directory);
            while (true)
            {
                DisplayMenu();
                string selection = Console.ReadLine();
                selection = selection.ToLower();

                switch (selection)
                {
                    case "1":
                    case "convert the restaurant profile table from sql to json":
                        {
                            try
                            {
                                //declare new sql connection

                                MySqlConnection conn = new MySqlConnection(cs);
                                conn.Open();
                                MySqlDataReader rdr;
                                MySqlCommand cmd;


                                string stm = "SELECT id, RestaurantName, Address, Phone, HoursOfOperation, Price, USACityLocation, Cuisine, FoodRating, ServiceRating, AmbienceRating, ValueRating, OverallRating, OverallPossibleRating from RestaurantProfiles";
                                cmd = new MySqlCommand(stm, conn);
                                rdr = cmd.ExecuteReader();





                                while (rdr.Read())
                                {
                                    List<Program> data = new List<Program>();


                                    //sql strings to fields from database
                                    Id = rdr["id"].ToString();
                                    RestaurantName = rdr["RestaurantName"].ToString();
                                    Address = rdr["Address"].ToString();
                                    Phone = rdr["Phone"].ToString();
                                    HoursOfOperation = rdr["HoursOfOperation"].ToString();
                                    Price = rdr["Price"].ToString();
                                    USACityLocation = rdr["USACityLocation"].ToString();
                                    Cuisine = rdr["Cuisine"].ToString();
                                    FoodRating = rdr["FoodRating"].ToString();
                                    ServiceRating = rdr["ServiceRating"].ToString();
                                    AmbienceRating = rdr["AmbienceRating"].ToString();
                                    ValueRating = rdr["ValueRating"].ToString();
                                    OverallRating = rdr["OverallRating"].ToString();
                                    OverallPossibleRating = rdr["OverallPossibleRating"].ToString();


                                    int i = 0;

                                    do
                                    {
                                        string[] lines = { "{\r\n" + "\"" + "RestaurantProfiles" + "\"" + ":" + "[" + "\"" + Id + "\"," + "\t\n" + "\"" + RestaurantName + "\"," + "\r\n" + "\"" + Address + "\"," + "\r\n" + "\"" + Phone + "\"," + "\r\n" + "\"" + HoursOfOperation + "\"," + "\r\n" + "\"" + Price + "\"," + "\r\n" + "\"" + USACityLocation + "\"," + "\r\n" + "\"" + Cuisine + "\"," + "\r\n" + "\"" + FoodRating + "\"," + "\r\n" + "\"" + ServiceRating + "\"," + "\r\n" + "\"" + AmbienceRating + "\"," + "\r\n" + "\"" + ValueRating + "\"," + "\r\n" + "\"" + OverallRating + "\"," + "\r\n" + "\"" + OverallPossibleRating + "\"" + "\r\n]" + "\r\n}}" };
                                        i++;
                                        File.AppendAllLines(@"../../output/DavidDuenas_ConvertedData.json", lines);





                                    } while (i < 1);

                                }

                                Console.WriteLine("Completed!");
                                string convertedFile = "DavidDuenas_ConvertedData.JSON";
                                string fullPath;
                                fullPath = Path.GetFullPath(convertedFile);
                                Console.WriteLine("The file is located in " + fullPath);
                                conn.Close();
                            }

                         
                            catch (Exception ex)
                            {

                                Console.WriteLine("Exception Occured: " + ex.ToString());
                            }

                           
                            
                            
                        }break;

                    //week2
                    case "2":
                    case "showcase our 5 star rating system":
                        {
                            Console.Clear();
                            MySqlConnection conn = new MySqlConnection(cs);
                            conn.Open();
                            MySqlDataReader rdr1;
                            MySqlCommand cmd;
                            string stm1;
                            
                          
                            

                            DisplayStarMenu();
                            string menuInput = Console.ReadLine();
                            menuInput = menuInput.ToLower();

                        switch (menuInput)
                        {
                                case "1":
                                case "list restaurants alphabetically":
                                    {
                                        Console.Clear();
                                        try
                                        {
                                            conn = new MySqlConnection(cs);
                                            conn.Open();

                                            stm1 = "SELECT RestaurantName, OverallRating from RestaurantProfiles;";

                                            cmd = new MySqlCommand(stm1, conn);
                                            rdr1 = cmd.ExecuteReader();



                                            while (rdr1.Read())
                                            {
                                                string names = rdr1["RestaurantName"].ToString() as string;
                                                string ratings = rdr1["OverallRating"].ToString() as string;
                                                double ratingsDub;
                                                string stars;


                                                Double.TryParse(ratings, out ratingsDub);
                                                Math.Round(ratingsDub, 0, MidpointRounding.AwayFromZero);

                                                Console.WriteLine("Name: " + names + "\n" + "Rating: " + ratings);

                                                if (ratingsDub == 0)
                                                {
                                                    stars = "No Rating";

                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                                    Console.WriteLine(stars + "\n");
                                                    Console.ResetColor();
                                                }
                                                else if (ratingsDub >= 0.5 && ratingsDub <= 1.4)
                                                {
                                                    stars = " * ";

                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                                    Console.WriteLine(stars + "\n");
                                                    Console.ResetColor();


                                                }
                                                else if (ratingsDub >= 1.5 && ratingsDub <= 2.4)
                                                {
                                                    stars = " * * ";

                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.BackgroundColor = ConsoleColor.DarkGray;

                                                    Console.WriteLine(stars + "\n");
                                                    Console.ResetColor();

                                                }
                                                else if (ratingsDub >= 2.5 && ratingsDub <= 3.4)
                                                {
                                                    stars = " * * * ";

                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                                    Console.WriteLine(stars + "\n");
                                                    Console.ResetColor();

                                                }
                                                else if (ratingsDub >= 3.5 && ratingsDub <= 4.4)
                                                {
                                                    stars = "* * * * ";

                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                                    Console.WriteLine(stars + "\n");
                                                    Console.ResetColor();


                                                }
                                                else if (ratingsDub >= 4.5)
                                                {
                                                    stars = "* * * * * ";

                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                                    Console.WriteLine(stars + "\n");
                                                    Console.ResetColor();

                                                }

                                               




                                            }
                                           

                                        }

                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("Exception Occured:" + ex.ToString());
                                        }
                                       
                                    }
                                    break;
                                case "2":
                                case "list restaurants in reverse alphabetically":
                                    {
                                        Console.Clear();
                                        MySqlConnection conn2 = new MySqlConnection(cs);

                                        MySqlDataReader rdr2;
                                        MySqlCommand cmd1;
                                        string reverseQuery = "SELECT RestaurantName, OverallRating from RestaurantProfiles ORDER BY RestaurantName DESC;";

                                        try
                                        {
                                            conn2 = new MySqlConnection(cs);
                                            conn2.Open();



                                            cmd1 = new MySqlCommand(reverseQuery, conn2);
                                            rdr2 = cmd1.ExecuteReader();


                                            while (rdr2.Read())
                                            {

                                                string names = rdr2["RestaurantName"].ToString() as string;
                                                string ratings = rdr2["OverallRating"].ToString() as string;
                                                double ratingsDub;
                                                string stars;

                                                Double.TryParse(ratings, out ratingsDub);
                                                Math.Round(ratingsDub, 0, MidpointRounding.AwayFromZero);

                                                Console.WriteLine("Name: " + names + "\n" + "Rating: " + ratings);

                                                if (ratingsDub == 0)
                                                {
                                                    stars = "No Rating";

                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                                    Console.WriteLine(stars + "\n");
                                                    Console.ResetColor();
                                                }
                                                else if (ratingsDub >= 0.5 && ratingsDub <= 1.4)
                                                {
                                                    stars = " * ";

                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                                    Console.WriteLine(stars + "\n");
                                                    Console.ResetColor();


                                                }
                                                else if (ratingsDub >= 1.5 && ratingsDub <= 2.4)
                                                {
                                                    stars = " * * ";

                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.BackgroundColor = ConsoleColor.DarkGray;

                                                    Console.WriteLine(stars + "\n");
                                                    Console.ResetColor();

                                                }
                                                else if (ratingsDub >= 2.5 && ratingsDub <= 3.4)
                                                {
                                                    stars = " * * * ";

                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                                    Console.WriteLine(stars + "\n");
                                                    Console.ResetColor();

                                                }
                                                else if (ratingsDub >= 3.5 && ratingsDub <= 4.4)
                                                {
                                                    stars = "* * * * ";

                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                                    Console.WriteLine(stars + "\n");
                                                    Console.ResetColor();


                                                }
                                                else if (ratingsDub >= 4.5)
                                                {
                                                    stars = "* * * * * ";

                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                                    Console.WriteLine(stars + "\n");
                                                    Console.ResetColor();

                                                }


                                            }
                                        }

                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("Exception Occured:" + ex.ToString());
                                        }


                                    }

                                    break;
                                case "3":
                                case "sort restaurants from best to worst":
                                    {
                                        Console.Clear();
                                        MySqlConnection conn2 = new MySqlConnection(cs);

                                        MySqlDataReader rdr2;
                                        MySqlCommand cmd1;
                                        string bestQuery = "SELECT RestaurantName, OverallRating from RestaurantProfiles ORDER BY OverallRating DESC;";

                                        try
                                        {
                                            conn2 = new MySqlConnection(cs);
                                            conn2.Open();



                                            cmd1 = new MySqlCommand(bestQuery, conn2);
                                            rdr2 = cmd1.ExecuteReader();


                                            while (rdr2.Read())
                                            {

                                                string names = rdr2["RestaurantName"].ToString() as string;
                                                string ratings = rdr2["OverallRating"].ToString() as string;
                                                double ratingsDub;
                                                string stars;

                                                Double.TryParse(ratings, out ratingsDub);
                                                Math.Round(ratingsDub, 0, MidpointRounding.AwayFromZero);

                                                Console.WriteLine("Name: " + names + "\n" + "Rating: " + ratings);

                                                if (ratingsDub == 0)
                                                {
                                                    stars = "No Rating";

                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                                    Console.WriteLine(stars + "\n");
                                                    Console.ResetColor();
                                                }
                                                else if (ratingsDub >= 0.5 && ratingsDub <= 1.4)
                                                {
                                                    stars = " * ";

                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                                    Console.WriteLine(stars + "\n");
                                                    Console.ResetColor();


                                                }
                                                else if (ratingsDub >= 1.5 && ratingsDub <= 2.4)
                                                {
                                                    stars = " * * ";

                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.BackgroundColor = ConsoleColor.DarkGray;

                                                    Console.WriteLine(stars + "\n");
                                                    Console.ResetColor();

                                                }
                                                else if (ratingsDub >= 2.5 && ratingsDub <= 3.4)
                                                {
                                                    stars = " * * * ";

                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                                    Console.WriteLine(stars + "\n");
                                                    Console.ResetColor();

                                                }
                                                else if (ratingsDub >= 3.5 && ratingsDub <= 4.4)
                                                {
                                                    stars = "* * * * ";

                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                                    Console.WriteLine(stars + "\n");
                                                    Console.ResetColor();


                                                }
                                                else if (ratingsDub >= 4.5)
                                                {
                                                    stars = "* * * * * ";

                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                                    Console.WriteLine(stars + "\n");
                                                    Console.ResetColor();

                                                }


                                            }
                                        }

                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("Exception Occured:" + ex.ToString());
                                        }
                                    }
                                    break;
                                case "4":
                                case "sort restaurants from worst to best":
                                    {
                                        Console.Clear();
                                        MySqlConnection conn2 = new MySqlConnection(cs);

                                        MySqlDataReader rdr2;
                                        MySqlCommand cmd1;
                                        string worstQuery = "SELECT RestaurantName, OverallRating from RestaurantProfiles ORDER BY OverallRating ASC;";

                                        try
                                        {
                                            conn2 = new MySqlConnection(cs);
                                            conn2.Open();



                                            cmd1 = new MySqlCommand(worstQuery, conn2);
                                            rdr2 = cmd1.ExecuteReader();


                                            while (rdr2.Read())
                                            {

                                                string names = rdr2["RestaurantName"].ToString() as string;
                                                string ratings = rdr2["OverallRating"].ToString() as string;
                                                double ratingsDub;
                                                string stars;

                                                Double.TryParse(ratings, out ratingsDub);
                                                Math.Round(ratingsDub, 0, MidpointRounding.AwayFromZero);

                                                Console.WriteLine("Name: " + names + "\n" + "Rating: " + ratings);

                                                if (ratingsDub == 0)
                                                {
                                                    stars = "No Rating";

                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                                    Console.WriteLine(stars + "\n");
                                                    Console.ResetColor();
                                                }
                                                else if (ratingsDub >= 0.5 && ratingsDub <= 1.4)
                                                {
                                                    stars = " * ";

                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                                    Console.WriteLine(stars + "\n");
                                                    Console.ResetColor();


                                                }
                                                else if (ratingsDub >= 1.5 && ratingsDub <= 2.4)
                                                {
                                                    stars = " * * ";

                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.BackgroundColor = ConsoleColor.DarkGray;

                                                    Console.WriteLine(stars + "\n");
                                                    Console.ResetColor();

                                                }
                                                else if (ratingsDub >= 2.5 && ratingsDub <= 3.4)
                                                {
                                                    stars = " * * * ";

                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                                    Console.WriteLine(stars + "\n");
                                                    Console.ResetColor();

                                                }
                                                else if (ratingsDub >= 3.5 && ratingsDub <= 4.4)
                                                {
                                                    stars = "* * * * ";

                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                                    Console.WriteLine(stars + "\n");
                                                    Console.ResetColor();


                                                }
                                                else if (ratingsDub >= 4.5)
                                                {
                                                    stars = "* * * * * ";

                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                                    Console.WriteLine(stars + "\n");
                                                    Console.ResetColor();

                                                }


                                            }
                                        }

                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("Exception Occured:" + ex.ToString());
                                        }

                                    }
                                    break;
                                case "5":
                                case "show only x and up":
                                    {
                                        Console.Clear();
                                        DisplayStarSubMenu();
                                        string subMenuInput = Console.ReadLine();
                                        subMenuInput = subMenuInput.ToLower();

                                        switch (subMenuInput)
                                        {
                                            case "1":
                                            case "show the best":
                                                {
                                                    Console.Clear();
                                                    MySqlConnection conn2 = new MySqlConnection(cs);

                                                    MySqlDataReader rdr2;
                                                    MySqlCommand cmd1;
                                                    string betweenQuery = "SELECT RestaurantName, OverallRating from RestaurantProfiles WHERE OverallRating BETWEEN 5 AND 5 ORDER BY OverallRating DESC;";

                                                    try
                                                    {
                                                        conn2 = new MySqlConnection(cs);
                                                        conn2.Open();



                                                        cmd1 = new MySqlCommand(betweenQuery, conn2);
                                                        rdr2 = cmd1.ExecuteReader();


                                                        while (rdr2.Read())
                                                        {

                                                            string names = rdr2["RestaurantName"].ToString() as string;
                                                            string ratings = rdr2["OverallRating"].ToString() as string;
                                                            double ratingsDub;
                                                            string stars;

                                                            Double.TryParse(ratings, out ratingsDub);
                                                            Math.Round(ratingsDub, 0, MidpointRounding.AwayFromZero);

                                                            Console.WriteLine("Name: " + names + "\n" + "Rating: " + ratings);

                                                            if (ratingsDub == 0)
                                                            {
                                                                stars = "No Rating";

                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(stars + "\n");
                                                                Console.ResetColor();
                                                            }
                                                            else if (ratingsDub >= 0.5 && ratingsDub <= 1.4)
                                                            {
                                                                stars = " * ";

                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(stars + "\n");
                                                                Console.ResetColor();


                                                            }
                                                            else if (ratingsDub >= 1.5 && ratingsDub <= 2.4)
                                                            {
                                                                stars = " * * ";

                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.BackgroundColor = ConsoleColor.DarkGray;

                                                                Console.WriteLine(stars + "\n");
                                                                Console.ResetColor();

                                                            }
                                                            else if (ratingsDub >= 2.5 && ratingsDub <= 3.4)
                                                            {
                                                                stars = " * * * ";

                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(stars + "\n");
                                                                Console.ResetColor();

                                                            }
                                                            else if (ratingsDub >= 3.5 && ratingsDub <= 4.4)
                                                            {
                                                                stars = "* * * * ";

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(stars + "\n");
                                                                Console.ResetColor();


                                                            }
                                                            else if (ratingsDub >= 4.5)
                                                            {
                                                                stars = "* * * * * ";

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(stars + "\n");
                                                                Console.ResetColor();

                                                            }


                                                        }
                                                    }

                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine("Exception Occured:" + ex.ToString());
                                                    }
                                                }
                                                break;
                                            case "2":
                                            case "show 4 stars and up":
                                                {
                                                    Console.Clear();
                                                    MySqlConnection conn2 = new MySqlConnection(cs);

                                                    MySqlDataReader rdr2;
                                                    MySqlCommand cmd1;
                                                    string betweenQuery = "SELECT RestaurantName, OverallRating from RestaurantProfiles WHERE OverallRating BETWEEN 3.5 AND 5 ORDER BY OverallRating ASC;";

                                                    try
                                                    {
                                                        conn2 = new MySqlConnection(cs);
                                                        conn2.Open();



                                                        cmd1 = new MySqlCommand(betweenQuery, conn2);
                                                        rdr2 = cmd1.ExecuteReader();


                                                        while (rdr2.Read())
                                                        {

                                                            string names = rdr2["RestaurantName"].ToString() as string;
                                                            string ratings = rdr2["OverallRating"].ToString() as string;
                                                            double ratingsDub;
                                                            string stars;

                                                            Double.TryParse(ratings, out ratingsDub);
                                                            Math.Round(ratingsDub, 0, MidpointRounding.AwayFromZero);

                                                            Console.WriteLine("Name: " + names + "\n" + "Rating: " + ratings);

                                                            if (ratingsDub == 0)
                                                            {
                                                                stars = "No Rating";

                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(stars + "\n");
                                                                Console.ResetColor();
                                                            }
                                                            else if (ratingsDub >= 0.5 && ratingsDub <= 1.4)
                                                            {
                                                                stars = " * ";

                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(stars + "\n");
                                                                Console.ResetColor();


                                                            }
                                                            else if (ratingsDub >= 1.5 && ratingsDub <= 2.4)
                                                            {
                                                                stars = " * * ";

                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.BackgroundColor = ConsoleColor.DarkGray;

                                                                Console.WriteLine(stars + "\n");
                                                                Console.ResetColor();

                                                            }
                                                            else if (ratingsDub >= 2.5 && ratingsDub <= 3.4)
                                                            {
                                                                stars = " * * * ";

                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(stars + "\n");
                                                                Console.ResetColor();

                                                            }
                                                            else if (ratingsDub >= 3.5 && ratingsDub <= 4.4)
                                                            {
                                                                stars = "* * * * ";

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(stars + "\n");
                                                                Console.ResetColor();


                                                            }
                                                            else if (ratingsDub >= 4.5)
                                                            {
                                                                stars = "* * * * * ";

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(stars + "\n");
                                                                Console.ResetColor();

                                                            }


                                                        }
                                                    }

                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine("Exception Occured:" + ex.ToString());
                                                    }
                                                }
                                                break;
                                            case "3":
                                            case "show 3 stars and up":
                                                {
                                                    Console.Clear();
                                                    MySqlConnection conn2 = new MySqlConnection(cs);

                                                    MySqlDataReader rdr2;
                                                    MySqlCommand cmd1;
                                                    string betweenQuery = "SELECT RestaurantName, OverallRating from RestaurantProfiles WHERE OverallRating BETWEEN 2.5 AND 5 ORDER BY OverallRating ASC;";

                                                    try
                                                    {
                                                        conn2 = new MySqlConnection(cs);
                                                        conn2.Open();



                                                        cmd1 = new MySqlCommand(betweenQuery, conn2);
                                                        rdr2 = cmd1.ExecuteReader();


                                                        while (rdr2.Read())
                                                        {

                                                            string names = rdr2["RestaurantName"].ToString() as string;
                                                            string ratings = rdr2["OverallRating"].ToString() as string;
                                                            double ratingsDub;
                                                            string stars;

                                                            Double.TryParse(ratings, out ratingsDub);
                                                            Math.Round(ratingsDub, 0, MidpointRounding.AwayFromZero);

                                                            Console.WriteLine("Name: " + names + "\n" + "Rating: " + ratings);

                                                            if (ratingsDub == 0)
                                                            {
                                                                stars = "No Rating";

                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(stars + "\n");
                                                                Console.ResetColor();
                                                            }
                                                            else if (ratingsDub >= 0.5 && ratingsDub <= 1.4)
                                                            {
                                                                stars = " * ";

                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(stars + "\n");
                                                                Console.ResetColor();


                                                            }
                                                            else if (ratingsDub >= 1.5 && ratingsDub <= 2.4)
                                                            {
                                                                stars = " * * ";

                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.BackgroundColor = ConsoleColor.DarkGray;

                                                                Console.WriteLine(stars + "\n");
                                                                Console.ResetColor();

                                                            }
                                                            else if (ratingsDub >= 2.5 && ratingsDub <= 3.4)
                                                            {
                                                                stars = " * * * ";

                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(stars + "\n");
                                                                Console.ResetColor();

                                                            }
                                                            else if (ratingsDub >= 3.5 && ratingsDub <= 4.4)
                                                            {
                                                                stars = "* * * * ";

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(stars + "\n");
                                                                Console.ResetColor();


                                                            }
                                                            else if (ratingsDub >= 4.5)
                                                            {
                                                                stars = "* * * * * ";

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(stars + "\n");
                                                                Console.ResetColor();

                                                            }


                                                        }
                                                    }

                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine("Exception Occured:" + ex.ToString());
                                                    }
                                                }
                                                break;
                                            case "4":
                                            case "show the worst":
                                                {
                                                    Console.Clear();
                                                    MySqlConnection conn2 = new MySqlConnection(cs);

                                                    MySqlDataReader rdr2;
                                                    MySqlCommand cmd1;
                                                    string betweenQuery = "SELECT RestaurantName, OverallRating from RestaurantProfiles WHERE OverallRating BETWEEN 0.5 AND 1.4 ORDER BY OverallRating ASC;";

                                                    try
                                                    {
                                                        conn2 = new MySqlConnection(cs);
                                                        conn2.Open();



                                                        cmd1 = new MySqlCommand(betweenQuery, conn2);
                                                        rdr2 = cmd1.ExecuteReader();


                                                        while (rdr2.Read())
                                                        {

                                                            string names = rdr2["RestaurantName"].ToString() as string;
                                                            string ratings = rdr2["OverallRating"].ToString() as string;
                                                            double ratingsDub;
                                                            string stars;

                                                            Double.TryParse(ratings, out ratingsDub);
                                                            Math.Round(ratingsDub, 0, MidpointRounding.AwayFromZero);

                                                            Console.WriteLine("Name: " + names + "\n" + "Rating: " + ratings);

                                                            if (ratingsDub == 0)
                                                            {
                                                                stars = "No Rating";

                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(stars + "\n");
                                                                Console.ResetColor();
                                                            }
                                                            else if (ratingsDub >= 0.5 && ratingsDub <= 1.4)
                                                            {
                                                                stars = " * ";

                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(stars + "\n");
                                                                Console.ResetColor();


                                                            }
                                                            else if (ratingsDub >= 1.5 && ratingsDub <= 2.4)
                                                            {
                                                                stars = " * * ";

                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.BackgroundColor = ConsoleColor.DarkGray;

                                                                Console.WriteLine(stars + "\n");
                                                                Console.ResetColor();

                                                            }
                                                            else if (ratingsDub >= 2.5 && ratingsDub <= 3.4)
                                                            {
                                                                stars = " * * * ";

                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(stars + "\n");
                                                                Console.ResetColor();

                                                            }
                                                            else if (ratingsDub >= 3.5 && ratingsDub <= 4.4)
                                                            {
                                                                stars = "* * * * ";

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(stars + "\n");
                                                                Console.ResetColor();


                                                            }
                                                            else if (ratingsDub >= 4.5)
                                                            {
                                                                stars = "* * * * * ";

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(stars + "\n");
                                                                Console.ResetColor();

                                                            }


                                                        }
                                                    }

                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine("Exception Occured:" + ex.ToString());
                                                    }
                                                }
                                                break;
                                            case "5":
                                            case "show unrated":
                                                {
                                                    Console.Clear();
                                                    MySqlConnection conn2 = new MySqlConnection(cs);

                                                    MySqlDataReader rdr2;
                                                    MySqlCommand cmd1;
                                                    string betweenQuery = "SELECT RestaurantName, OverallRating from RestaurantProfiles WHERE OverallRating IS NULL or OverallRating = 0 ORDER BY OverallRating ASC;";

                                                    try
                                                    {
                                                        conn2 = new MySqlConnection(cs);
                                                        conn2.Open();



                                                        cmd1 = new MySqlCommand(betweenQuery, conn2);
                                                        rdr2 = cmd1.ExecuteReader();


                                                        while (rdr2.Read())
                                                        {

                                                            string names = rdr2["RestaurantName"].ToString() as string;
                                                            string ratings = rdr2["OverallRating"].ToString() as string;
                                                            double ratingsDub;
                                                            string stars;

                                                            Double.TryParse(ratings, out ratingsDub);
                                                            Math.Round(ratingsDub, 0, MidpointRounding.AwayFromZero);

                                                            Console.WriteLine("Name: " + names + "\n" + "Rating: " + ratings);

                                                            if (ratingsDub == 0)
                                                            {
                                                                stars = "No Rating";

                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(stars + "\n");
                                                                Console.ResetColor();
                                                            }
                                                            else if (ratingsDub >= 0.5 && ratingsDub <= 1.4)
                                                            {
                                                                stars = " * ";

                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(stars + "\n");
                                                                Console.ResetColor();


                                                            }
                                                            else if (ratingsDub >= 1.5 && ratingsDub <= 2.4)
                                                            {
                                                                stars = " * * ";

                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.BackgroundColor = ConsoleColor.DarkGray;

                                                                Console.WriteLine(stars + "\n");
                                                                Console.ResetColor();

                                                            }
                                                            else if (ratingsDub >= 2.5 && ratingsDub <= 3.4)
                                                            {
                                                                stars = " * * * ";

                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(stars + "\n");
                                                                Console.ResetColor();

                                                            }
                                                            else if (ratingsDub >= 3.5 && ratingsDub <= 4.4)
                                                            {
                                                                stars = "* * * * ";

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(stars + "\n");
                                                                Console.ResetColor();


                                                            }
                                                            else if (ratingsDub >= 4.5)
                                                            {
                                                                stars = "* * * * * ";

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(stars + "\n");
                                                                Console.ResetColor();

                                                            }


                                                        }
                                                    }

                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine("Exception Occured:" + ex.ToString());
                                                    }
                                                }
                                                break;
                                            case "6":
                                            case "back":
                                                {
                                                    Console.Clear();
                                                    DisplayStarMenu();
                                                }
                                                break;

                                        }
                                        break;
                                    }


                            }
                        }
                        break;


                    case "3":
                    case "showcase our animated bar graph review system":
                        {

                        }
                        break;
                    case "4":
                    case "play a card game":
                        {

                        }
                        break;
                    case "5":
                    case "exit":
                        {

                        }
                        break;
                }


            }




        }
    }
}
