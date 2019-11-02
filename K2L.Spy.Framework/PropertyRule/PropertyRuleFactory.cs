using SilkTest.Ntf;
using System;
using System.Collections.Generic;
using System.Linq;

namespace K2L.Spy.Framework.PropertyRule
{
    internal class PropertyRuleFactory
    {
        internal static List<ValueTypeArrayAbstract> GetValueTypeArrayRules(TestObject parentObject, string propertyValue, string propertyName)
        {
            var rules = new List<ValueTypeArrayAbstract>();
            foreach (var type in System.Reflection.Assembly.GetExecutingAssembly().GetTypes().Where(w => w.IsSubclassOf(typeof(ValueTypeArrayAbstract)) && !w.IsAbstract))
            {
                var instance = (ValueTypeArrayAbstract)Activator.CreateInstance(type, parentObject, propertyValue, propertyName);
                rules.Add(instance);
            }
            return rules;
        }

        //internal static List<GuiObjectTypeAbstract> GetGuiObjectTypeRules(TestObject parentObject, string propertyValue, string propertyName)
        //{
        //    var rules = new List<GuiObjectTypeAbstract>();
        //    foreach (var type in System.Reflection.Assembly.GetExecutingAssembly().GetTypes().Where(w => w.IsSubclassOf(typeof(GuiObjectTypeAbstract)) && !w.IsAbstract))
        //    {
        //        var instance = (GuiObjectTypeAbstract)Activator.CreateInstance(type, parentObject, propertyValue, propertyName);
        //        rules.Add(instance);
        //    }
        //    return rules;
        //}
    }
}