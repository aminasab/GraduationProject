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
            try
            {
                if (update.Type == UpdateType.Message)
                {
                    await HandleMessage(
                    botClient, update);
                    return;
                }
                if (update.Type == UpdateType.CallbackQuery)
                {
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
                await Workers.PrintMainMenuAsync(update.Message);
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
                await Workers.PrintMainMenuAsync(callbackQuery.Message!);
            }
            else
            {
                foreach (var del in DelegateOfCallBackInlineButton.callbackDelegates)
                {
                    await del(callbackQuery);
                }
            }
        }
    }
}
