using System;

namespace EmailExample
{
    // Email class representing an email message
    class Email
    {
        public string Theme { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }

    // Logging interface abstraction
    interface ILogger
    {
        void Log(string message);
    }

    // Console logger implementation of ILogger
    class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    // EmailSender class responsible only for sending emails
    class EmailSender
    {
        private readonly ILogger _logger;

        // Constructor injection of the logger
        public EmailSender(ILogger logger)
        {
            _logger = logger;
        }

        public void Send(Email email)
        {
            // ... sending logic ...

            // Logging using the injected logger
            _logger.Log($"Email from '{email.From}' to '{email.To}' was sent");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Email e1 = new Email() { From = "Me", To = "Vasya", Theme = "Who are you?" };
            Email e2 = new Email() { From = "Vasya", To = "Me", Theme = "Vacuum cleaners!" };
            Email e3 = new Email() { From = "Kolya", To = "Vasya", Theme = "No! Thanks!" };
            Email e4 = new Email() { From = "Vasya", To = "Me", Theme = "Washing machines!" };
            Email e5 = new Email() { From = "Me", To = "Vasya", Theme = "Yes" };
            Email e6 = new Email() { From = "Vasya", To = "Petya", Theme = "+2" };

            // Instantiate the logger
            ILogger logger = new ConsoleLogger();

            // Instantiate the EmailSender with the logger
            EmailSender emailSender = new EmailSender(logger);

            // Send emails
            emailSender.Send(e1);
            emailSender.Send(e2);
            emailSender.Send(e3);
            emailSender.Send(e4);
            emailSender.Send(e5);
            emailSender.Send(e6);

            Console.ReadKey();
        }
    }
}
