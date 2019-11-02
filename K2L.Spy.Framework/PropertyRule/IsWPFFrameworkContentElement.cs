using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SilkTest.Ntf;

namespace K2L.Spy.Framework.PropertyRule
{
    class IsWPFFrameworkContentElement : GuiObjectTypeAbstract
    {
        public IsWPFFrameworkContentElement(TestObject parentObject, string propertyValue, string propertyName) : base(parentObject, propertyValue, propertyName)
        {
        }

        public override bool Match()=> _propertyValue.Contains("WPFFrameworkContentElement");
    }
}
