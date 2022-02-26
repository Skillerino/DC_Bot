using DSharpPlus;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC_Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            var discordConfiguration = new DiscordConfiguration()
            {
                Intents = DiscordIntents.All,
                MinimumLogLevel = LogLevel.Debug,
                Token = "OTQ3MjI1NDk4Nzg4OTg2OTEx.YhqKfQ.mUM8mujPX5P5HI4oGojjhpCGDKI",
                TokenType = TokenType.Bot,
            };

            var discordClient = new DiscordClient(discordConfiguration);
            await discordClient.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
