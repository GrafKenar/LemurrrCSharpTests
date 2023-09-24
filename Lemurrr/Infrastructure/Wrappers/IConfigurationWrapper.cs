namespace Baucenter.Infrastructure.Wrappers;

public interface IConfigurationWrapper
{
    string? GetSectionValue(string key);
}
