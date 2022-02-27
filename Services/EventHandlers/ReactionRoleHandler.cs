using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC_Bot.Services.EventHandlers
{
    public interface IReactionRoleHandler
    {
        Task handleReactionRoleAdded(DiscordClient client, MessageReactionAddEventArgs context);
        Task handleReactionRoleRemoved(DiscordClient client, MessageReactionAddEventArgs context);
    }


    public class ReactionRoleHandler: IReactionRoleHandler
    {
        DiscordRole _providedRole;

        public ReactionRoleHandler(DiscordRole providedRole)
        {
            _providedRole = providedRole;
        }

        public async Task handleReactionRoleAdded(DiscordClient client, MessageReactionAddEventArgs context)
        {
            throw new NotImplementedException();
        }

        public async Task handleReactionRoleRemoved(DiscordClient client, MessageReactionAddEventArgs context)
        {
            throw new NotImplementedException();
        }
    }
}
