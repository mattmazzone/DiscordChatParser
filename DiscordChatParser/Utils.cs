using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordChatParser
{
    public class Utils
    {
        public static string GetDiscordNameFromDescription(string description)
        {

            if (description.Length < 2)
            {
                return description;
            }

            description = description.Substring(2);

            if (description.IndexOf('*') - 1 == -1)
            {
                return description;
            }

            if (description.IndexOf('*') == -1)
            {
                return "";
            }


            return description.Substring(0, description.IndexOf('*') - 1);            
        }


        public static string GetActionFromDescription(string description)
        {
            if (description.Contains("joined"))
            {
                return "joined";
            }
            else if (description.Contains("left"))
            {
                return "left";
            }
            else if (description.Contains("moved"))
            {
                return "joined";
            }
            else
            {
                return "unknown action";
            }
        }

        public static string GetTargetChannel(string description)
        {

            // Treat moving channel case


            if (description.Contains("voice channel"))
            {
                var channel = description.Split(':', StringSplitOptions.None);
                channel[1] = channel[1].Trim();
                return channel[1].TrimEnd('.');
            }
            else
            {
                return description;
            }
        }



    }
}
