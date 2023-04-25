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
                InlineKeyboardButton.WithCallbackData( text:"Подбор ниток и игл", callbackData:"threadsAndNeedles" )
                },
                new []{InlineKeyboardButton.WithCallbackData( text:"Выбрать пошив изделия",callbackData: "tailoring")
                }
            });
            await Program.bot.SendTextMessageAsync(
                callbackQuery.Message!.Chat.Id,
                "Выберите опцию",
                replyMarkup:replyKeyboardOfSeamstress);
        }
    }
}
