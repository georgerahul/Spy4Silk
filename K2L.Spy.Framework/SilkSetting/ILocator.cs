using K2L.Spy.Framework.DataModel;
using System.Collections.Generic;

namespace K2L.Spy.Framework.SilkSetting
{
    internal interface ILocator
    {
        List<SilkBaseState> GetLocators();
    }
}