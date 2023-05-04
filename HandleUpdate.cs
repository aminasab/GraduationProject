using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace graduationProject
{
    internal class HandleUpdate
    {
        /// <summary>
        /// Получение обновлений от пользователя.
        /// </summary>
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            WorkersRepository workersRepository = new(ConstantsForConnectionToDB.ConnectionString);
            try
            {
                if (update.Type == UpdateType.Message)
                {
                    await HandleMessage(
                    botClient, update);
                    Worker worker1 = new(
                    update.Message.From.Id,
                    update.Message.From.FirstName,
                    update.Message.From.LastName!,
                    update.Message.From.Username!,
                    update.Message.Text!,
                    DateTime.Now);
                    await workersRepository.InsertData(worker1);
                    return;
                }
                if (update.Type == UpdateType.CallbackQuery)
                {
                    string callback = update.CallbackQuery.Data!;
                    Worker worker2 = new(
                    update.CallbackQuery.From!.Id,
                    update.CallbackQuery.From.FirstName,
                    update.CallbackQuery.From.LastName!,
                    update.CallbackQuery.From.Username!,
                    callback,
                    DateTime.Now);
                    await workersRepository.InsertData(worker2); 
                    await HandleButtonAsync(update.CallbackQuery!);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Обработка сообщений с текстом.
        /// </summary>
        public static async Task HandleMessage(ITelegramBotClient botClient, Update update)
        {
            if (update.Message?.Text?.ToLower() == "/start" || update.Message?.Text?.ToLower() == "начать")
            {
                update.Message.Text = "MenuForTheStart";
                await Worker.PrintMainMenuAsync(update.Message);
            }
            else
            {
                await botClient.SendTextMessageAsync(
                    update.Message!.Chat.Id,
                    "Введите- начать, чтобы продолжить пользование чат-ботом.");
            }
        }

        /// <summary>
        /// Получение ответа от Inline-кнопок.
        /// </summary>
        public static async Task HandleButtonAsync(CallbackQuery callbackQuery)
        {
            if ((callbackQuery.Data == "MenuForTheStart") || (callbackQuery.Data == "exitToMainMenu"))
            {
                await Worker.PrintMainMenuAsync(callbackQuery.Message!);
            }
            else
            {
                foreach (var del in DelegateOfCallBackInlineButton.CallbackDelegates)
                {
                    await del(callbackQuery);
                }
            }
        }
    }
}
