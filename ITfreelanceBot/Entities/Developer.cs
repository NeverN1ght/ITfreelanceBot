using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITfreelanceBot.Entities
{
    public class Developer
    {
        public int Id { get; set; }

        public int TelegramId { get; set; }

        public string TelegramNickname { get; set; }

        public string Technologies { get; set; }

        public DeveloperLevel Expirience { get; set; }

        public int Rate { get; set; }

        public string AdditionalInfo { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }
    }
}