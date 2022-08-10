using Newtonsoft.Json;

namespace DiscordChatParser
{
    class Program
    {
        static void Main()
        {


            using StreamReader r = new(@"..\..\..\MauxyLogsChannel.json");
            using JsonReader jsonReader = new JsonTextReader(r);
            {
                JsonSerializer serializer = new JsonSerializer();
                var messageList = serializer.Deserialize<List<Messages>>(jsonReader);


                foreach (var message in messageList)
                {
                    Console.WriteLine(message.Id);
                }
                Console.WriteLine(messageList.Count);



            }

        }
    }

    class Messages
    {
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