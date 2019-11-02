using K2L.Spy.Framework.DataModel;
using K2L.Spy.Framework.Properties;

namespace K2L.Spy.Framework.SilkSetting
{
    /// <summary>
    /// Set the default base state.
    /// </summary>
    public class DefaultBaseState
    {
        public void SetDefaultBaseState(DesktopBaseState baseState)
        {
            Settings.Default.DefaultLocator = baseState.Locator;
            //set default from xml or json.
        }

        public DesktopBaseState GetDefaultBaseState()
        {
            //get default from xml or json.
            var value=Settings.Default.DefaultLocator;

            if (value == null || value.Trim() == string.Empty)
                return null;

            var baseState = new DesktopBaseState(value);
            return baseState;

        }
    }
}