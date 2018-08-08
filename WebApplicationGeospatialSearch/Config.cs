using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationGeospatialSearch
{
    public static class Config
    {
        private static readonly Lazy<IConfiguration> Configuration = new Lazy<IConfiguration>(() =>
        {
            var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
           .AddEnvironmentVariables()
           .Build();

            return configuration;
        });

        public static T GetValue<T>(string key, T defaultValue)
        {
            try
            {
                Type tipo = typeof(T);
                if (IsSimple(tipo))
                {
                    var value = Configuration.Value[key];

                    if (value is null)
                    {
                        return defaultValue;
                    }
                    if (tipo == typeof(bool))
                    {
                        bool isTrue = "1".Equals(value, StringComparison.InvariantCultureIgnoreCase)
                                           || "true".Equals(value, StringComparison.InvariantCultureIgnoreCase)
                                           || "yes".Equals(value, StringComparison.InvariantCultureIgnoreCase);

                        return (T)Convert.ChangeType(isTrue, tipo);
                    }
                    return (T)Convert.ChangeType(value, tipo);
                }
                else
                {
                    var value = Activator.CreateInstance<T>();
                    Configuration.Value.GetSection(key).Bind(value);

                    return value;
                }
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        public static T GetValue<T>(string key)
        {
            return GetValue<T>(key, default(T));
        }

        private static bool IsSimple(Type tipo)
        {
            tipo = Nullable.GetUnderlyingType(tipo) ?? tipo;
            return tipo.IsPrimitive
                || tipo.IsEnum
                || tipo.Equals(typeof(Object))
                || tipo.Equals(typeof(DBNull))
                || tipo.Equals(typeof(Boolean))
                || tipo.Equals(typeof(Char))
                || tipo.Equals(typeof(SByte))
                || tipo.Equals(typeof(Byte))
                || tipo.Equals(typeof(Int16))
                || tipo.Equals(typeof(UInt16))
                || tipo.Equals(typeof(Int32))
                || tipo.Equals(typeof(UInt32))
                || tipo.Equals(typeof(Int64))
                || tipo.Equals(typeof(UInt64))
                || tipo.Equals(typeof(Single))
                || tipo.Equals(typeof(Double))
                || tipo.Equals(typeof(Decimal))
                || tipo.Equals(typeof(DateTime))
                || tipo.Equals(typeof(String));
        }
    }
}
