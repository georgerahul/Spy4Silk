using SilkTest.Ntf;
using System;
using System.Text;

namespace K2L.Spy.Framework.PropertyRule
{
    internal class IsInt32Array : ValueTypeArrayAbstract
    {
        public IsInt32Array(TestObject parentObject, string propertyValue, string propertyName) : base(parentObject, propertyValue, propertyName)
        {
        }

        public override bool IsMatch() =>
            _propertyValue.Contains("Int32[]");

        public override string ConstructedValue()
        {
            Int32[] data = (Int32[])_parentObject.GetProperty(_propertyName);
            var stringBuilder = new StringBuilder();
            foreach (var value in data)
            {
                stringBuilder.Append(value + ",");
            }
            var finalValue = stringBuilder.ToString();
            return finalValue.Remove(finalValue.Length - 1);
        }
    }
}