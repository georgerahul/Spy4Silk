using System;
using System.Collections.Generic;
using System.Linq;

namespace K2L.Spy.Framework.MethodsRule
{
    internal class MethodRuleFactory
    {
        internal static List<InvokableRuleAbstract> GetValueTypeArrayRules(string methodName)
        {
            var rules = new List<InvokableRuleAbstract>();
            foreach (var type in System.Reflection.Assembly.GetExecutingAssembly().GetTypes().Where(w => w.IsSubclassOf(typeof(InvokableRuleAbstract)) && !w.IsAbstract))
            {
                var instance = (InvokableRuleAbstract)Activator.CreateInstance(type, methodName);
                rules.Add(instance);
            }
            return rules;
        }

        internal static object[] ToParamters(string parameter)
        {
            parameter = parameter.Trim().Trim('(', ')').Trim();

            // If no parameters.
            if (parameter == string.Empty)
            {
                return null;
            }

            var content = parameter.Split(',');
            object[] parameters = new object[content.Length];

            // Supported parameter types: Boolean, Int, Double, string.
            for (int i = 0; i < content.Length; i++)
            {
                content[i] = content[i].Trim();

                if (content[i].Contains("\'"))
                    parameters[i] = content[i].Trim('\'');
                else
                    if (content[i].Contains("\""))
                    parameters[i] = content[i].Trim('\"');
                else
                    if (content[i].Contains(".")) // Fix this. Not a good way.
                    parameters[i] = Convert.ToDouble(content[i]);
                else
                    if (content[i].ToLower().Equals("false") || content[i].ToLower().Equals("true"))
                    parameters[i] = Convert.ToBoolean(content[i]);
                else
                    if (content[i].All(char.IsNumber))
                    parameters[i] = Convert.ToInt32(content[i]);
                else
                    throw new Exception(" The parameter '" + parameters[i] + "' could not be parsed to any specific value.");
            }

            return parameters;
        }
    }
}