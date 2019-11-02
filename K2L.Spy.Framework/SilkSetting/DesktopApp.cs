using K2L.Spy.Framework.DataModel;
using SilkTest.Ntf;
using System;
using System.Collections.Generic;
using System.Linq;

namespace K2L.Spy.Framework.SilkSetting
{
    /// <summary>
    /// The Class will give all applications running or open in desktop.
    /// </summary>
    public class DesktopApp : ILocator
    {
        public List<SilkBaseState> GetLocators()
        {
            List<TestObject> applications = new List<TestObject>();

            foreach (var app in DesktopEnvt.Instance.Desktop.GetChildren())
            {
                try { applications.Add(app); }
                catch (Exception) { }
            }

            if (applications == null || applications.Count == 0)
                return null;

            var apps = applications
                .Select(s => new DesktopBaseState(s))
                .Cast<SilkBaseState>()
                .ToList();

            return apps;
        }
    }
}