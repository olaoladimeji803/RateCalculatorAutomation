using System;
using NUnit.Framework;

namespace SpecflowTestAutomation
{
    public class EnvironmentData
    {
        public static string baseUrl { get; } = TestContext.Parameters["baseUrl"];
        public static string browser { get; } = TestContext.Parameters["browser"];
        public static string setRateBaseUrl { get; } = TestContext.Parameters["setRateBaseUrl"];
    }
}
