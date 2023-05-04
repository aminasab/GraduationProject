using Telegram.Bot.Types;

namespace graduationProject
{
    public delegate Task CallbackQueryDelegate(CallbackQuery callbackQuery);
    public class DelegateOfCallBackInlineButton
    {
        static readonly CallbackQueryDelegate[] _callbackDelegates ={
                // Технолог.
                Technologist.PrintMenuOfTechnologistAsync,
                Technologist.PrintMenuOfJobDescriptionOfTechnologistAsync,
                Technologist.PrintInformationAboutOptimizationAsync,
                Technologist.PrintInformationaboutManagementAsync,
                Technologist.PrintResponsibilitiesOfTechnologistAsync,
                Technologist.PrintRightsOfTechnologistAsync,
                Technologist.PrintResponsibilityOfTechnologistAsync,
                // Швея.
                Seamstress.PrintMenuOfSeamstressAsync,
                Seamstress.PrintMenuOfClothesOfSeamstressAsync,
                // Продавец.
                Seller.PrintMenuForSellerAsync,
                Seller.PrintInformationAboutresponsibilitiesOfSellerAsync,
                Seller.PrintInformationAboutRightsOfSellerAsync,
                Seller.PrintInformationAboutResponsibilityOfSellerAsync,
                Worker.PrintInformationAboutThreadsAndNeedlesAsync,
                Worker.PrintInformationOfSundressAsync,
                Worker.PrintInformationOfDressAsync,
                Worker.PrintInformationOfShirtAsync,
                // Студент.
                Student.PrintMenuOfStudentAsync,
                Student.PrintMenuOfClothesOfStudentAsync,
                Student.PrintMenuOfEquipmentAsync
        };
        public static CallbackQueryDelegate[] CallbackDelegates
        {
            get
            {
                return _callbackDelegates;
            }
        }

    }
}
