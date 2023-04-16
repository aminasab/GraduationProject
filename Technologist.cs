using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace graduationProject
{
    internal class Technologist
    {
        /// <summary>
        /// Вывести на экран сообщение и инлайн-кнопки для Технолога.
        /// </summary>
        public static async Task PrintMenuOfTechnologistAsync(ITelegramBotClient botClient)
        {
            var keyBoardMarkupOfTechnologist = new InlineKeyboardMarkup(new[]
            {
                new[]{
                            InlineKeyboardButton.WithCallbackData(text:"Реорганизация предприятия",callbackData:"reorganization")},
                new[]{
                            InlineKeyboardButton.WithCallbackData(text:"Оптимизация производства",callbackData:"optimization")},
                new []{
                            InlineKeyboardButton.WithCallbackData(text:"Управление персоналом",callbackData:"management")},
                new[]{
                            InlineKeyboardButton.WithCallbackData(text:"Вернуться в главное меню", callbackData:"exitToMainMenu")}
            });
            Message sentMessage = await botClient.SendTextMessageAsync(
                HandleUpdate.message.Chat.Id,
                text: "Выберите опцию",
                replyMarkup: keyBoardMarkupOfTechnologist);
            return;
        }
    }
}
