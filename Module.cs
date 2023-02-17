using Gems.Client;
using System.Collections.Generic;

namespace Gems.Enterprise.WebApp.FirstApplication
{
    /// <summary>
    /// Class defining a Gems web app plugin backend
    /// </summary>
    public class Module : GemsModuleBase
    {
        /// <summary>
        /// This method is called by the framework to allow services to be registered
        /// </summary>
        /// <param name="webApplicationBuilder">Builder for web applications and services</param>
        /// <param name="configuration">Represents a set of key/value application configuration properties</param>
        /// <param name="bootstrapLogger">Not for developer use. For framework use only</param>
        public override void ConfigureServices(WebApplicationBuilder webApplicationBuilder, IConfiguration configuration, ILogger? bootstrapLogger)
        {
            // Add services here. 
        }

        /// <summary>
        /// This method is called by the framework after ConfigureServices is called to allow configuration of services
        /// </summary>
        /// <param name="webApplication">The web application used to configure the HTTP pipeline, and routes</param>
        public override void Configure(WebApplication webApplication)
        {
            // Configure services here
        }

        /// <summary>
        ///  This method is called by the framework when the module is first loaded to register the web app within the plugin.
        /// </summary>
        /// <returns>Web app to be registered</returns>
        public override Client.WebApp RegisterWebApp()
        {
            // There should not be a need to modify the template generated properties in this definition
            var webApp = new Client.WebApp()
            {
                // Globally unique identifier i.e. gems-edge-gproduction-corrections
                ID = "gems-enterprise-gproduction-GemsEnterpriseApp",

                // Untranslated product name
                Name = "Gems Enterprise App",

                // Name of page that is the web app entry point. Must match the web app ID !!
                URL = "gems-enterprise-gproduction-GemsEnterpriseApp",

                // name must be one of gproduction, gtools, or guptime
                Category = "gproduction"
            };


            // Add additional definitions as needed

            webApp.Description.Add("EN_en", "This is an english description");
            webApp.Description.Add("DE_de", "This is an german description");

            webApp.IconResource.Add("gems-light", "/images/gems-light/app.icon.jpg");
            webApp.IconResource.Add("gems-dark", "images/gems_dark/app.icon.jpg");
            webApp.IconResource.Add("cameleon", "images/cameleon/app.icon.jpg");

            webApp.SupportedUserRoles.Add("gems-enterprise-gproduction-GemsEnterpriseApp");
            webApp.SupportedUserRoles.Add("user");

            return webApp;
        }

        /// <summary>
        /// This method is called by the framework when the module is first loaded to get the web app page documentation within the plugin
        /// </summary>
        /// <returns>Page documentation set for the plugin where keys are well known language identifiers</returns>
        public override Dictionary<string, PageDocumentation> GetWebAppPageDocumentation()
        {
            // Add documentation references for @page gems-enterprise-gproduction-GemsEnterpriseApp in MainPage.razor for english and german
            var pageDocSet = new Dictionary<string, PageDocumentation>();

            var englishPageDocs = new PageDocumentation();

            // Set english display names for pages for use in breadcrumbs
            englishPageDocs.DisplayNames.Add("gems-enterprise-gproduction-GemsEnterpriseApp", "Main");
            englishPageDocs.DisplayNames.Add("SecondPage", "Second Page");
            englishPageDocs.DisplayNames.Add("ThirdPage", "Third Page");

            // Set english help markdown references for pages
            englishPageDocs.References.Add("gems-enterprise-gproduction-GemsEnterpriseApp", "docs/Main.EN_en.md");
            englishPageDocs.References.Add("SecondPage", "docs/Main.EN_en.md");
            englishPageDocs.References.Add("ThirdPage", "docs/Main.EN_en.md");

            pageDocSet.Add("EN_en", englishPageDocs);

            var germanPageDocs = new PageDocumentation();

            // Set german display names for pages for use in breadcrumbs
            germanPageDocs.DisplayNames.Add("gems-enterprise-gproduction-GemsEnterpriseApp", "Primär");
            germanPageDocs.DisplayNames.Add("SecondPage", "Zweite Seite");
            germanPageDocs.DisplayNames.Add("ThirdPage", "Dritte Seite");

            // Set german help markdown references for pages
            germanPageDocs.References.Add("gems-enterprise-gproduction-GemsEnterpriseApp", "docs/Main.DE_de.md");
            germanPageDocs.References.Add("SecondPage", "docs/Main.DE_de.md");
            germanPageDocs.References.Add("ThirdPage", "docs/Main.DE_de.md");

            pageDocSet.Add("DE_de", germanPageDocs);

            // Add additional page documentation for other languages

            return pageDocSet;
        }

        /// <summary>
        /// This method is called by the framework when the module is first loaded to get the web app string translations within the plugin
        /// </summary>
        /// <returns>Translations where outer dictionary keys are well known language identifiers and each value is a dictionary whose 
        /// keys are well known string identifiers (or mnemonics) and the values are the human readble translations</returns>
        public override Dictionary<string, Dictionary<string, string>> GetWebAppTranslations()
        {
            var translations = new Dictionary<string, Dictionary<string, string>>();

            // Add dictionaries for all supported languages
            translations.Add("EN_en", new Dictionary<string, string>());
            translations.Add("DE_de", new Dictionary<string, string>());

            // Add english translations for main page 
            translations["EN_en"].Add("main-page-title", "Welcome to the Gems Enterprise App App");
            translations["EN_en"].Add("main-page-prompt", "Go to page two");

            // Add german translations for main page
            translations["DE_de"].Add("main-page-title", "Willkommen bei der Gems Enterprise App App");
            translations["DE_de"].Add("main-page-prompt", "Gehe zu Seite zwei");


            // Add english translations for page two 
            translations["EN_en"].Add("page-two-title", "This is page two");
            translations["EN_en"].Add("page-two-prompt", "Go to page three");

            // Add german translations for page two
            translations["DE_de"].Add("page-two-title", "Dies ist Seite zwei");
            translations["DE_de"].Add("page-two-prompt", "Gehe zu Seite drei");


            // Add english translations for page three 
            translations["EN_en"].Add("page-three-title", "This is page three");
            translations["EN_en"].Add("page-three-prompt", "Go to main page");

            // Add german translations for page three 
            translations["DE_de"].Add("page-three-title", "Dies ist Seite drei");
            translations["DE_de"].Add("page-three-prompt", "zur Hauptseite");

            return translations;
        }

        /// <summary>
        /// This method is called by the framework when the module is first loaded to get the web app session to use in development mode
        /// </summary>
        /// <returns>Web app session object</returns>
        public override WebAppSession GetDevelopmentWebAppSession()
        {
            var hostName = Environment.MachineName;

            var session = new WebAppSession()
            {
                ClassName = "AssetObject",
                ClientToken = hostName,
                UserName = Environment.UserName
            };

            session.IDs.Add(hostName);
            session.Roles.Add("user");
            session.Permissions.Add("open-files");

            session.Breadcrumbs.Add(new Breadcrumb() { DisplayName = "we" });
            session.Breadcrumbs.Add(new Breadcrumb() { DisplayName = "come" });
            session.Breadcrumbs.Add(new Breadcrumb() { DisplayName = "in" });
            session.Breadcrumbs.Add(new Breadcrumb() { DisplayName = "peace" });

            session.WebAppDisplaySettings.ID = hostName;
            session.WebAppDisplaySettings.Theme = "gems-dark";
            session.WebAppDisplaySettings.Language = "EN_en";
            session.WebAppDisplaySettings.Units = "metric";

            return session;
        }
    }
}