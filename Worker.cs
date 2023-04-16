using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace graduationProject
{
    internal class Worker
    {
        public int UserId { get; set; }

        public static async Task PrintMainMenuAsync(ITelegramBotClient botClient)
        { 
            var replyKeyboardMarkup = new InlineKeyboardMarkup(new[]
            {
                new[]{
                InlineKeyboardButton.WithCallbackData( text:"Технолог", callbackData:"callBackOfTechnologist" )
                },
                new []{InlineKeyboardButton.WithCallbackData( text:"Швея",callbackData:"callBackOfSeamstress" ) },
                new[]{
                InlineKeyboardButton.WithCallbackData(text:"Стажер/студент/практикант", callbackData:"callBackOfStudent") }
            });
            Message sentMessage = await botClient.SendTextMessageAsync(
                 HandleUpdate.message.Chat.Id,
                 text: "Выберите пользователя",
                 replyMarkup: replyKeyboardMarkup);
            return;
        }

        public static async Task HandleCallbackQuery(ITelegramBotClient botClient, CallbackQuery callbackQuery)
        {
            if (callbackQuery.Data.Equals("callBackOfTechnologist"))
            {
                await Technologist.PrintMenuOfTechnologistAsync(botClient);
            }
            if (callbackQuery.Data.Equals("callBackOfSeamstress"))
            {
                await Seamstress.PrintMenuOfSeamstressAsync(botClient);
            }
            if (callbackQuery.Data.Equals("callBackOfStudent"))
            {
                await Student.PrintMenuOfStudentAsync(botClient);
            }
            return;
        }
    }
}
