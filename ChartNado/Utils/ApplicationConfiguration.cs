namespace ChartNado.Utils
{
    using System.Web.Configuration;
    using Exceptions;

    public static class ApplicationConfiguration
    {
        public static ApplicationDevModeEnum ApplicationMode
        {
            get
            {
                var configVal = WebConfigurationManager.AppSettings[Constants.AppSettings.DevMode.ConfigKeyName];
                var isValid = !string.IsNullOrWhiteSpace(configVal) &&
                              Constants.AppSettings.DevMode.ValidValues.Contains(configVal);
                if (!isValid)
                {
                    throw new InvalidConfigurationException(
                        Constants.AppSettings.DevMode.InvalidConfigurationExceptionMessage);
                }
                return configVal.ToEnum(ApplicationDevModeEnum.Dev);
            }
        }
    }
}