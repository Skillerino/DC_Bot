using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC_Bot.CommandModules
{
    public class MainCommands : BaseCommandModule
    {
        [Command("ping")]
        public async Task ping(CommandContext ctx)
        {
            await ctx.RespondAsync("Pong!");
        }
    }
}
