using DC_Bot.CommandModules;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC_Bot
{
    class Bot
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextExtension Commands { get; private set; }
        public InteractivityExtension Interactivity { get; private set; }

        public Bot()
        {
            var json = string.Empty;

            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = sr.ReadToEnd();

            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);
            var discordConfiguration = new DiscordConfiguration()
            {
                Intents = DiscordIntents.DirectMessages
                |DiscordIntents.GuildMembers
                |DiscordIntents.GuildMessageReactions
                |DiscordIntents.GuildMessages
                |DiscordIntents.GuildPresences
                |DiscordIntents.Guilds
                |DiscordIntents.GuildVoiceStates,
                MinimumLogLevel = LogLevel.Debug,
                Token = configJson.Token,
                TokenType = TokenType.Bot,
            };

            Client = new DiscordClient(discordConfiguration);

            var commandsConfiguration = new CommandsNextConfiguration()
            {
                DmHelp = true,
                EnableDms = false,
                StringPrefixes = new[] { "!" },
            };
            Commands = Client.UseCommandsNext(commandsConfiguration);

            Commands.RegisterCommands<MainCommands>(); ;
        }

        public async Task RunAsync()
        {
            await Client.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
