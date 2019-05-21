using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondPart
{
   static public class Logger
    {
        static private List<string> currentSessionActivities = new List<string>();

        static public void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";" /*+ LoginValidation.currentUserUsername + ";"+ LoginValidation.currentUserRole*/ + ";"+ activity;
            currentSessionActivities.Add(activityLine);

            File.AppendAllText("test.txt", activityLine);
        }

        public static String GetCurrentSessionActivities(String filter)
        {
            List<String> filteredActivities = (from activity in currentSessionActivities where activity.Contains(filter) select activity).ToList();
            StringBuilder loggerBuilder = new StringBuilder();
            foreach (var currentLog in currentSessionActivities)
            {
                loggerBuilder.Append(currentLog);
                loggerBuilder.Append(Environment.NewLine);
            }
            return loggerBuilder.ToString();
        }



    }
}
