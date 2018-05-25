using ITfreelanceBot.DTOs;
using ITfreelanceBot.Entities;
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
        private DeveloperDTO developerDTO;

        public DeveloperDialog(string telegramId, string telegramName)
        {
            developerDTO = new DeveloperDTO
            {
                TelegramId = telegramId,
                TelegramNickname = telegramName
            };
        }

        public async Task StartAsync(IDialogContext context)
        {
            PromptDialog.Text(
            context: context,
            resume: TechnologiesReceivedAsync,
            prompt: "Опишите технологии с которыми вы работаете",
            retry: "Вы ввели некорректные данные, попробуйте ещё раз");
        }

        private async Task TechnologiesReceivedAsync(IDialogContext context, IAwaitable<string> result)
        {
            developerDTO.Technologies = await result;

            PromptDialog.Choice(
            context: context,
            resume: ExpirienceReceivedAsync,
            options: new List<DeveloperLevel> { DeveloperLevel.Junior, DeveloperLevel.Middle, DeveloperLevel.Senior},
            prompt: "Выберите свой уровень",
            retry: "Я не понимаю ваш выбор, попробуйте ещё раз");
        }

        private async Task ExpirienceReceivedAsync(IDialogContext context, IAwaitable<DeveloperLevel> result)
        {
            developerDTO.Expirience = await result;

            PromptDialog.Number(
            context: context,
            resume: RateReceivedAsync,
            prompt: "Введите свой рейт ($/час)",
            retry: "Вы ввели некорректные данные, попробуйте ещё раз");
        }

        private async Task RateReceivedAsync(IDialogContext context, IAwaitable<long> result)
        {
            developerDTO.Rate = (int)await result;

            PromptDialog.Text(
            context: context,
            resume: AdditionalInfoReceivedAsync,
            prompt: "Введите дополнительную информацию",
            retry: "Вы ввели некорректные данные, попробуйте ещё раз");
        }

        private async Task AdditionalInfoReceivedAsync(IDialogContext context, IAwaitable<string> result)
        {
            developerDTO.AdditionalInfo = await result;

            await context.PostAsync($"Вы ввели:\n  - Telegram-id: *{developerDTO.TelegramId}*\n  - Telegram-никнейм: *{developerDTO.TelegramNickname}*\n  - Технологии: *{developerDTO.Technologies}*\n  - Уровень: *{developerDTO.Expirience}*\n  - Рейт: *{developerDTO.Rate} $/час*");
            context.Done(this);
        }
    }
}