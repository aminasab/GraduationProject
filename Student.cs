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
            if ((callbackQuery.Data== "callBackOfStudent")||(callbackQuery.Data== "backToMenuOfStudent")) {
                var replyKeyboardOfStudent = new InlineKeyboardMarkup(new[]
                    {
                new[]{
                InlineKeyboardButton.WithCallbackData( text:"Подбор ниток и игл", callbackData:"threadsAndNeedles")
                },
                new []{InlineKeyboardButton.WithCallbackData( text:"Выбрать пошив изделия",callbackData: "tailoringOfStudent")
                },
                new []{InlineKeyboardButton.WithCallbackData(text:"Заправка оборудования", callbackData: "refuelingEquipment") },
                new[]{InlineKeyboardButton.WithCallbackData(text:"Вернуться назад", callbackData:"exitToMainMenu")}
            });
                await Program.bot.SendTextMessageAsync(
                    callbackQuery.Message!.Chat.Id,
                    "Выберите опцию",
                    replyMarkup: replyKeyboardOfStudent);
            }
        }

        /// <summary>
        /// Вывод инлайн-кнопок для выбора изделий для студента. 
        /// </summary>
        public static async Task PrintMenuOfClothesOfStudentAsync(CallbackQuery callbackQuery)
        {
            if (callbackQuery.Data == "tailoringOfStudent") {
                var replyKeyBoardOfClothes = new InlineKeyboardMarkup(new[]
                {
                new []{InlineKeyboardButton.WithCallbackData(text:"Сарафан школьный для девочки", callbackData:"sundressForGirl")},
                new []{InlineKeyboardButton.WithCallbackData(text:"Платье школьное для девочки", callbackData:"dressForGirl")},
                new []{InlineKeyboardButton.WithCallbackData(text:"Рубашка для эколога", callbackData:"shirtForEcologist")},
                new []{InlineKeyboardButton.WithCallbackData(text:"Вернуться назад", callbackData:"backToMenuOfStudent")}
                });
                await Program.bot.SendTextMessageAsync(
                    callbackQuery.Message!.Chat.Id,
                    "Выбирите изделие",
                    replyMarkup: replyKeyBoardOfClothes);
            }
        }

        /// <summary>
        /// Вывести меню кнопок для выбора оборудования для заправки.
        /// </summary>
        public static async Task PrintMenuOfEquipmentAsync(CallbackQuery callbackQuery)
        {
            if (callbackQuery.Data== "refuelingEquipment") {
                var replyKeyboardOfStudent = new InlineKeyboardMarkup(new[]
                {
                new[]{
                InlineKeyboardButton.WithUrl( text:"Промышленная прямострочная машина", url:"https://www.youtube.com/watch?v=Uud4xtSH0FQ&t=3s")
                },
                new[]{InlineKeyboardButton.WithUrl(text:"Четырехниточный оверлок", url: "https://www.youtube.com/watch?v=WtFNixJLRXs") },
                new []{InlineKeyboardButton.WithUrl(text:"Пятиниточный оверлок", url: "https://www.youtube.com/watch?v=DVlmZuupGDY") },
                new []{InlineKeyboardButton.WithCallbackData(text:"Вернуться назад", callbackData:"backToMenuOfStudent")}
                });
                await Program.bot.SendTextMessageAsync(
                    callbackQuery.Message!.Chat.Id,
                    "Выберите машину для заправки",
                    replyMarkup: replyKeyboardOfStudent);
            }
        }
    }
}
