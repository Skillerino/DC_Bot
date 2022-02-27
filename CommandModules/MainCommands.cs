using DC_Bot.Services.EventHandlers;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC_Bot.CommandModules
{
    public class MainCommands : BaseCommandModule
    {
        public ReactionRoleHandler reactionRoleHandler {private get; set;}

        [Command("ping")]
        public async Task ping(CommandContext ctx)
        {
            await ctx.RespondAsync("Pong!");
        }

        [Command("reactionRole")]
        public async Task ReactionRole(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            var roleOptions = new List<DiscordSelectComponentOption>();
            foreach(DiscordRole role in ctx.Guild.Roles.Values)
            {
                roleOptions.Add(new DiscordSelectComponentOption(role.Name, role.Id.ToString(), role.Id.ToString()));
            }
            var dropdown = new DiscordSelectComponent("dropdown_reactionRole", "Please select", roleOptions, false, 1);

            var confirmButton = new DiscordButtonComponent(ButtonStyle.Success, "confirm_reactionRole_role", "Confirm");

            var selectionBuilder = new DiscordMessageBuilder().WithContent("Please select a Role for Reaction Role:").AddComponents(dropdown).AddComponents(confirmButton);



            ctx.Client.ComponentInteractionCreated += async (s, e) =>
             {
                 if (e.Id == "dropdown_reactionRole" && e.User.Id == ctx.User.Id)
                 {
                     await e.Interaction.CreateResponseAsync(InteractionResponseType.DeferredMessageUpdate);
                     await ctx.Channel.SendMessageAsync(e.Interaction.Data.Values.First());
                 }
             };

            ctx.Client.ComponentInteractionCreated += async (s, e) =>
            {
                if (e.Id == "confirm_reactionRole_role" && e.User == ctx.User)
                {
                    await e.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().WithContent("Reaction Role"));

                    //await selectionMessage.DeleteAsync();

                    var reactionRoleMessageBuilder = new DiscordMessageBuilder().WithContent("Reaction Role");

                    await reactionRoleMessageBuilder.SendAsync(ctx.Channel);

                    var reactionRoleMessage = ctx.Channel.GetMessageAsync((ulong)reactionRoleMessageBuilder.ReplyId).Result;


                }
            };

            await selectionBuilder.SendAsync(ctx.Channel);
        }
    }
}
