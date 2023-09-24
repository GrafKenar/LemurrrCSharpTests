using Baucenter.Infrastructure.Wrappers;
using Microsoft.Extensions.Configuration;

namespace Baucenter.Infrastructure;

public class AppSettings : IAppSettings
{
    private const string AppSettingsFileName = "appsettings.test.json";

    private const string BaseUrlSettingName = "BaseUrl";

    private const string LoginSettingName = "Login";

    private const string PasswordSettingName = "Password";

    private const string ScreenshotFolderSettingName = "ScreenshotFolderPath";

    private const string ScreenshotFileExtensionSettingName = "ScreenshotFileExtension";

    private static IConfigurationWrapper _config;

    public AppSettings()
    {
       IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(AppSettingsFileName)
                .Build();

       _config = new ConfigurationWrapper(config);
    }

    public Uri? GetBaseUri()
    {
        string uriValue = _config.GetSectionValue(BaseUrlSettingName);

        return string.IsNullOrEmpty(uriValue) ? null : new Uri(uriValue);
    }

    public string GetLogin()
    {
        return _config.GetSectionValue(LoginSettingName);
    }

    public string GetPassword()
    {
        return _config.GetSectionValue(PasswordSettingName);
    }

    public string GetScreenshotFolderPath()
    {
        return _config.GetSectionValue(ScreenshotFolderSettingName);
    }

    public string GetScreenshotFileExtension()
    {
        return _config.GetSectionValue(ScreenshotFileExtensionSettingName);
    }
}
