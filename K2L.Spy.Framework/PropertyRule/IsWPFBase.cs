using SilkTest.Ntf;

namespace K2L.Spy.Framework.PropertyRule
{
    class IsWPFBase : GuiObjectTypeAbstract
    {
        public IsWPFBase(TestObject parentObject, string propertyValue, string propertyName) : base(parentObject, propertyValue, propertyName)
        {
        }

        public override bool Match() => _propertyValue.Contains("WPFBase");
    }
}
