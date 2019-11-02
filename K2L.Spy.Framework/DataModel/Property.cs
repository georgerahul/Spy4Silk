using K2L.Spy.Framework.PropertyRule;
using SilkTest.Ntf;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;

namespace K2L.Spy.Framework.DataModel
{
    public class Property : PropertyBase
    {
        public Property(TestObject parentObject, string name) : base(name, parentObject.GetProperty(name))
        {
            ParentGuiElement = parentObject;
            CheckIsValueTypeArray();
            SetIsArrayList();
            PropertyState = PropertyState.NoChange;
        }

        public bool IsArrayList { get; private set; }
        public ObservableCollection<PropertyBase> GuiElements { get; private set; }
        public TestObject ParentGuiElement { get; private set; }
        public PropertyState PropertyState { get; set; }

        public void SetIsArrayList()
        {
            if (Value.Contains("ArrayList"))
            {
                var arrayValues = (_valueObject as ArrayList).ToArray();

                //Add count of elements in Array to the value.
                Value = Value + " [" + arrayValues.Count() + "]";

                GuiElements = new ObservableCollection<PropertyBase>();
                for (int i = 0; i < arrayValues.Count(); i++)
                {
                    GuiElements.Add(new PropertyBase("[" + i + "]", Name + "[" + i + "]", arrayValues[i]));
                }

                IsArrayList = true;
            }
        }

        private void CheckIsValueTypeArray()
        {
            foreach (var rule in PropertyRuleFactory.GetValueTypeArrayRules(ParentGuiElement, Value, Name))
            {
                if (rule.IsMatch())
                {
                    Value = rule.ConstructedValue();
                    break;
                }
            }
        }
    }

    public enum PropertyState
    {
        NoChange,
        NewlyAdded,
        Changed
    }
}