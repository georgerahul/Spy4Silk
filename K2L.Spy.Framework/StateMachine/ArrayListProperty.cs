using SilkTest.Ntf;
using System;
using System.Collections;

namespace K2L.Spy.Framework.StateMachine
{
    /// <summary> ArrayList Property Class. </summary>
    public class ArrayListProperty : StateBase
    {
        public static ArrayListProperty Parser(string xPath)
        {
            var content = xPath.Split('[', ']');

            if (content.Length == 3)
                return new ArrayListProperty(content[0], Convert.ToInt32(content[1]));
            else
                return null;
        }

        public ArrayListProperty(string propertyName, int index)
        {
            PropertyName = propertyName;
            Index = index;
        }

        public string PropertyName { get; set; }

        public int Index { get; set; }

        public override string GuiString => PropertyName + "[" + Index + "]";

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
                var arrayData = parentObject.GetProperty(PropertyName) as ArrayList;

                if (!(arrayData.Count > Index))
                {
                    Logger.Logger.GetLogger().WriteLog("Getting Property value of " + PropertyName + " at index '" + Index + "' failed.  Array data Count is:'" + arrayData.Count + "'.");
                    throw new Exception("Getting Property value of " + PropertyName + " at index '" + Index + "' failed.  Array data Count is:'" + arrayData.Count + "'.");
                    return null;
                }

                var arrayValues = arrayData[Index];

                if (arrayValues is TestObject testObject)
                    return testObject;
                else
                {
                    Logger.Logger.GetLogger().WriteLog("Property value of " + PropertyName + " [" + Index + "] is not TestObject.");
                    throw new Exception("Property value of " + PropertyName + " [" + Index + "] is not TestObject.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.GetLogger().WriteLog("Getting Property value of " + PropertyName + " as 'ArrayList' failed.");
                throw new Exception(ex.Message);
                return null;
            }
        }
    }
}