using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ITfreelanceBot.Dialogs
{
    [Serializable]
    public class ClientDialog: IDialog<object>
    {
        public string Name { get; set; }
        public string Order { get; set; }

        public async Task StartAsync(IDialogContext context)
        {
            PromptDialog.Text(
            context: context,
            resume: NameReceivedAsync,
            prompt: "Введите свой Telegram-никнейм",
            retry: "Вы ввели некорректные данные, попробуйте ещё раз");
        }

        private async Task NameReceivedAsync(IDialogContext context, IAwaitable<string> result)
        {
            string response = await result;
            Name = response;

            PromptDialog.Text(
            context: context,
            resume: OrderReceivedAsync,
            prompt: "Опишите ваш заказ",
            retry: "Вы ввели некорректные данные, попробуйте ещё раз");
        }

        private async Task OrderReceivedAsync(IDialogContext context, IAwaitable<string> result)
        {
            string response = await result;
            Order = response;

            await context.PostAsync($"Вы ввели:\n  - Telegram-никнейм: *{Name}*\n  - Заказ: *{Order}*");
            context.Done(this);
        }
    }
}