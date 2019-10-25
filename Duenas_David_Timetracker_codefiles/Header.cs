using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timetracker
{

    class Header
    {
        public static string ShowHeader()
        {
            Console.Title = "Timetracker";
            string title = @"
___________.__                 ___________                     __                 
\__    ___/|__| _____   ____   \__    ___/___________    ____ |  | __ ___________ 
  |    |   |  |/     \_/ __ \    |    |  \_  __ \__  \ _/ ___\|  |/ // __ \_  __ \
  |    |   |  |  Y Y  \  ___/    |    |   |  | \// __ \\  \___|    <\  ___/|  | \/
  |____|   |__|__|_|  /\___  >   |____|   |__|  (____  /\___  >__|_ \\___  >__|   
                    \/     \/                        \/     \/     \/    \/                ";


            return title;
        }

    }
}