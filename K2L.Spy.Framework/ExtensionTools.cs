using SilkTest.Ntf;
using SilkTest.Ntf.Wpf;
using System;

namespace K2L.Spy.Framework
{
    public static class ExtensionTools
    {
        public static void ClickObject(this TestObject guiObject)
        {
            try
            {
                (guiObject as WPFBase).Click();
            }
            catch (Exception ex)
            {
                Logger.Logger.GetLogger().WriteLog(ex.StackTrace);
            }
        }

        /// <summary>
        /// Get the value in <see cref="System.ComponentModel.DefaultValueAttribute"/> declared for the enum values.
        /// </summary>
        /// <param name="enumValue"><see cref="Enum"/></param>
        /// <returns>A String.</returns>
        public static string GetEnumSystemDefaultValue(this Enum enumValue)
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());
            if (field == null)
                return enumValue.ToString();
            var attributes = field.GetCustomAttributes(typeof(System.ComponentModel.DefaultValueAttribute), false);
            return attributes.Length == 0 ? enumValue.ToString() : ((System.ComponentModel.DefaultValueAttribute)attributes[0]).Value.ToString();
        }
    }
}