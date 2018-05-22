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
        private int role = 0;

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
                OnSelectedRoleAsync,
                new List<Role>() { Role.Client, Role.Developer},
                "Select your role",
                "I don't understand your choice");
        }

        private async Task OnSelectedRoleAsync(IDialogContext context, IAwaitable<Role> role)
        {
            Role selectedRole = await role;

            switch (selectedRole)
            {
                case Role.Client:
                    //context.Call(n);
                    break;
                case Role.Developer:
                    context.Call(new DeveloperDialog(), ResumeAfterNewDialog);
                    break;
            }
        }


        private async Task ResumeAfterNewDialog(IDialogContext context, IAwaitable<object> result)
        {
            var interview = await result as DeveloperInfo;

            if (interview != null)
            {
                await context.PostAsync("Success, thank you!");
            }
        }

        //private async Task End(IDialogContext context, IAwaitable<object> result)
        //{
        //    await context.PostAsync("Done!");
        //}
    }
}