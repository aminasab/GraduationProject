using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.Enums;
using System.Threading.Tasks;

namespace graduationProject
{
    internal class Worker
    {
      
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
