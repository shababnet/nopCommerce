using Nop.Core;
using Nop.Core.Domain.Localization;
using Nop.Core.Infrastructure;
using Nop.Services.Localization;
using System.IO;
using System.Linq;


namespace Nop.Services.Installation
{
    public partial class CodeFirstInstallationService : IInstallationService
    {
        void IInstallationService.InstallData(string defaultUserEmail, string defaultUserPassword, bool installSampleData)
        {
            this.InstallData(defaultUserEmail, defaultUserPassword, installSampleData);
            InstalArabicLanage();

        }


        private void InstalArabicLanage()
        {

            var language = new Language
            {
                Name = "اللغة العربية",
                LanguageCulture = "ar-KW",
                UniqueSeoCode = "ar",
                FlagImageFileName = "kw.png",
                Published = true,
                DisplayOrder = 2,
                Rtl = true
            };
            _languageRepository.Insert(language);

            //'Arabic' language
            var arlanguage = _languageRepository.Table.Single(l => l.Name == "اللغة العربية");

            //save resoureces
            foreach (var filePath in System.IO.Directory.EnumerateFiles(CommonHelper.MapPath("~/SimGateCo/App_Data/Localization/ar/"), "*.xml", SearchOption.TopDirectoryOnly))
            {
                var localesXml = File.ReadAllText(filePath);
                var localizationService = EngineContext.Current.Resolve<ILocalizationService>();
                localizationService.ImportResourcesFromXml(language, localesXml);

            }
        }


    }
}
