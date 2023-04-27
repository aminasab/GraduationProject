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

        /// <summary>
        /// Вывод инлайн-кнопок для выбора изделий для студента и швеи. 
        /// </summary>
        public static async Task PrintMenuOfClothes(CallbackQuery callbackQuery)
        {
            var replyKeyBoardOfClothes = new InlineKeyboardMarkup(new[]
            {
                new []{InlineKeyboardButton.WithCallbackData(text:"Сарафан школьный для девочки", callbackData:"sundressForGirl")},
                new []{InlineKeyboardButton.WithCallbackData(text:"Платье школьное для девочки", callbackData:"dressForGirl")},
                new []{InlineKeyboardButton.WithCallbackData(text:"Рубашка для эколога", callbackData:"shirtForEcologist")}
            });
            await Program.bot.SendTextMessageAsync(
                callbackQuery.Message!.Chat.Id,
                "Выбирите изделие",
                replyMarkup:replyKeyBoardOfClothes);
        }
    }
}
