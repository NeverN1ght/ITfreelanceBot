namespace ITfreelanceBot.Context
{
    using ITfreelanceBot.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BotDbContext : DbContext
    {
        // Контекст настроен для использования строки подключения "BotDbContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "ITfreelanceBot.Context.BotDbContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "BotDbContext" 
        // в файле конфигурации приложения.
        public BotDbContext()
            : base("name=BotDbContext")
        {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Developer> Developers { get; set; }
    }
}