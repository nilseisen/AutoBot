using Discord;
using Discord.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBot
{
    class MyBot
    {
        DiscordClient discord;
        public MyBot()
        {
            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            var commands = discord.GetService<CommandService>();

            commands.CreateCommand("Hi")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Hello");
                });

            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MzE1NTAyOTUzMzQ1NzEyMTUw.DAHzjg.z5IpW2uyTQ5ZHy7XJ533cH0p2MQ", TokenType.Bot);
            });
        }

        private void Log(Object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
