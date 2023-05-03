using Telegram.Bot.Types;

namespace graduationProject
{
    public delegate Task CallbackQueryDelegate(CallbackQuery callbackQuery);
    public static class DelegateOfCallBackInlineButton
    {
        public static CallbackQueryDelegate[] callbackDelegates ={
                Technologist.PrintMenuOfTechnologistAsync,
                Seamstress.PrintMenuOfSeamstressAsync,
                Student.PrintMenuOfStudentAsync,
                Seller.PrintMenuForSeller,
                Workers.PrintInformationOfSundressAsync,
                Workers.PrintInformationOfDressAsync,
                Workers.PrintInformationOfShirtAsync,
                Seller.PrintInformationAboutresponsibilitiesOfSeller,
                Seller.PrintInformationAboutRightsOfSeller,
                Seller.PrintInformationAboutResponsibilityOfSeller,
                Technologist.PrintMenuOfJobDescriptionOfTechnologist,
                Technologist.PrintInformationAboutOptimization,
                Technologist.PrintInformationaboutManagement,
                Technologist.PrintResponsibilitiesOfTechnologist,
                Technologist.PrintRightsOfTechnologist,
                Technologist.PrintResponsibilityOfTechnologist,
                Workers.PrintInformationAboutThreadsAndNeedles,
                Seamstress.PrintMenuOfClothesOfSeamstressAsync,
                Student.PrintMenuOfClothesOfStudentAsync,
                Student.PrintMenuOfEquipmentAsync
        };
    }
}
