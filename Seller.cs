using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace graduationProject
{
    internal class Seller
    {
        /// <summary>
        /// Вывести меню для продавца-консультанта.
        /// </summary>
        public static async Task PrintMenuForSeller(CallbackQuery callbackQuery)
        {
            var keyBoardMarkupOfSeller = new InlineKeyboardMarkup(new[]
            {
                new []{InlineKeyboardButton.WithCallbackData(text:"Должностные обязанности", "responsibilitiesOfSeller") },
                new []{InlineKeyboardButton.WithCallbackData(text: "Права продавца-консультанта", "rightsOfSeller") },
                new []{InlineKeyboardButton.WithCallbackData(text:"Ответственность", "responsibilityOfSeller") },
                new[]{InlineKeyboardButton.WithCallbackData(text:"Вернуться назад", callbackData:"exitToMainMenu")}
            }
            );
            await Program.bot.SendTextMessageAsync(
                callbackQuery.Message!.Chat.Id,
                "Выберите позицию",
                replyMarkup: keyBoardMarkupOfSeller);
        }

        /// <summary>
        /// Вывести должностные обязанности продавца-консультанта.
        /// </summary>
        public static async Task PrintInformationAboutresponsibilitiesOfSeller(CallbackQuery callbackQuery)
        {
            using StreamReader reader = new("TextFiles\\responsibilitiesOfSeller.txt");
            string text = await reader.ReadToEndAsync();
            await Program.bot.SendTextMessageAsync(
            callbackQuery.Message!.Chat.Id,
            text: text);
        }

        /// <summary>
        /// Вывести права продавца.
        /// </summary>
        public static async Task PrintInformationAboutRightsOfSeller(CallbackQuery callbackQuery)
        {
            using StreamReader reader = new("TextFiles\\rightsOfSeller.txt");
            string text = await reader.ReadToEndAsync();
            await Program.bot.SendTextMessageAsync(
            callbackQuery.Message!.Chat.Id,
            text: text);
        }

        /// <summary>
        /// Вывести ответственность продавца-консультанта.
        /// </summary>
        public static async Task PrintInformationAboutResponsibilityOfSeller(CallbackQuery callbackQuery)
        {
            using StreamReader reader = new("TextFiles\\responsibilityOfSeller.txt");
            string text = await reader.ReadToEndAsync();
            await Program.bot.SendTextMessageAsync(
            callbackQuery.Message!.Chat.Id,
            text: text);
        }
    }
}
