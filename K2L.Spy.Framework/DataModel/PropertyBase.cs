using SilkTest.Ntf;

namespace K2L.Spy.Framework.DataModel
{
    public class PropertyBase
    {
        protected object _valueObject = null;

        public string Name { get; private set; }
        public string Value { get; protected set; }
        public bool IsValueGuiObject { get; private set; }
        public TestObject GuiObjectValue { get; private set; }

        public string Relationship { get; private set; }

        public PropertyBase(string name, string relationship, object valueObject)
        {
            Relationship = relationship;
            Name = name;
            _valueObject = valueObject;
            Value = GetPropertyString();
            SetIsGuiObject();
        }

        public PropertyBase(string relationship, object valueObject)
        {
            Relationship = relationship;
            Name = Relationship;
            _valueObject = valueObject;
            Value = GetPropertyString();
            SetIsGuiObject();
        }

        private void SetIsGuiObject()
        {
            if (_valueObject is TestObject guiItem)
            {
                IsValueGuiObject = true;
                GuiObjectValue = guiItem;
            }
        }

        private string GetPropertyString()
        {
            try
            {
                return _valueObject.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}