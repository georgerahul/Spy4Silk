using K2L.Spy.Framework.MethodsRule;
using SilkTest.Ntf;
using System;

namespace K2L.Spy.Framework.StateMachine
{
    /// <summary> Method Object Class. </summary>
    public class MethodObject : StateBase
    {
        public static MethodObject Parser(string xPath)
        {
            var content = xPath.Split('(');

            var methodName = content[0];
            object[] parameters = MethodRuleFactory.ToParamters(content[1]);

            return new MethodObject(methodName, parameters);
        }

        public MethodObject(string methodName, params object[] parameters)
        {
            MethodName = methodName;
            Parameters = parameters;
        }

        public string MethodName { get; set; }

        public object[] Parameters { get; set; }

        public override string GuiString
        {
            get
            {
                string content = MethodName + "(";

                foreach (var par in Parameters)
                    content = content + par.ToString() + ", ";

                content = content.Trim();
                content = content.Trim(',');

                content = content + ")";

                return content;
            }
        }

        public override TestObject GetGuiObject()
        {
            var parentObject = Parent.GetGuiObject();
            if (parentObject == null)
            {
                Logger.Logger.GetLogger().WriteLog("Getting parent object failed.");
                throw new Exception("Getting parent object '" + Parent.ToString() + "' failed.");
            }

            try
            {
                var methodValue = parentObject.Invoke(MethodName, Parameters);

                if (methodValue is TestObject testObject)
                    return testObject;
                else
                {
                    Logger.Logger.GetLogger().WriteLog("Method Value of " + MethodName + " is not TestObject.");
                    throw new Exception("Method Value of " + MethodName + " is not TestObject.");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.GetLogger().WriteLog("Getting Method value of " + MethodName + " failed.");
                throw new Exception(ex.Message);
            }
        }
    }
}