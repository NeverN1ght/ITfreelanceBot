using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ITfreelanceBot.Dialogs
{
    [Serializable]
    public class DefineDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            // define if user already exists
            PromptDialog.Choice(
                context,
                OnSelectedRoleAsync,
                //(IEnumerable<Roles>)Enum.GetValues(typeof(Roles)),
                new List<string> {"Я заказчик", "Я разработчик"},
                "Выберите кто вы",
                "Я не понимаю ваш выбор, попробуйте ещё раз");
        }

        private async Task OnSelectedRoleAsync(IDialogContext context, IAwaitable<string> role)
        {
            try
            {
                string selectedRole = await role;

                switch (selectedRole)
                {
                    case "Я заказчик":
                        context.Call(new ClientDialog(), ResumeAfterConversation);
                        break;
                    case "Я разработчик":
                        context.Call(new DeveloperDialog(), ResumeAfterConversation);
                        break;
                }
            }
            catch (TooManyAttemptsException)
            {
                await context.PostAsync("Слишком много попыток");
            }
        }

        private async Task ResumeAfterConversation(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("Данные были успешно записаны!");
            context.Done(this);
        }
    }
}