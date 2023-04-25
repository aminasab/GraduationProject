using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace graduationProject
{
    internal class Seller
    {
        public static async Task PrintMenuForSeller(CallbackQuery callbackQuery)
        {
            var keyBoardMarkupOfSeller = new InlineKeyboardMarkup(new[]
            {
                new []{InlineKeyboardButton.WithCallbackData(text:"Должностные обязанности", "responsibilitiesOfSeller") },
                new []{InlineKeyboardButton.WithCallbackData(text: "Права продавца-консультанта", "rightsOfSeller") },
                new []{InlineKeyboardButton.WithCallbackData(text:"Ответственность", "responsibilityOfSeller") }
            }
            );
            await Program.bot.SendTextMessageAsync(
                callbackQuery.Message!.Chat.Id,
                "Выберите позицию",
                replyMarkup:keyBoardMarkupOfSeller);
        }
    }
}
