using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

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
                InlineKeyboardButton.WithCallbackData(text:"Стажер/студент/практикант", callbackData:"callBackOfStudent")},
                new[]{InlineKeyboardButton.WithCallbackData(text:"Продавец-консультант", callbackData:"callBackOfSeller") },
                new[]{InlineKeyboardButton.WithCallbackData(text:"Мастер-класс по ВТО", callbackData:"callbackOfMasterClass")}
            });
            await Program.bot.SendTextMessageAsync(
                message.Chat.Id,
                "Выберите пользователя / опцию",
                replyMarkup: replyKeyboardMarkup);
        }

        /// <summary>
        /// Вывод информации о сарафане для девочек для студента и швеи.
        /// </summary>
        public static async Task PrintInformationOfSundressAsync(CallbackQuery callbackQuery)
        {
            var drawingOfSundress = "https://disk.yandex.ru/i/uKvKLRllANBoZA";
            var photoUrl = "https://disk.yandex.ru/i/4aha9_ew2d-_dw";
            var photoOfprocessingMethods = "https://disk.yandex.ru/i/V9XpmeqBt1UEVg";
            await Program.bot.SendPhotoAsync(
            callbackQuery.Message!.Chat.Id,
                photo: photoUrl);

            using (StreamReader reader = new("TextFiles\\sundressForGirls.txt"))
            {
                string text = await reader.ReadToEndAsync();
                await Program.bot.SendPhotoAsync(
                callbackQuery.Message!.Chat.Id,
                photo: drawingOfSundress,
                caption: text,
                parseMode: ParseMode.Html);
            }
            await Program.bot.SendPhotoAsync(
                callbackQuery.Message!.Chat.Id,
                photo: photoOfprocessingMethods);
        }

        /// <summary>
        /// Вывод информации о платье для девочек, для студента и швеи.
        /// </summary>
        public static async Task PrintInformationOfDressAsync(CallbackQuery callbackQuery)
        {
            var drawingOfDress = "https://disk.yandex.ru/i/q3UV96AaOk-s3g";
            var photoOfDress = "https://disk.yandex.ru/i/xyK-KxCkStMWQA";
            var photoOfprocessingMethods = "https://disk.yandex.ru/i/VaE50B3YZxeLAg";
            await Program.bot.SendPhotoAsync(
           callbackQuery.Message!.Chat.Id,
               photo: photoOfDress);
            using (StreamReader reader = new("TextFiles\\dressForGirl.txt"))
            {
                string text = await reader.ReadToEndAsync();
                await Program.bot.SendPhotoAsync(
                callbackQuery.Message!.Chat.Id,
                photo: drawingOfDress,
                caption: text,
                parseMode: ParseMode.Html);
            }
            await Program.bot.SendPhotoAsync(
           callbackQuery.Message!.Chat.Id,
               photo: photoOfprocessingMethods);
        }

        /// <summary>
        /// Вывод информации о рубашке для эколога, для студента/швеи.
        /// </summary>
        public static async Task PrintInformationOfShirtAsync(CallbackQuery callbackQuery)
        {
            var drawingOfShirt = "https://disk.yandex.ru/i/E8OaOCDYkzdY_Q";
            var photoOfShirt = "https://disk.yandex.ru/i/7BmcP7scP8lrBw";
            var photoOfprocessingMethods = "https://disk.yandex.ru/i/yf6BN8OSjO0sQw";
            await Program.bot.SendPhotoAsync(
           callbackQuery.Message!.Chat.Id,
               photo: photoOfShirt);
            using (StreamReader reader = new("TextFiles\\shirtForEcologist.txt"))
            {
                string text = await reader.ReadToEndAsync();
                await Program.bot.SendPhotoAsync(
                callbackQuery.Message!.Chat.Id,
                photo: drawingOfShirt,
                caption: text,
                parseMode: ParseMode.Html);
            }
            await Program.bot.SendPhotoAsync(
            callbackQuery.Message!.Chat.Id,
            photo: photoOfprocessingMethods);
        }

        /// <summary>
        /// Вывод изображения о выборе ниток и игл, для студента/швеи.
        /// </summary>
        public static async Task PrintInformationAboutThreadsAndNeedles(CallbackQuery callbackQuery)
        {
            var photo = "https://disk.yandex.ru/i/zUwaNyj0GHuNRw";
            await Program.bot.SendPhotoAsync(
                callbackQuery.Message!.Chat.Id,
                photo);
        }

        public static async Task OutputOfVideo(CallbackQuery callbackQuery)
        {

        }
    }
}
