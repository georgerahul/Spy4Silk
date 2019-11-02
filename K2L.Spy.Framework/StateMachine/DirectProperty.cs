using SilkTest.Ntf;
using System;

namespace K2L.Spy.Framework.StateMachine
{
    /// <summary> Direct Property Class. </summary>
    public class DirectProperty : StateBase
    {
        public static DirectProperty Parser(string content)
        {
            return new DirectProperty(content);
        }

        public DirectProperty(string propertyName)
        {
            PropertyName = propertyName;
        }

        public string PropertyName { get; set; }

        public override string GuiString => PropertyName;

        public override TestObject GetGuiObject()
        {
            var parentObject = Parent.GetGuiObject();
            if (parentObject == null)
            {
                Logger.Logger.GetLogger().WriteLog("Getting parent object failed.");
                throw new Exception("Getting parent object '" + Parent.ToString() + "' failed.");
                return null;
            }

            try
            {
                var propertyValue = parentObject.GetProperty(PropertyName);

                if (propertyValue is TestObject testObject)
                    return testObject;
                else
                {
                    Logger.Logger.GetLogger().WriteLog("Property value of " + PropertyName + " is not TestObject.");
                    throw new Exception("Property value of '" + PropertyName + "' is not TestObject.");
                    //return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.GetLogger().WriteLog("Getting Property value of " + PropertyName + " failed.");
                throw new Exception(ex.Message);
                //return null;
            }
        }
    }
}