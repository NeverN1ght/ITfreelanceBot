using ITfreelanceBot.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ITfreelanceBot.Dialogs
{
    [Serializable]
    public class DeveloperDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(DeveloperInterviewAsync);

            return Task.CompletedTask;
        }

        private async Task DeveloperInterviewAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            await context.Forward(MakeDeveloperInterview(), ResumeAfterNewDialog, activity, CancellationToken.None);
        }

        internal static IDialog<DeveloperInfo> MakeDeveloperInterview()
        {
            return Chain.From(() => FormDialog.FromForm(DeveloperInfo.BuildForm));
        }

        private async Task ResumeAfterNewDialog(IDialogContext context, IAwaitable<object> result)
        {
            var interview = await result as DeveloperInfo;

            if (interview != null)
            {
                await context.PostAsync("Success, thank you!");
            }
        }
    }
}