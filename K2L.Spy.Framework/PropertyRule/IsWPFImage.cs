using SilkTest.Ntf;

namespace K2L.Spy.Framework.PropertyRule
{
    class IsWPFImage : GuiObjectTypeAbstract
    {
        public IsWPFImage(TestObject parentObject, string propertyValue, string propertyName) : base(parentObject, propertyValue, propertyName)
        {
        }

        public override bool Match() => _propertyValue.Contains("WPFImage");
    }
}
