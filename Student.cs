using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace graduationProject
{
    internal class Student
    {
        /// <summary>
        /// Вывести на экран сообщение и инлайн-кнопки для Практиканта/Стажера/Студента.
        /// </summary>
        public static async Task PrintMenuOfStudentAsync(CallbackQuery callbackQuery)
        {
            var replyKeyboardOfStudent = new InlineKeyboardMarkup(new[]
                {
                new[]{
                InlineKeyboardButton.WithCallbackData( text:"Подбор ниток и игл", callbackData:"threadsAndNeedles")
                },
                new []{InlineKeyboardButton.WithCallbackData( text:"Выбрать пошив изделия",callbackData: "tailoring")
                },
                new []{InlineKeyboardButton.WithCallbackData(text:"Заправка оборудования", callbackData: "refuelingEquipment") }
            });
            await Program.bot.SendTextMessageAsync(
                callbackQuery.Message!.Chat.Id, 
                "Выберите опцию", 
                replyMarkup: replyKeyboardOfStudent);
        }
    }
}
