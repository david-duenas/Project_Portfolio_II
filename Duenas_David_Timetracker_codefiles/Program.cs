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
        public static string cs = @"server=172.16.71.1;userid=davidduenas;password=pwd123;database=David_Duenas_MDV229_Database_Month(ex:201910);port=8889";
        public static string activity_category_id;
        public static string category_description;
        public static string activityCategoryChoice;

        public static string activity_description_id;
        public static string activity_description;
        public static string activityDescriptionChoice;

        public static string calendar_date_id;
        public static string calendar_date;
        public static string calendarDateChoice;

        public static string activity_time_id;
        public static string time_spent_on_activity;
        public static string activityTimeChoice;

        public static string log_date;
        public static string log_date_id;
        public static string logdateChoice;
        public static string logCategoryChoice;
        public static string logDescriptionChoice;
        public static string log_activity_category_id;
        public static string log_category_description;
        public static string log_activity_description_id;
        public static string log_activity_description;


        public static string _logCalendarNumericalDay;
        public static string _logCalendarDate;
        public static string _logCategoryDescription;
        public static string _logActivityDescription;
        public static string _logTimeSpentOnActivity;






        static void Main(string[] args)
        {
            Console.WriteLine(Header.ShowHeader());
            Login.TryLogin();
            Console.WriteLine(Header.ShowHeader());
            mainMenu:
            Menu.ShowMenu();

            string input = Console.ReadLine();
            int inputNum;
            int.TryParse(input, out inputNum);

            switch (inputNum)
            {

                case 1:
                    {
                        Console.Clear();
                        Console.WriteLine(Header.ShowHeader());
                        activityMenu:
                        Menu.ActivityMenu();

                        input = Console.ReadLine();
                        int.TryParse(input, out inputNum);

                        switch (inputNum)
                        {

                            case 1:
                                {

                                    MySqlConnection conn = null;
                                    MySqlDataReader rdr;
                                    Console.Clear();

                                    Console.WriteLine(Header.ShowHeader());

                                    try
                                    {
                                        conn = new MySqlConnection(cs);
                                        conn.Open();

                                        string categoryStm = "select activity_category_id, category_description from activity_categories;";
                                        MySqlCommand cmd = new MySqlCommand(categoryStm, conn);
                                        rdr = cmd.ExecuteReader();

                                        while (rdr.Read())
                                        {
                                            activity_category_id = rdr["activity_category_id"].ToString() as string;
                                            category_description = rdr["category_description"].ToString() as string;

                                            Console.WriteLine("[" + activity_category_id + "]" + category_description);
                                        }
                                    }
                                    catch (MySqlException ex)
                                    {
                                        Console.WriteLine("Error {0}", ex.ToString());
                                    }

                                    Console.WriteLine("==================");
                                    Console.WriteLine("\nSelect Category:");


                                    activityCategoryChoice = Console.ReadLine();

                                }
                                break;
                            case 2:
                                {
                                    goto mainMenu;
                                }


                        }
                        Console.Clear();
                        Console.WriteLine(Header.ShowHeader());

                        try
                        {
                            MySqlConnection conn = new MySqlConnection(cs);
                            MySqlDataReader rdr;
                            string activityStm = "SELECT activity_description_id, activity_description FROM activity_descriptions";
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand(activityStm, conn);
                            rdr = cmd.ExecuteReader();

                            while (rdr.Read())
                            {
                                activity_description_id = rdr["activity_description_id"].ToString() as string;
                                activity_description = rdr["activity_description"].ToString() as string;

                                Console.WriteLine("[" + activity_description_id + "]" + activity_description);

                            }


                        }

                        catch (MySqlException ex)
                        {
                            Console.WriteLine("Error {0}", ex.ToString());
                        }

                        Console.WriteLine("==================");
                        Console.WriteLine("Pick an Activity:");

                        activityDescriptionChoice = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine(Header.ShowHeader());

                        try
                        {
                            MySqlConnection conn = new MySqlConnection(cs);
                            MySqlDataReader rdr;
                            string dateStm = "SELECT calendar_date_id, calendar_date FROM tracked_calendar_dates;";
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand(dateStm, conn);
                            rdr = cmd.ExecuteReader();

                            while (rdr.Read())
                            {
                                calendar_date_id = rdr["calendar_date_id"].ToString() as string;
                                calendar_date = rdr["calendar_date"].ToString() as string;

                                Console.WriteLine("[" + calendar_date_id + "]" + calendar_date);

                            }

                        }

                        catch (MySqlException ex)
                        {
                            Console.WriteLine("Error {0}", ex.ToString());
                        }

                        Console.WriteLine("==================");
                        Console.WriteLine("What Date Did You Perform The Activity?");
                        calendarDateChoice = Console.ReadLine();



                        Console.Clear();
                        Console.WriteLine(Header.ShowHeader());

                        try
                        {
                            MySqlConnection conn = new MySqlConnection(cs);
                            MySqlDataReader rdr;
                            string timeStm = "SELECT activity_time_id, time_spent_on_activity FROM activity_times;";
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand(timeStm, conn);
                            rdr = cmd.ExecuteReader();

                            while (rdr.Read())
                            {
                                activity_time_id = rdr["activity_time_id"].ToString() as string;
                                time_spent_on_activity = rdr["time_spent_on_activity"].ToString() as string;

                                Console.WriteLine("[" + activity_time_id + "]" + time_spent_on_activity);

                            }

                        }

                        catch (MySqlException ex)
                        {
                            Console.WriteLine("Error {0}", ex.ToString());
                        }

                        Console.WriteLine("==================");
                        Console.WriteLine("How Long Did You Perform The Activity?");
                        activityTimeChoice = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine(Header.ShowHeader());


                        using (MySqlConnection conn1 = new MySqlConnection(cs))
                        {
                            using (MySqlCommand cmd = new MySqlCommand())
                            {
                                cmd.Connection = conn1;
                                cmd.CommandType = System.Data.CommandType.Text;
                                cmd.CommandText = @"INSERT INTO activity_log (user_id, calendar_day, calendar_date, category_description, activity_description, time_spent_on_activity)VALUES(@user_id, @calendar_day, @calendar_date, @category_description, @activity_description, @time_spent_on_activity)";

                                cmd.Parameters.AddWithValue("@user_id", Login.user_id);
                                cmd.Parameters.AddWithValue("@calendar_day", calendarDateChoice);
                                cmd.Parameters.AddWithValue("@calendar_date", calendarDateChoice);
                                cmd.Parameters.AddWithValue("@category_description", activityCategoryChoice);
                                cmd.Parameters.AddWithValue("@activity_description", activityDescriptionChoice);
                                cmd.Parameters.AddWithValue("@time_spent_on_activity", activityTimeChoice);


                                try
                                {
                                    conn1.Open();
                                    cmd.ExecuteNonQuery();
                                }
                                catch (MySqlException ex)
                                {
                                    Console.WriteLine("Error: {0}", ex.ToString());
                                }
                            }

                        }
                        Console.WriteLine("Activity Entered!");
                        Console.WriteLine("1. Enter Another Activity");
                        Console.WriteLine("2. Go Back To Main Menu");
                        input = Console.ReadLine();
                        int.TryParse(input, out inputNum);

                        switch (inputNum)
                        {
                            case 1:
                                {
                                    goto activityMenu;

                                }
                            case 2:
                                {
                                    goto mainMenu;
                                }
                        }
                    }
                    break;
                case 2:
                    {
                        Console.Clear();
                        Console.WriteLine(Header.ShowHeader());
                        datalog:
                        Menu.TrackedDataLog();

                        input = Console.ReadLine();
                        int.TryParse(input, out inputNum);

                        switch (inputNum)
                        {
                            case 1:
                                {
                                    Console.Clear();
                                    Console.WriteLine(Header.ShowHeader());


                                    try
                                    {
                                        MySqlConnection conn = new MySqlConnection(cs);
                                        conn = new MySqlConnection(cs);
                                        conn.Open();
                                        MySqlDataReader rdr;

                                        string logStatementDate = "SELECT calendar_date_id, calendar_date FROM tracked_calendar_dates;";
                                        MySqlCommand logCommand = new MySqlCommand(logStatementDate, conn);
                                        rdr = logCommand.ExecuteReader();

                                        while (rdr.Read())
                                        {
                                            log_date_id = rdr["calendar_date_id"].ToString() as string;
                                            log_date = rdr["calendar_date"].ToString() as string;

                                            Console.WriteLine("[" + log_date_id + "]" + log_date);
                                        }
                                    }
                                    catch (MySqlException ex)
                                    {
                                        Console.WriteLine("Error {0}", ex.ToString());
                                    }

                                    Console.WriteLine("What Date Would You Like To View?:\n");
                                    logdateChoice = Console.ReadLine();
                                    Console.Clear();
                                    Console.WriteLine(Header.ShowHeader());


                                    using (MySqlConnection conn = new MySqlConnection(cs))
                                    {
                                        using (MySqlCommand cmd = new MySqlCommand())
                                        {
                                            cmd.Connection = conn;
                                            conn.Open();
                                            cmd.CommandType = System.Data.CommandType.Text;
                                            cmd.CommandText = @"SELECT
	                                                                    time_tracker_users.user_id,
	                                                                    tracked_calendar_days.calendar_day_id,
	                                                                    tracked_calendar_days.calendar_numerical_day,
	                                                                    tracked_calendar_dates.calendar_date,
	                                                                    activity_categories.activity_category_id,
	                                                                    activity_categories.category_description,
	                                                                    activity_descriptions.activity_description,
	                                                                    activity_times.time_spent_on_activity
                                                                    FROM
	                                                                    `David_Duenas_MDV229_Database_Month(ex:201910)`.activity_log activity_log,
	                                                                    `David_Duenas_MDV229_Database_Month(ex:201910)`.time_tracker_users 
	                                                                    time_tracker_users,
	                                                                    `David_Duenas_MDV229_Database_Month(ex:201910)`.tracked_calendar_days 
	                                                                    tracked_calendar_days,
	                                                                    `David_Duenas_MDV229_Database_Month(ex:201910)`.tracked_calendar_dates 
	                                                                    tracked_calendar_dates,
	                                                                    `David_Duenas_MDV229_Database_Month(ex:201910)`.activity_categories 
	                                                                    activity_categories,
	                                                                    `David_Duenas_MDV229_Database_Month(ex:201910)`.activity_descriptions 
	                                                                    activity_descriptions,
	                                                                    `David_Duenas_MDV229_Database_Month(ex:201910)`.activity_times activity_times
                                                                    WHERE
	                                                                    activity_log.user_id = time_tracker_users.user_id AND
	                                                                    activity_log.calendar_day = tracked_calendar_days.calendar_day_id AND
	                                                                    activity_log.calendar_date = tracked_calendar_dates.calendar_date_id AND
	                                                                    activity_log.category_description = 
	                                                                    activity_categories.activity_category_id AND
	                                                                    activity_log.activity_description = 
	                                                                    activity_descriptions.activity_description_id AND
	                                                                    activity_log.time_spent_on_activity = activity_times.activity_time_id AND
	                                                                    time_tracker_users.user_id = @log_UserId AND
	                                                                    tracked_calendar_days.calendar_day_id = @log_date
                                                                    ;";

                                            cmd.Parameters.AddWithValue("@log_date", logdateChoice);
                                            cmd.Parameters.AddWithValue("@log_UserId", Login.user_id);
                                            using (MySqlDataReader rdr = cmd.ExecuteReader())
                                            {
                                                while (rdr.Read())
                                                {
                                                    _logCalendarNumericalDay = rdr["calendar_numerical_day"].ToString() as string;
                                                    _logCalendarDate = rdr["calendar_date"].ToString() as string;
                                                    _logCategoryDescription = rdr["category_description"].ToString() as string;
                                                    _logActivityDescription = rdr["activity_description"].ToString() as string;
                                                    _logTimeSpentOnActivity = rdr["time_spent_on_activity"].ToString() as string;


                                                    Console.WriteLine("|Date:| " + _logCalendarDate + " [ " + _logCalendarNumericalDay + " ]" + " |Category:| " + _logCategoryDescription + " |Activity:| " + _logActivityDescription + " |Time:| " + _logTimeSpentOnActivity);
                                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                                    Console.WriteLine("_____________________________________________________________________________________________________________");
                                                    Console.ResetColor();
                                                }
                                            }
                                            try
                                            {

                                                cmd.ExecuteNonQuery();
                                            }
                                            catch (MySqlException ex)
                                            {
                                                Console.WriteLine("Error: {0}", ex.ToString());
                                            }


                                        }
                                        conn.Close();


                                        Menu.LogMenu();
                                        input = Console.ReadLine();
                                        int.TryParse(input, out inputNum);

                                        switch (inputNum)
                                        {
                                            case 1:
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(Header.ShowHeader());
                                                    goto datalog;

                                                }
                                            case 2:
                                                {
                                                    goto mainMenu;
                                                }

                                        }


                                    }
                                }
                                break;
                            case 2:
                                {
                                    Console.Clear();
                                    Console.WriteLine(Header.ShowHeader());


                                    try
                                    {
                                        MySqlConnection conn = new MySqlConnection(cs);
                                        conn = new MySqlConnection(cs);
                                        conn.Open();
                                        MySqlDataReader rdr;

                                        string logStatementCategory = "SELECT activity_category_id, category_description from activity_categories;";
                                        MySqlCommand logCommand = new MySqlCommand(logStatementCategory, conn);
                                        rdr = logCommand.ExecuteReader();

                                        while (rdr.Read())
                                        {
                                            log_activity_category_id = rdr["activity_category_id"].ToString() as string;
                                            log_category_description = rdr["category_description"].ToString() as string;

                                            Console.WriteLine("[" + log_activity_category_id + "]" + log_category_description);
                                        }
                                    }
                                    catch (MySqlException ex)
                                    {
                                        Console.WriteLine("Error {0}", ex.ToString());
                                    }

                                    Console.WriteLine("What Category Would You Like To View?:\n");
                                    logCategoryChoice = Console.ReadLine();
                                    Console.Clear();
                                    Console.WriteLine(Header.ShowHeader());


                                    using (MySqlConnection conn = new MySqlConnection(cs))
                                    {
                                        using (MySqlCommand cmd = new MySqlCommand())
                                        {
                                            cmd.Connection = conn;
                                            conn.Open();
                                            cmd.CommandType = System.Data.CommandType.Text;
                                            cmd.CommandText = @"SELECT
	                                                        time_tracker_users.user_id,
	                                                        tracked_calendar_days.calendar_day_id,
	                                                        tracked_calendar_days.calendar_numerical_day,
	                                                        tracked_calendar_dates.calendar_date,
	                                                        activity_categories.activity_category_id,
	                                                        activity_categories.category_description,
	                                                        activity_descriptions.activity_description,
	                                                        activity_times.time_spent_on_activity
                                                        FROM
	                                                        `David_Duenas_MDV229_Database_Month(ex:201910)`.activity_log activity_log,
	                                                        `David_Duenas_MDV229_Database_Month(ex:201910)`.time_tracker_users 
	                                                        time_tracker_users,
	                                                        `David_Duenas_MDV229_Database_Month(ex:201910)`.tracked_calendar_days 
	                                                        tracked_calendar_days,
	                                                        `David_Duenas_MDV229_Database_Month(ex:201910)`.tracked_calendar_dates 
	                                                        tracked_calendar_dates,
	                                                        `David_Duenas_MDV229_Database_Month(ex:201910)`.activity_categories 
	                                                        activity_categories,
	                                                        `David_Duenas_MDV229_Database_Month(ex:201910)`.activity_descriptions 
	                                                        activity_descriptions,
	                                                        `David_Duenas_MDV229_Database_Month(ex:201910)`.activity_times activity_times
                                                        WHERE
	                                                        activity_log.user_id = time_tracker_users.user_id AND
	                                                        activity_log.calendar_day = tracked_calendar_days.calendar_day_id AND
	                                                        activity_log.calendar_date = tracked_calendar_dates.calendar_date_id AND
	                                                        activity_log.category_description = 
	                                                        activity_categories.activity_category_id AND
	                                                        activity_log.activity_description = 
	                                                        activity_descriptions.activity_description_id AND
	                                                        activity_log.time_spent_on_activity = activity_times.activity_time_id AND
	                                                        time_tracker_users.user_id = @log_UserId AND
	                                                        activity_categories.activity_category_id = @logCategoryChoice
                                                        ;";

                                            cmd.Parameters.AddWithValue("@logCategoryChoice", logCategoryChoice);
                                            cmd.Parameters.AddWithValue("@log_UserId", Login.user_id);

                                            using (MySqlDataReader rdr = cmd.ExecuteReader())
                                            {
                                                while (rdr.Read())
                                                {
                                                    _logCalendarNumericalDay = rdr["calendar_numerical_day"].ToString() as string;
                                                    _logCalendarDate = rdr["calendar_date"].ToString() as string;
                                                    _logCategoryDescription = rdr["category_description"].ToString() as string;
                                                    _logActivityDescription = rdr["activity_description"].ToString() as string;
                                                    _logTimeSpentOnActivity = rdr["time_spent_on_activity"].ToString() as string;


                                                    Console.WriteLine("|Date:| " + _logCalendarDate + " [ " + _logCalendarNumericalDay + " ]" + " |Category:| " + _logCategoryDescription + " |Activity:| " + _logActivityDescription + " |Time:| " + _logTimeSpentOnActivity);
                                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                                    Console.WriteLine("_____________________________________________________________________________________________________________");
                                                    Console.ResetColor();
                                                }
                                            }
                                            try
                                            {

                                                cmd.ExecuteNonQuery();
                                            }
                                            catch (MySqlException ex)
                                            {
                                                Console.WriteLine("Error: {0}", ex.ToString());
                                            }


                                        }
                                        conn.Close();
                                    }

                                    Menu.LogMenu();
                                    input = Console.ReadLine();
                                    int.TryParse(input, out inputNum);

                                    switch (inputNum)
                                    {
                                        case 1:
                                            {
                                                Console.Clear();
                                                Console.WriteLine(Header.ShowHeader());
                                                goto datalog;

                                            }
                                        case 2:
                                            {
                                                goto mainMenu;
                                            }

                                    }


                                }
                                break;
                            case 3:
                                {
                                    Console.Clear();
                                    Console.WriteLine(Header.ShowHeader());


                                    try
                                    {
                                        MySqlConnection conn = new MySqlConnection(cs);
                                        conn = new MySqlConnection(cs);
                                        conn.Open();
                                        MySqlDataReader rdr;

                                        string logStatementDescription = "SELECT activity_description_id, activity_description FROM activity_descriptions;";
                                        MySqlCommand logCommand = new MySqlCommand(logStatementDescription, conn);
                                        rdr = logCommand.ExecuteReader();

                                        while (rdr.Read())
                                        {
                                            log_activity_description_id = rdr["activity_description_id"].ToString() as string;
                                            log_activity_description = rdr["activity_description"].ToString() as string;

                                            Console.WriteLine("[" + log_activity_description_id + "]" + log_activity_description);
                                        }
                                    }
                                    catch (MySqlException ex)
                                    {
                                        Console.WriteLine("Error {0}", ex.ToString());
                                    }

                                    Console.WriteLine("What Description Would You Like To View?:\n");
                                    logDescriptionChoice = Console.ReadLine();
                                    Console.Clear();
                                    Console.WriteLine(Header.ShowHeader());


                                    using (MySqlConnection conn = new MySqlConnection(cs))
                                    {
                                        using (MySqlCommand cmd = new MySqlCommand())
                                        {
                                            cmd.Connection = conn;
                                            conn.Open();
                                            cmd.CommandType = System.Data.CommandType.Text;
                                            cmd.CommandText = @"SELECT
	                                                        time_tracker_users.user_id,
	                                                        tracked_calendar_days.calendar_day_id,
	                                                        tracked_calendar_days.calendar_numerical_day,
	                                                        tracked_calendar_dates.calendar_date,
	                                                        activity_categories.activity_category_id,
	                                                        activity_categories.category_description,
	                                                        activity_descriptions.activity_description_id,
	                                                        activity_descriptions.activity_description,
	                                                        activity_times.time_spent_on_activity
                                                        FROM
	                                                        `David_Duenas_MDV229_Database_Month(ex:201910)`.activity_log activity_log,
	                                                        `David_Duenas_MDV229_Database_Month(ex:201910)`.time_tracker_users 
	                                                        time_tracker_users,
	                                                        `David_Duenas_MDV229_Database_Month(ex:201910)`.tracked_calendar_days 
	                                                        tracked_calendar_days,
	                                                        `David_Duenas_MDV229_Database_Month(ex:201910)`.tracked_calendar_dates 
	                                                        tracked_calendar_dates,
	                                                        `David_Duenas_MDV229_Database_Month(ex:201910)`.activity_categories 
	                                                        activity_categories,
	                                                        `David_Duenas_MDV229_Database_Month(ex:201910)`.activity_descriptions 
	                                                        activity_descriptions,
	                                                        `David_Duenas_MDV229_Database_Month(ex:201910)`.activity_times activity_times
                                                        WHERE
	                                                        activity_log.user_id = time_tracker_users.user_id AND
	                                                        activity_log.calendar_day = tracked_calendar_days.calendar_day_id AND
	                                                        activity_log.calendar_date = tracked_calendar_dates.calendar_date_id AND
	                                                        activity_log.category_description = 
	                                                        activity_categories.activity_category_id AND
	                                                        activity_log.activity_description = 
	                                                        activity_descriptions.activity_description_id AND
	                                                        activity_log.time_spent_on_activity = activity_times.activity_time_id AND
	                                                        time_tracker_users.user_id = @log_UserId AND
	                                                        activity_descriptions.activity_description_id = @logDescriptionChoice
                                                        ";

                                            cmd.Parameters.AddWithValue("@logDescriptionChoice", logDescriptionChoice);
                                            cmd.Parameters.AddWithValue("@log_UserId", Login.user_id);

                                            using (MySqlDataReader rdr = cmd.ExecuteReader())
                                            {
                                                while (rdr.Read())
                                                {
                                                    _logCalendarNumericalDay = rdr["calendar_numerical_day"].ToString() as string;
                                                    _logCalendarDate = rdr["calendar_date"].ToString() as string;
                                                    _logCategoryDescription = rdr["category_description"].ToString() as string;
                                                    _logActivityDescription = rdr["activity_description"].ToString() as string;
                                                    _logTimeSpentOnActivity = rdr["time_spent_on_activity"].ToString() as string;


                                                    Console.WriteLine("|Date:| " + _logCalendarDate + " [ " + _logCalendarNumericalDay + " ]" + " |Category:| " + _logCategoryDescription + " |Activity:| " + _logActivityDescription + " |Time:| " + _logTimeSpentOnActivity);
                                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                                    Console.WriteLine("_____________________________________________________________________________________________________________");
                                                    Console.ResetColor();
                                                }
                                            }
                                            try
                                            {

                                                cmd.ExecuteNonQuery();
                                            }
                                            catch (MySqlException ex)
                                            {
                                                Console.WriteLine("Error: {0}", ex.ToString());
                                            }


                                        }
                                        conn.Close();

                                        Menu.LogMenu();
                                        input = Console.ReadLine();
                                        int.TryParse(input, out inputNum);

                                        switch (inputNum)
                                        {
                                            case 1:
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(Header.ShowHeader());
                                                    goto datalog;

                                                }
                                            case 2:
                                                {
                                                    goto mainMenu;
                                                }

                                        }
                                    }
                                    break;

                                }

                        }

                    }

                    break;
                case 3:
                    {
                        Console.Clear();
                        Console.WriteLine(Header.ShowHeader());
                        Menu.RunCalcMenu();


                    }
                    break;
            }
        }


    }
}

