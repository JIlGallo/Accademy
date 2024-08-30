using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ProgettoContatti.WebApp
{
    public static class Utility
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
              .GetMember(enumValue.ToString())
              .First()
              .GetCustomAttribute<DisplayAttribute>()
              ?.GetName();
        }
    }
}
