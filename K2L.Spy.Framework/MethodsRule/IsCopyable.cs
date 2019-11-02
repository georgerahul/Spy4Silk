namespace K2L.Spy.Framework.MethodsRule
{
    internal class IsCopyable : InvokableRuleAbstract
    {
        public IsCopyable(string methodName) : base(methodName)
        {
        }

        public override DataTypeSupported ReturnType => DataTypeSupported.String;

        public override bool Match() => _methodName.Contains("Copy") || _methodName.Contains("copy");
    }
}