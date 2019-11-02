using SilkTest.Ntf;

namespace K2L.Spy.Framework.PropertyRule
{
    internal abstract class ValueTypeArrayAbstract
    {
        protected TestObject _parentObject;
        protected string _propertyValue;
        protected string _propertyName;

        public ValueTypeArrayAbstract(TestObject parentObject, string propertyValue, string propertyName)
        {
            _parentObject = parentObject;
            _propertyValue = propertyValue;
            _propertyName = propertyName;
        }

        public abstract bool IsMatch();

        public abstract string ConstructedValue();
    }
}