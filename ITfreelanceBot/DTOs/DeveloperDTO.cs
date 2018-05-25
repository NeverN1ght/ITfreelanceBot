using ITfreelanceBot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITfreelanceBot.DTOs
{
    public class DeveloperDTO
    {
        public string TelegramId { get; set; }

        public string TelegramNickname { get; set; }

        public string Technologies { get; set; }

        public DeveloperLevel Expirience { get; set; }

        public int Rate { get; set; }

        public string AdditionalInfo { get; set; }
    }
}