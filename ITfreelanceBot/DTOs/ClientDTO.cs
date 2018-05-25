using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITfreelanceBot.DTOs
{
    public class ClientDTO
    {
        public string TelegramId { get; set; }

        public string TelegramNickname { get; set; }

        public string OrderDescription { get; set; }

        public string AdditionalInfo { get; set; }
    }
}