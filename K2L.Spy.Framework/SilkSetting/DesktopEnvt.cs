using SilkTest.Ntf;
using System;

namespace K2L.Spy.Framework.SilkSetting
{
    public class DesktopEnvt
    {
        #region Singleton

        private static readonly Lazy<DesktopEnvt> instance
            = new Lazy<DesktopEnvt>(() => new DesktopEnvt());

        public static DesktopEnvt Instance => instance.Value;

        private DesktopEnvt()
        {
        }

        ~DesktopEnvt()
        {
        }

        #endregion Singleton

        private Desktop _desktop = null;

        /// <summary> Provide the Silk desktop agent. </summary>
        internal Desktop Desktop
        {
            get
            {
                if (_desktop == null || !_desktop.Exists())
                    _desktop = Agent.Desktop;
                return _desktop;
            }
        }

        // Provide Website app link.
    }
}