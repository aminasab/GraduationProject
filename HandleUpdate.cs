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
                await Worker.PrintMainMenuAsync(message);
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
            //Обработка вызовов из главного меню.
            if (callbackQuery.Data == "callBackOfTechnologist")
            {
                await Technologist.PrintMenuOfTechnologistAsync(callbackQuery);
            }
            if (callbackQuery.Data == "callBackOfSeamstress")
            {
                await Seamstress.PrintMenuOfSeamstressAsync(callbackQuery);
            }
            if (callbackQuery.Data == "callBackOfStudent")
            {
                await Student.PrintMenuOfStudentAsync(callbackQuery);
            }
            if (callbackQuery.Data == "callBackOfSeller")
            {
                await Seller.PrintMenuForSeller(callbackQuery);
            }
            if (callbackQuery.Data == "callbackOfMasterClass")
            {
                await Worker.OutputOfVideo(callbackQuery);
            }
            if (callbackQuery.Data == "exitToMainMenu")
            {
                await Worker.PrintMainMenuAsync(callbackQuery.Message!);
            }

            // Обработка вызовов выбора методов обработки одежды.
            if (callbackQuery.Data == "sundressForGirl")
            {
                await Worker.PrintInformationOfSundressAsync(callbackQuery);
            }
            if (callbackQuery.Data == "dressForGirl")
            {
                await Worker.PrintInformationOfDressAsync(callbackQuery);
            }
            if (callbackQuery.Data == "shirtForEcologist")
            {
                await Worker.PrintInformationOfShirtAsync(callbackQuery);
            }

            // Обработка вызовов выбора меню для продавца.
            if (callbackQuery.Data == "responsibilitiesOfSeller")
            {
                await Seller.PrintInformationAboutresponsibilitiesOfSeller(callbackQuery);
            }
            if (callbackQuery.Data == "rightsOfSeller")
            {
                await Seller.PrintInformationAboutRightsOfSeller(callbackQuery);
            }
            if (callbackQuery.Data == "responsibilityOfSeller")
            {
                await Seller.PrintInformationAboutResponsibilityOfSeller(callbackQuery);
            }

            // Обработка вызовов выбора меню для технолога.
            if (callbackQuery.Data == "jobDescription")
            {
                await Technologist.PrintMenuOfJobDescriptionOfTechnologist(callbackQuery);
            }
            if (callbackQuery.Data == "optimization")
            {
                await Technologist.PrintInformationAboutOptimization(callbackQuery);
            }
            if (callbackQuery.Data == "management")
            {
                await Technologist.PrintInformationaboutManagement(callbackQuery);
            }
            if (callbackQuery.Data == "backToMenuOfTechnologist")
            {
                await Technologist.PrintMenuOfTechnologistAsync(callbackQuery);
            }

            // Обработка нажатия кнопки "Должностная инструкция" технолога.
            if (callbackQuery.Data == "responsibilitiesOfTechnologist")
            {
                await Technologist.PrintResponsibilitiesOfTechnologist(callbackQuery);
            }
            if (callbackQuery.Data == "rightsOfTechnologist")
            {
                await Technologist.PrintRightsOfTechnologist(callbackQuery);
            }
            if (callbackQuery.Data == "responsibilityOfTechnologist")
            {
                await Technologist.PrintResponsibilityOfTechnologist(callbackQuery);
            }
            // Обработка вызова нажатия кнопки Студент/Швея из главного меню.
            if (callbackQuery.Data == "threadsAndNeedles")
            {
                await Worker.PrintInformationAboutThreadsAndNeedles(callbackQuery);
            }
            if (callbackQuery.Data == "tailoringOfSeamstress")
            {
                await Seamstress.PrintMenuOfClothesOfSeamstressAsync(callbackQuery);
            }
            if (callbackQuery.Data == "tailoringOfStudent")
            {
                await Student.PrintMenuOfClothesOfStudentAsync(callbackQuery);
            }
            if (callbackQuery.Data == "refuelingEquipment")
            {
                await Student.PrintMenuOfEquipmentAsync(callbackQuery);
            }
            if (callbackQuery.Data == "refuelingOfMachine")
            {
                await Student.OutputVideoOfMachine(callbackQuery);
            }
            if (callbackQuery.Data == "refuelingOverlock4")
            {
                await Student.OutputVideoOfOverlock4(callbackQuery);
            }
            if (callbackQuery.Data == "refuelingOverlock5")
            {
                await Student.OutputVideoOfOverlock5(callbackQuery);
            }
            if (callbackQuery.Data == "backToMenuOfSeamstress")
            {
                await Seamstress.PrintMenuOfSeamstressAsync(callbackQuery);
            }
            if (callbackQuery.Data == "backToMenuOfStudent")
            {
                await Student.PrintMenuOfStudentAsync(callbackQuery);
            }
        }
    }
}
