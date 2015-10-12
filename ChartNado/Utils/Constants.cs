namespace ChartNado.Utils
{
    using System;
    using System.Collections.ObjectModel;
    using System.Text;

    public static class Constants
    {
        public static class AppSettings
        {
            public static class DevMode
            {
                public static readonly string ConfigKeyName = "applicationdevmode";
                public static readonly string Dev = "dev";
                public static readonly string Prod = "prod";
                public static readonly string Test = "test";

                public static readonly ReadOnlyCollection<string> ValidValues =
                    new ReadOnlyCollection<string>(new[] {Dev, Prod, Test});

                public static readonly string InvalidConfigurationExceptionMessage =
                    new StringBuilder()
                        .AppendFormat("Invalid Configuration for Application {0} key.{1}", ConfigKeyName,
                            Environment.NewLine)
                        .AppendLine("Configuration is missing or the provided value is not valid.")
                        .AppendFormat("Valid values for {0} are: [{1}]", ConfigKeyName, ValidValues.ToString("|"))
                        .ToString();
            }
        }
    }
}