using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using System.Threading;
using Microsoft.VisualBasic;

namespace graduationProject
{
    internal class HandleUpdate
    {
        public static Message? message;
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            message = update.Message;
            if (update.Type == UpdateType.Message && update?.Message?.Text != null)
            {
                await HandleMessage(botClient, update.Message, update, cancellationToken);
                return;
            }
            if (update.Type == UpdateType.CallbackQuery)
            {
                await Worker.HandleCallbackQuery(botClient, update.CallbackQuery);
                return;
            }
        }

        public static async Task HandleMessage(ITelegramBotClient botClient, Message message, Update update, CancellationToken cancellationToken)
        {
            if (message?.Text?.ToLower() == "/start" || message?.Text?.ToLower() == "начать")
            {
                await Worker.PrintMainMenuAsync(botClient);
            }
            else
            {
                Message sentMessage = await botClient.SendTextMessageAsync(
                 message.Chat.Id,
                 text: "Введите- начать, чтобы продолжить пользование чат-ботом.");
            }
        }
    }
}
