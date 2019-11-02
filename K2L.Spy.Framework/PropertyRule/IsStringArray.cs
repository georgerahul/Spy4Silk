using SilkTest.Ntf;
using System.Text;

namespace K2L.Spy.Framework.PropertyRule
{
    internal class IsStringArray : ValueTypeArrayAbstract
    {
        public IsStringArray(TestObject parentObject, string propertyValue, string propertyName) : base(parentObject, propertyValue, propertyName)
        {
        }

        public override string ConstructedValue()
        {
            string[] data = (string[])_parentObject.GetProperty(_propertyName);
            var stringBuilder = new StringBuilder();
            foreach (var value in data)
            {
                stringBuilder.Append(value + ",");
            }
            var finalValue = stringBuilder.ToString();
            return finalValue.Remove(finalValue.Length - 1);
        }

        public override bool IsMatch() => _propertyValue.Contains("string[]") || _propertyValue.Contains("String[]");
    }
}