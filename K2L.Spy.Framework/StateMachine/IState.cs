using SilkTest.Ntf;

namespace K2L.Spy.Framework.StateMachine
{
    internal interface IState
    {
        IState Prev { get; set; }

        TestObject GetGuiObject(TestObject parent);

        string ToString();
    }

    public abstract class StateBase //: IState
    {
        public const string SEPERATOR = ".";

        //protected TestObject _prevObject;
        public virtual StateBase Parent { get; set; }

        public abstract TestObject GetGuiObject();

        public abstract string GuiString { get; }

        public override string ToString()
        {
            string path = string.Empty;
            if (Parent != null)
                path = Parent.ToString() + SEPERATOR;

            path = path + GuiString;

            return path;
        }
    }

    public enum StateType
    {
        ArrayListProperty,
        DirectProperty,
        MethodValue,
        TestObject,
    }
}