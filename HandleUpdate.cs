using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace graduationProject
{
    internal class HandleUpdate
    {
        /// <summary>
        /// Получение обновлений от пользователя.
        /// </summary>
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            try
            {
                if (update.Type == UpdateType.Message)
                {
                    await HandleMessage(
                    botClient, update.Message!);
                    return;
                }
                if (update.Type == UpdateType.CallbackQuery)
                {
                    await HandleButtonAsync(update.CallbackQuery!);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Обработка сообщений с текстом.
        /// </summary>
        public static async Task HandleMessage(ITelegramBotClient botClient, Message message)
        {
            if (message?.Text?.ToLower() == "/start" || message?.Text?.ToLower() == "начать")
            {
                await Workers.PrintMainMenuAsync(message);
            }
            else
            {
                await botClient.SendTextMessageAsync(
                    message!.Chat.Id,
                    "Введите- начать, чтобы продолжить пользование чат-ботом.");
            }
        }

        /// <summary>
        /// Получение ответа от Inline-кнопок.
        /// </summary>
        public static async Task HandleButtonAsync(CallbackQuery callbackQuery)
        {
            switch (callbackQuery.Data)
            {
                //Обработка вызовов из главного меню.
                case "callBackOfTechnologist":
                    await Technologist.PrintMenuOfTechnologistAsync(callbackQuery);
                    break;
                case "callBackOfSeamstress":
                    await Seamstress.PrintMenuOfSeamstressAsync(callbackQuery);
                    break;
                case "callBackOfStudent":
                    await Student.PrintMenuOfStudentAsync(callbackQuery);
                    break;
                case "callBackOfSeller":
                    await Seller.PrintMenuForSeller(callbackQuery);
                    break;
                case "exitToMainMenu":
                    await Workers.PrintMainMenuAsync(callbackQuery.Message!);
                    break;
                // Обработка вызовов выбора методов обработки одежды.
                case "sundressForGirl":
                    await Workers.PrintInformationOfSundressAsync(callbackQuery);
                    break;
                case "dressForGirl":
                    await Workers.PrintInformationOfDressAsync(callbackQuery);
                    break;
                case "shirtForEcologist":
                    await Workers.PrintInformationOfShirtAsync(callbackQuery);
                    break;
                // Обработка вызовов выбора меню для продавца.
                case "responsibilitiesOfSeller":
                    await Seller.PrintInformationAboutresponsibilitiesOfSeller(callbackQuery);
                    break;
                case "rightsOfSeller":
                    await Seller.PrintInformationAboutRightsOfSeller(callbackQuery);
                    break;
                case "responsibilityOfSeller":
                    await Seller.PrintInformationAboutResponsibilityOfSeller(callbackQuery);
                    break;
                // Обработка вызовов выбора меню для технолога.
                case "jobDescription":
                    await Technologist.PrintMenuOfJobDescriptionOfTechnologist(callbackQuery);
                    break;
                case "optimization":
                    await Technologist.PrintInformationAboutOptimization(callbackQuery);
                    break;
                case "management":
                    await Technologist.PrintInformationaboutManagement(callbackQuery);
                    break;
                case "backToMenuOfTechnologist":
                    await Technologist.PrintMenuOfTechnologistAsync(callbackQuery);
                    break;
                // Обработка нажатия кнопки "Должностная инструкция" технолога.
                case "responsibilitiesOfTechnologist":
                    await Technologist.PrintResponsibilitiesOfTechnologist(callbackQuery);
                    break;
                case "rightsOfTechnologist":
                    await Technologist.PrintRightsOfTechnologist(callbackQuery);
                    break;
                case "responsibilityOfTechnologist":
                    await Technologist.PrintResponsibilityOfTechnologist(callbackQuery);
                    break;
                // Обработка вызова нажатия кнопки Студент/Швея из главного меню.
                case "threadsAndNeedles":
                    await Workers.PrintInformationAboutThreadsAndNeedles(callbackQuery);
                    break;
                case "tailoringOfSeamstress":
                    await Seamstress.PrintMenuOfClothesOfSeamstressAsync(callbackQuery);
                    break;
                case "tailoringOfStudent":
                    await Student.PrintMenuOfClothesOfStudentAsync(callbackQuery);
                    break;
                case "refuelingEquipment":
                    await Student.PrintMenuOfEquipmentAsync(callbackQuery);
                    break;
                case "backToMenuOfSeamstress":
                    await Seamstress.PrintMenuOfSeamstressAsync(callbackQuery);
                    break;
                case "backToMenuOfStudent":
                    await Student.PrintMenuOfStudentAsync(callbackQuery);
                    break;
            }
        }
    }
}
