using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace graduationProject
{
    internal class Seamstress
    {
        /// <summary>
        /// Вывести на экран сообщение и инлайн-кнопки для Швеи.
        /// </summary>
        public static async Task PrintMenuOfSeamstressAsync(CallbackQuery callbackQuery)
        {
            var replyKeyboardOfSeamstress = new InlineKeyboardMarkup(new[]
                {
                new[]{
                InlineKeyboardButton.WithCallbackData( text:"Подбор ниток и игл", callbackData:"threadsAndNeedles")},
                new []{InlineKeyboardButton.WithCallbackData( text:"Выбрать пошив изделия",callbackData: "tailoringOfSeamstress")},
                new[]{InlineKeyboardButton.WithCallbackData(text:"Вернуться назад", callbackData:"exitToMainMenu")}
            });
            await Program.bot.SendTextMessageAsync(
                callbackQuery.Message!.Chat.Id,
                "Выберите опцию",
                replyMarkup:replyKeyboardOfSeamstress);
        }

        /// <summary>
        /// Вывод инлайн-кнопок для выбора изделий для швеи. 
        /// </summary>
        public static async Task PrintMenuOfClothesOfSeamstressAsync(CallbackQuery callbackQuery)
        {
            var replyKeyBoardOfClothes = new InlineKeyboardMarkup(new[]
            {
                new []{InlineKeyboardButton.WithCallbackData(text:"Сарафан школьный для девочки", callbackData:"sundressForGirl")},
                new []{InlineKeyboardButton.WithCallbackData(text:"Платье школьное для девочки", callbackData:"dressForGirl")},
                new []{InlineKeyboardButton.WithCallbackData(text:"Рубашка для эколога", callbackData:"shirtForEcologist")},
                new []{InlineKeyboardButton.WithCallbackData(text:"Вернуться назад", callbackData:"backToMenuOfSeamstress")}
            });
            await Program.bot.SendTextMessageAsync(
                callbackQuery.Message!.Chat.Id,
                "Выбирите изделие",
                replyMarkup: replyKeyBoardOfClothes);
        }
    }
}
