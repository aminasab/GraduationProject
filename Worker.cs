using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace graduationProject
{
    internal class Worker
    {
      /// <summary>
      /// Вывод общего первоначального меню.
      /// </summary>
        public static async Task PrintMainMenuAsync(Message message)
        {
            var replyKeyboardMarkup = new InlineKeyboardMarkup(new[]
            {
                new[]{
                InlineKeyboardButton.WithCallbackData( text:"Технолог", callbackData:"callBackOfTechnologist" )
                },
                new []{InlineKeyboardButton.WithCallbackData( text:"Швея",callbackData:"callBackOfSeamstress" ) },
                new[]{
                InlineKeyboardButton.WithCallbackData(text:"Стажер/студент/практикант", callbackData:"callBackOfStudent") 
                },
                new[]{InlineKeyboardButton.WithCallbackData(text:"Продавец-консультант", callbackData:"callBackOfSeller") }
            });
            await Program.bot.SendTextMessageAsync(
                message.Chat.Id, 
                "Выберите пользователя", 
                replyMarkup:replyKeyboardMarkup);
        }
    }
}
