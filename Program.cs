using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

namespace graduationProject
{
    internal class Program
    {
        // Ссылка на бота- https://t.me/AtechnologistBot
        static public TelegramBotClient bot = new("6204176520:AAFBOM3RR6kgZ3WKSA61ovl2O9rKrv2XkiU");

        public static async Task Main(string[] args)
        {
            var me = await bot.GetMeAsync();
            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);
            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                // Получать все виды обновлений.
                AllowedUpdates = Array.Empty<UpdateType>(),
            };
            bot.StartReceiving(
                HandleUpdate.HandleUpdateAsync,
                Exceptions.HandleErrorAsync,
                receiverOptions,
                cts.Token
            );
            Console.ReadLine();
            cts.Cancel();
        }
    }
}
