using Microsoft.Bot.Builder.FormFlow;
using System;

namespace ITfreelanceBot.Models
{
    [Serializable]
    public class DeveloperInfo
    {
        public string Nickname;

        public string Technologies;

        public ExpirienceOptions? Expirience;

        public int Rate;

        public static IForm<DeveloperInfo> BuildForm()
        {
            return new FormBuilder<DeveloperInfo>().Build();
        }
    }

    public enum ExpirienceOptions
    {
        Junior,
        Middle,
        Senior
    }
}