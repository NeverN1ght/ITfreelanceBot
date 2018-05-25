using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ITfreelanceBot.Dialogs
{
    [Serializable]
    public class ManagerDialog : IDialog<object>
    {
        private readonly string _managerName;

        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync($"Привет {_managerName}!");
            await context.PostAsync("Этот функционал ещё не реализован");
            context.Done(this);
        }

        public ManagerDialog(string managerName)
        {
            _managerName = managerName;
        }
    }
}