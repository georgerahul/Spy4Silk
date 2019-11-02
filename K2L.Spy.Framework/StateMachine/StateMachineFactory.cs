namespace K2L.Spy.Framework.StateMachine
{
    public class StateMachineFactory
    {
        public static StateBase ConvertXpathToStates(string xPath)
        {
            int len = xPath.Length;
            StateBase state = null;

            var levels = xPath.Split('.');

            for (int i = 0; i < levels.Length; i++)
            {
                levels[i] = levels[i].Trim();
                StateBase newState = null;
                if (levels[i].Contains("/"))
                    newState = XPathProperty.Parser(levels[i]);
                else
                    if (levels[i].Contains("("))
                    newState = MethodObject.Parser(levels[i]);
                else
                    if (levels[i].Contains("["))
                    newState = ArrayListProperty.Parser(levels[i]);
                else
                    newState = DirectProperty.Parser(levels[i]);

                newState.Parent = state;
                state = newState;
            }

            return state;

            //for (int i = 0; i < len; i++)
            //{
            //    if(xPath[i]=='/' || i==0 )
            //    {
            //        int xPathStart = i;
            //        int xPathEnd = i;

            //        while (xPath[i] != '.' && i != len)
            //        {
            //        }
            //        xPathEnd = i-1;
            //        var value = xPath.Substring(xPathStart, xPathEnd- xPathStart);
            //        value = value.Trim('.', ' ');
            //        StateBase newState = new XPathProperty(value);
            //    }
            //    else
            //    {
            //    }
            //}
        }
    }
}