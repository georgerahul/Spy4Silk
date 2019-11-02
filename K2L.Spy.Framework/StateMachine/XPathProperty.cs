using K2L.Spy.Framework.SilkSetting;
using SilkTest.Ntf;
using System;

namespace K2L.Spy.Framework.StateMachine
{
    /// <summary> XPath Property Class. </summary>
    public class XPathProperty : StateBase
    {
        private const int TIMEOUT = 500;

        public static XPathProperty Parser(string content)
        {
            return new XPathProperty(content);
        }

        public XPathProperty(string xPath)
        {
            XPath = xPath;
        }

        public string XPath { get; set; }

        public override string GuiString => XPath;

        public override TestObject GetGuiObject()
        {
            try
            {
                TestObject propertyValue;
                if (Parent == null)
                    propertyValue = AppToSpy.Instance.Application.Find(XPath, new FindOptions(TIMEOUT));
                else
                    propertyValue = Parent.GetGuiObject().Find(XPath, new FindOptions(TIMEOUT));

                if (propertyValue is TestObject testObject)
                    return testObject;
                else
                {
                    Logger.Logger.GetLogger().WriteLog("Value of " + XPath + " is not TestObject.");
                    throw new Exception("Value of " + XPath + " is not TestObject.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.GetLogger().WriteLog(ex.ToString());

                throw new Exception(ex.Message);
                //return null;
            }
        }
    }
}