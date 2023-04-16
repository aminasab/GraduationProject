using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace graduationProject
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Ссылка на бота- https://t.me/AtechnologistBot
            TelegramBotClient bot = new("6204176520:AAFBOM3RR6kgZ3WKSA61ovl2O9rKrv2XkiU");
            Message? message;
            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);
            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                // Получать все виды обновлений.
                AllowedUpdates = { },
            };
            bot.StartReceiving(
                HandleUpdate.HandleUpdateAsync,
                Exceptions.HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
            Console.ReadLine();
        }
    }
}
