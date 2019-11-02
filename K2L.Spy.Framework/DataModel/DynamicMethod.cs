using K2L.Spy.Framework.MethodsRule;
using SilkTest.Ntf;
using System.Collections;
using System.Threading.Tasks;

namespace K2L.Spy.Framework.DataModel
{
    public class DynamicMethod
    {
        public string Name { get; private set; }
        public string InvokableText => Invokable.ToString();
        public bool Invokable { get; private set; }
        public TestObject ParentElement { get; private set; }

        //public DataTypeSupported ReturnType { get; private set; }
        //public DataTypeSupported[] Parameters { get; private set; }
        //public string ReturnTypeName => ReturnType.GetEnumSystemDefaultValue();

        public string MethodName { get; private set; }
        public bool IsReturn { get; set; }
        public string ReturnValue { get; set; }
        public string[] Parameters { get; private set; }

        public DynamicMethod(TestObject testObject, string name)
        {
            ParentElement = testObject;
            Name = name;
            Invokable = true;
            //CheckInvokability();
            GetNameReturnAndParamterDetails();
        }

        private void CheckInvokability()
        {
            var rules = MethodRuleFactory.GetValueTypeArrayRules(Name);
            foreach (var rule in rules)
            {
                Invokable = rule.Match();
                if (Invokable)
                {
                    //ReturnType = rule.ReturnType;
                    break;
                }
            }
        }

        private void GetNameReturnAndParamterDetails()
        {
            Name = Name.Trim();
            Task.Run(() =>
            {
                // Return MethodName and paramter1, parmeter2 etc.
                var divideMethod = Name.Split('(');
                divideMethod[1] = divideMethod[1].Trim(')').Trim();

                // Return and MethodName
                var splitFirst = divideMethod[0].Split(' ');

                // Get Return value and methodName.
                if (splitFirst.Length == 2)
                {
                    IsReturn = true;
                    ReturnValue = splitFirst[0];
                    MethodName = splitFirst[1];
                }
                else
                {
                    IsReturn = false;
                    ReturnValue = string.Empty;
                    MethodName = splitFirst[0];
                }

                if (divideMethod[1] == string.Empty)
                {
                    Parameters = new string[0];
                }
                else
                {
                    var parameters = divideMethod[1].Split(',');
                    Parameters = new string[parameters.Length];
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Split(' ')[0];
                    }
                }
            });
        }
    }

    public class MethodResult
    {
        public object Result { get; private set; }

        public bool IsGuiObject { get; private set; }

        public bool IsNull { get; private set; }

        public bool IsArrayList { get; private set; }

        public string Relationship { get; private set; }

        public override string ToString()
        {
            if (IsNull == true)
                return "NULL";

            if (IsArrayList == true)
            {
                string result = "ArrayList: ";
                var value = Result as ArrayList;
                for (int i = 0; i < value.Count; i++)
                {
                    result += value[i].ToString() + ", ";
                }
                return result.TrimEnd(' ').TrimEnd(',');
            }

            return Result.GetType().ToString() + ": " + Result.ToString();
        }

        public MethodResult(DynamicMethod method, string parameter, object result)
        {
            Relationship = method.MethodName + "(" + parameter + ")";
            Result = result;
            IsNull = false;
            IsArrayList = false;
            IsGuiObject = false;

            if (result == null)
                IsNull = true;
            else
            {
                if (result is TestObject)
                    IsGuiObject = true;
                else if (result is ArrayList)
                    IsArrayList = true;
            }
        }
    }
}