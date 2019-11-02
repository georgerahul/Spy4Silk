using K2L.Spy.Framework.DataModel;
using SilkTest.Ntf;

namespace K2L.Spy.Framework.PropertyRule
{
    abstract class GuiObjectTypeAbstract
    {
        protected TestObject _parentObject;
        protected string _propertyValue;
        protected string _propertyName;
        public GuiObjectTypeAbstract(TestObject parentObject, string propertyValue, string propertyName)
        {
            _parentObject = parentObject;
            _propertyValue = propertyValue;
            _propertyName = propertyName;
        }
        public GuiObject GetGuiElement() => new GuiObject(_parentObject.GetProperty(_propertyName) as TestObject);
        public abstract bool Match();
    }
}
