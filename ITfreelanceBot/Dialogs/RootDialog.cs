using System;
using System.Threading;
using System.Threading.Tasks;
using ITfreelanceBot.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;
using ITfreelanceBot.Dialogs;
using System.Collections.Generic;

namespace ITfreelanceBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        private enum Role
        {
            Client,
            Developer
        }

        public Task StartAsync(IDialogContext context)
        {
            context.PostAsync("Hello from A2Lab!");

            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            PromptDialog.Choice(
                context,
                this.OnSelectedRoleAsync,
                new List<Role>() { Role.Client, Role.Developer},
                "Select your role",
                "I don't understand your choice",
                3);

            //await context.Forward(new DeveloperDialog(), End, activity, CancellationToken.None);

        }

        private async Task OnSelectedRoleAsync(IDialogContext context, IAwaitable<Role> role, IAwaitable<object> result)
        {
            var selectedRole = await role;

            var activity = await result as Activity;

            switch (selectedRole)
            {
                case Role.Client:
                    //await context.Forward(new ClientDialog(), End, activity, CancellationToken.None);
                    break;
                case Role.Developer:
                    await context.Forward(new DeveloperDialog(), End, activity, CancellationToken.None);
                    break;
            }
        }

        private async Task End(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("Done!");
        }
    }
}