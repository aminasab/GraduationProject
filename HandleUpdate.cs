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
            // Обработка вызовов выбора методов обработки одежды.
            if (callbackQuery.Data== "sundressForGirl")
            {

            }
            if (callbackQuery.Data== "dressForGirl")
            {

            }
            if (callbackQuery.Data== "shirtForEcologist")
            {

            }
            // Обработка вызовов выбора меню для продавца.
            if (callbackQuery.Data== "responsibilitiesOfSeller")
            {

            }
            if (callbackQuery.Data== "rightsOfSeller")
            {

            }
            if(callbackQuery.Data== "responsibilityOfSeller")
            {

            }
            // Обработка вызовов выбора меню для технолога.
            if(callbackQuery.Data== "jobDescription")
            {

            }
            if (callbackQuery.Data== "optimization")
            {

            }
            if (callbackQuery.Data== "management")
            {

            }
            // Обработка нажатия кнопки "Должностная инструкция" технолога.
            if (callbackQuery.Data== "responsibilitiesOfTechnologist")
            {

            }
            if(callbackQuery.Data== "rightsOfTechnologist")
            {

            }
            if(callbackQuery.Data== "responsibilityOfTechnologist")
            {

            }
            // Обработка вызова нажатия кнопки Студент/Швея из главного меню.
            if (callbackQuery.Data== "threadsAndNeedles")
            {

            }
            if(callbackQuery.Data== "tailoring")
            {

            }
            if (callbackQuery.Data== "refuelingEquipment")
            {

            }
        }
    }
}
