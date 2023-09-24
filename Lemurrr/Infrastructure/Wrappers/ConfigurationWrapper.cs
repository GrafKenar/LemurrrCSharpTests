using Microsoft.Extensions.Configuration;

namespace Baucenter.Infrastructure.Wrappers;

public class ConfigurationWrapper : IConfigurationWrapper
{
    private readonly IConfiguration _config;

    public ConfigurationWrapper(IConfiguration config)
    {
        _config = config;
    }

    public string? GetSectionValue(string key)
    {
        return _config.GetSection(key).Value;
    }
}
