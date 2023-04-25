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
                    botClient, update.Message!);
                    return;
                }
                if (update.Type == UpdateType.CallbackQuery)
                {
                    await HandleButtonAsync(update.CallbackQuery!);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Обработка сообщений с текстом.
        /// </summary>
        public static async Task HandleMessage(ITelegramBotClient botClient, Message message )
        {
            if (message?.Text?.ToLower() == "/start" || message?.Text?.ToLower() == "начать")
            {
                await Worker.PrintMainMenuAsync(message);
            }
            else
            {
                await botClient.SendTextMessageAsync(
                    message!.Chat.Id, 
                    "Введите- начать, чтобы продолжить пользование чат-ботом.");
            }
        }

        /// <summary>
        /// Получение ответа от Inline-кнопок.
        /// </summary>
        public static async Task HandleButtonAsync(CallbackQuery callbackQuery)
        {
            if (callbackQuery.Data=="callBackOfTechnologist")
                {
                    await Technologist.PrintMenuOfTechnologistAsync(callbackQuery);
                }
            if (callbackQuery.Data=="callBackOfSeamstress")
            {
                await Seamstress.PrintMenuOfSeamstressAsync(callbackQuery);
            }
            if (callbackQuery.Data == "callBackOfStudent")
            {
                await Student.PrintMenuOfStudentAsync(callbackQuery);
            }
            if (callbackQuery.Data== "callBackOfSeller")
            {
                await Seller.PrintMenuForSeller(callbackQuery);
            }
        }
    }
}
