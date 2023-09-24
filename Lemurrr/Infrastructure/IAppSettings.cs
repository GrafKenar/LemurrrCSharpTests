namespace Baucenter.Infrastructure.Wrappers;

public interface IAppSettings
{
    Uri? GetBaseUri();

    string? GetLogin();

    string? GetPassword();

    string? GetScreenshotFolderPath();

    string? GetScreenshotFileExtension();
}
