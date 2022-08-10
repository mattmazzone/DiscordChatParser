using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DiscordChatParser {
    class Program
    {
        static void Main()
        {


            using StreamReader r = new(@"C:\Users\matte\source\repos\DiscordChatParser\DiscordChatParser\MauxyLogsChannel.json");
            // Read and parse json file
            string json = r.ReadToEnd();
            JObject jsonObj = JObject.Parse(json);

            JToken? jsonToken = jsonObj["messages"];
            if (jsonToken is null)
            {
                Console.WriteLine("Json token is null");
                return;
            }

            // Convert to string
            string results = jsonToken.ToString();

            var messageList = JsonConvert.DeserializeObject<List<Messages>>(results);

            foreach (Messages message in messageList)
            {


                
    
            if (message.Embeds.Count > 0)
                {
                    string name = Utils.GetDiscordNameFromDescription(message.Embeds[0].Description);
                    string action = Utils.GetActionFromDescription(message.Embeds[0].Description);
                    string channel = Utils.GetTargetChannel(message.Embeds[0].Description);

                Console.WriteLine(name + " " + action + " " + channel + " at " + message.Timestamp);
                }

            }
        }



    }

    class Messages {
        public string? Id { get; set; }
        public string? Type { get; set; }
        public string? Timestamp { get; set; }
        public string? TimestampEdited { get; set; }
        public string? CallEndedTimestamp { get; set; }
        public string? IsPinned { get; set; }
        public string? Content { get; set; }

        // Author

        // public string? Attachments { get; set; }

        public List<EmbedsMessage>? Embeds { get; set; }

        // public string? Stickers { get; set; }
        // public string? Reactions { get; set; }
        // public string? Mentions { get; set; }


        public class EmbedsMessage
        {
            public string? Description { get; set; }
        }


    }
}