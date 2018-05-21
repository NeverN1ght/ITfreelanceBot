using Microsoft.Bot.Builder.FormFlow;
using System;

namespace ITfreelanceBot.Models
{
    [Serializable]
    public class ClientInfo
    {
        public string Nickname;

        public string OrderDescription;

        public static IForm<ClientInfo> BuildForm()
        {
            return new FormBuilder<ClientInfo>().Build();
        }
    }
}