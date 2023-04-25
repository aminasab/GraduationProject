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
        public static async Task PrintMenuOfTechnologistAsync(CallbackQuery callbackQuery)
        {
            var keyBoardMarkupOfTechnologist = new InlineKeyboardMarkup(new[]
            {
                new[]{
                            InlineKeyboardButton.WithCallbackData(text:"Должностная инструкция",callbackData:"jobDescription")},
                new[]{
                            InlineKeyboardButton.WithCallbackData(text:"Оптимизация производства",callbackData:"optimization")},
                new []{
                            InlineKeyboardButton.WithCallbackData(text:"Управление персоналом",callbackData:"management")},
                new[]{
                            InlineKeyboardButton.WithCallbackData(text:"Вернуться в главное меню", callbackData:"exitToMainMenu")}
            });
            await Program.bot.SendTextMessageAsync(
                callbackQuery.Message!.Chat.Id,
                "Выберите опцию",
                replyMarkup: keyBoardMarkupOfTechnologist);
        }

        public static async Task PrintMenuOfJobDescriptionOfTechnologist(CallbackQuery callbackQuery)
        {
            var keyBoardMarkup = new InlineKeyboardMarkup(new[]
            {
                new[]{InlineKeyboardButton.WithCallbackData(text:"Должностные обязанности", callbackData: "responsibilitiesOfTechnologist") },
                new[]{InlineKeyboardButton.WithCallbackData(text:"Права технолога", callbackData:"rightsOfTechnologist")},
                new []{InlineKeyboardButton.WithCallbackData(text:"Ответственность технолога", callbackData: "responsibilityOfTechnologist") }
            });
            await Program.bot.SendTextMessageAsync(
                callbackQuery.Message!.Chat.Id,
                "Выберите опцию",
                replyMarkup: keyBoardMarkup);
        }
    }
}
