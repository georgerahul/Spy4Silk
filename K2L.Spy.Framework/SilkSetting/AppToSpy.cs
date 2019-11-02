using K2L.Spy.Framework.DataModel;
using SilkTest.Ntf;
using System;

namespace K2L.Spy.Framework.SilkSetting
{
    /// <summary>
    /// The class provides the application whihc will be used to spy.
    /// </summary>
    public class AppToSpy
    {
        #region Singleton

        private static readonly Lazy<AppToSpy> instance = new Lazy<AppToSpy>(() => new AppToSpy());

        public static AppToSpy Instance => instance.Value;

        private AppToSpy()
        { }

        #endregion Singleton

        private TestObject _application = null;
        private DesktopBaseState _baseState = null;

        public void SetApplication(DesktopBaseState baseState)
        {
            _baseState = baseState;
            _application = baseState.Application;
        }

        /// <summary> The test application. </summary>
        public TestObject Application
        {
            get
            {
                // If baseState is not assigned, get default baseState.
                if (_baseState == null)
                {
                    var state = new DefaultBaseState();
                    _baseState = state.GetDefaultBaseState();
                }

                // If no default BaseState, return null;
                if (_baseState == null)
                    return null;

                if (_application == null || !_application.Exists())
                {
                    //BaseState.Execute();
                    //Thread.Sleep(500);
                    _application = DesktopEnvt.Instance.Desktop.Find(_baseState.Locator);
                }
                return _application;
            }
        }
    }
}