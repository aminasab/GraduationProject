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
        public static async Task PrintMenuOfSeamstressAsync(ITelegramBotClient botClient)
        {
            var replyKeyboardOfSeamstress = new InlineKeyboardMarkup(new[]
                {
                new[]{
                InlineKeyboardButton.WithCallbackData( text:"Подбор ниток и игл", callbackData:"threadsAndNeedles" )
                },
                new []{InlineKeyboardButton.WithCallbackData( text:"Выбрать пошив изделия",callbackData: "tailoring")
                }
            });
            Message sentMessage = await botClient.SendTextMessageAsync(
                 HandleUpdate.message.Chat.Id,
                 text: "Выберите опцию",
                 replyMarkup: replyKeyboardOfSeamstress);
            return;
        }
    }
}
