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
        private string Name { get; set; }
        private string Technologies { get; set; }
        private string Expirience { get; set; }
        private long Rate { get; set; } // need to do double

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
            resume: TechnologiesReceivedAsync,
            prompt: "Опишите технологии с которыми вы работаете",
            retry: "Вы ввели некорректные данные, попробуйте ещё раз");
        }

        private async Task TechnologiesReceivedAsync(IDialogContext context, IAwaitable<string> result)
        {
            string response = await result;
            Technologies = response;

            PromptDialog.Choice(
            context: context,
            resume: ExpirienceReceivedAsync,
            options: new List<string> { "Junior", "Middle", "Senior"},
            prompt: "Выберите свой уровень",
            retry: "Я не понимаю ваш выбор, попробуйте ещё раз");
        }

        private async Task ExpirienceReceivedAsync(IDialogContext context, IAwaitable<string> result)
        {
            string response = await result;
            Expirience = response;

            PromptDialog.Number(
            context: context,
            resume: RateReceivedAsync,
            prompt: "Введите свой рейт ($/час)",
            retry: "Вы ввели некорректные данные, попробуйте ещё раз");
        }

        private async Task RateReceivedAsync(IDialogContext context, IAwaitable<long> result)
        {
            long response = await result;
            Rate = response;

            await context.PostAsync($"Вы ввели:\n  - Telegram-никнейм: *{Name}*\n  - Технологии: *{Technologies}*\n  - Уровень: *{Expirience}*\n  - Рейт: *{Rate} $/час*");
            context.Done(this);
        }
    }
}