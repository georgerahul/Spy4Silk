namespace K2L.Spy.Framework.MethodsRule
{
    public enum DataTypeSupported2
    {
        String, Int, IntArray, StringArray, Void, Bool, Object, ObjectArray
    }

    public enum DataTypeSupported
    {
        String, Int, ArrayList, Void, Bool, Object,
    }

    internal abstract class InvokableRuleAbstract
    {
        protected string _methodName;
        public abstract DataTypeSupported ReturnType { get; }

        public InvokableRuleAbstract(string methodName)
        {
            _methodName = methodName;
        }

        public abstract bool Match();
    }
}