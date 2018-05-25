using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITfreelanceBot.Entities
{
    public class Client
    {
        public int Id { get; set; }

        public int TelegramId { get; set; }

        public string TelegramNickname { get; set; }

        public string OrderDescription { get; set; }

        public string AdditionalInfo { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }
    }
}