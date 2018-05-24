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
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(ShowWelcomeMessageAsync);
        }

        private async Task ShowWelcomeMessageAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            // тут можно взять активити (айди пользователя)
            await context.PostAsync("Здравствуйте! Я официальный бот канала \"ITfreelance\". Я здесь чтобы помочь вам оставить заявку");
            context.Call(new DefineDialog(), ResumeAfterConversation); //можно передать активити в конструктор
        }

        private async Task ResumeAfterConversation(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("Напишите что-то для возобновления работы...");
        }
    }
}