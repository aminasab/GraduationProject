using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

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
                new[]{InlineKeyboardButton.WithCallbackData(text:"Должностная инструкция",callbackData:"jobDescription")},
                new[]{InlineKeyboardButton.WithCallbackData(text:"Оптимизация производства",callbackData:"optimization")},
                new []{InlineKeyboardButton.WithCallbackData(text:"Управление персоналом",callbackData:"management")},
                new[]{InlineKeyboardButton.WithCallbackData(text:"Вернуться назад", callbackData:"exitToMainMenu")}
            });
            await Program.bot.SendTextMessageAsync(
                callbackQuery.Message!.Chat.Id,
                "Выберите опцию",
                replyMarkup: keyBoardMarkupOfTechnologist);
        }

        /// <summary>
        /// Вывести информацию об оптимизации производства для технолога.
        /// </summary>
        public static async Task PrintInformationAboutOptimization(CallbackQuery callbackQuery)
        {
            using StreamReader reader = new StreamReader("TextFiles\\optimization.txt");
            string text = await reader.ReadToEndAsync();
            await Program.bot.SendTextMessageAsync(
            callbackQuery.Message!.Chat.Id,
            text);
        }

        /// <summary>
        /// Вывести информацию об управлении персоналом для технолога.
        /// </summary>
        public static async Task PrintInformationaboutManagement(CallbackQuery callbackQuery)
        {
            using StreamReader reader = new StreamReader("TextFiles\\personalMenegment.txt");
            string text = await reader.ReadToEndAsync();
            await Program.bot.SendTextMessageAsync(
            callbackQuery.Message!.Chat.Id,
            text);
        }

        /// <summary>
        /// Вывести меню инлайн-кнопок Должностных инструкций для технолога.
        /// </summary>
        public static async Task PrintMenuOfJobDescriptionOfTechnologist(CallbackQuery callbackQuery)
        {
            var keyBoardMarkup = new InlineKeyboardMarkup(new[]
            {
                new[]{InlineKeyboardButton.WithCallbackData(text:"Должностные обязанности", callbackData: "responsibilitiesOfTechnologist") },
                new[]{InlineKeyboardButton.WithCallbackData(text:"Права технолога", callbackData:"rightsOfTechnologist")},
                new []{InlineKeyboardButton.WithCallbackData(text:"Ответственность технолога", callbackData: "responsibilityOfTechnologist") },
                new []{InlineKeyboardButton.WithCallbackData(text:"Вернуться назад", callbackData:"backToMenuOfTechnologist")}
            });
            await Program.bot.SendTextMessageAsync(
                callbackQuery.Message!.Chat.Id,
                "Выберите опцию",
                replyMarkup: keyBoardMarkup);
        }

        /// <summary>
        /// Вывести информацию о должностных обязанностях технолога.
        /// </summary>
        public static async Task PrintResponsibilitiesOfTechnologist(CallbackQuery callbackQuery)
        {
            using StreamReader reader = new StreamReader("TextFiles\\responsibilitiesOfTechnologist.txt");
            string text = await reader.ReadToEndAsync();
            await Program.bot.SendTextMessageAsync(
            callbackQuery.Message!.Chat.Id,
            text);
        }

        /// <summary>
        /// Вывести информацию о правах технолога.
        /// </summary>
        public static async Task PrintRightsOfTechnologist(CallbackQuery callbackQuery)
        {
            using StreamReader reader = new StreamReader("TextFiles\\rightsOfTechnologist.txt");
            string text = await reader.ReadToEndAsync();
            await Program.bot.SendTextMessageAsync(
            callbackQuery.Message!.Chat.Id,
            text);
        }

        /// <summary>
        /// Вывести информацию об ответственности технолога.
        /// </summary>
        public static async Task PrintResponsibilityOfTechnologist(CallbackQuery callbackQuery)
        {
            using StreamReader reader = new StreamReader("TextFiles\\responsibilityOfTechnologist.txt");
            string text = await reader.ReadToEndAsync();
            await Program.bot.SendTextMessageAsync(
            callbackQuery.Message!.Chat.Id,
            text);
        }
    }
}
