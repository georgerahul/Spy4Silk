using K2L.Spy.Framework.DataModel;
using K2L.Spy.Framework.MethodsRule;
using K2L.Spy.Framework.StateMachine;
using SilkTest.Ntf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace K2L.Spy.Framework
{
    public class Analyzer
    {
        public Analyzer(string xpath)
        {
            XPath = xpath;
            ObjectUnderAnalyzsis = null;
            try
            {
                ErrorDetails = string.Empty;
                State = StateMachineFactory.ConvertXpathToStates(xpath);
                if (State == null)
                    Logger.Logger.GetLogger().WriteLog($"Unable to find the '" + xpath + "' object.");
                else
                    ObjectUnderAnalyzsis = State.GetGuiObject();

                if (ObjectUnderAnalyzsis == null)
                    ErrorDetails = "Unable to find the '" + xpath + "' object.";
            }
            catch (Exception ex)
            {
                ErrorDetails = ex.Message;
                Logger.Logger.GetLogger().WriteLog($"{ex.StackTrace}");
                Logger.Logger.GetLogger().WriteLog($"Unable to find the '" + xpath + "' object.");
            }
        }

        public Analyzer(TestObject controlObject)
        {
            ObjectUnderAnalyzsis = controlObject;
            XPath = ObjectUnderAnalyzsis.ToString();
        }

        public string XPath { get; private set; }

        public StateBase State { get; set; }

        public TestObject ObjectUnderAnalyzsis { get; private set; }

        private string ProcessXPath(string xpath)
        {
            //if(xpath.Substring(0,17) == "OptoLyzer Studio.")
            if (xpath.Contains("OptoLyzer Studio."))
            {
                return xpath.Remove(0, 17);
            }
            return xpath;
        }

        public List<DynamicMethod> GetMethods()
        {
            var dynamicMethods = new List<DynamicMethod>();
            foreach (var item in ObjectUnderAnalyzsis.GetDynamicMethodList())
                dynamicMethods.Add(new DynamicMethod(ObjectUnderAnalyzsis, item));
            return dynamicMethods;
        }

        public List<Property> GetProperties()
        {
            var propertyModel = new List<Property>();
            var properties = ObjectUnderAnalyzsis.GetPropertyList();
            //var guiObject = new GuiObject(ObjectUnderAnalyzsis);

            foreach (var property in properties)
            {
                var prop = new Property(ObjectUnderAnalyzsis, property);
                propertyModel.Add(prop);
            }
            return propertyModel;
        }

        private void ArrayAction(string property, TestObject testObject, ref ObservableCollection<Property> propertiesModel)
        {
            throw new NotImplementedException();
        }

        public StateBase GuiState { get; private set; }

        private void ConvertXpathToState(string xpath)
        {
        }

        public string ErrorDetails { get; private set; }

        public MethodResult ExecuteMethod(DynamicMethod method, string parameterString)
        {
            object[] parameters = MethodRuleFactory.ToParamters(parameterString);
            return new MethodResult(method, parameterString, ObjectUnderAnalyzsis.Invoke(method.MethodName, parameters));
        }
    }
}