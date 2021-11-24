using OOup.Statuses;
using System.Text.RegularExpressions;

namespace OOup.Library
{
    public static class VariableLibrary
    {
        public static Variables Variables = new Variables();
        static Regex VariableRegex = new Regex(@"\[\%(.*)\%\]=(.*)");
        internal static void Parse(ExecuteStatus execStatus)
        {
            Parse(execStatus.Output.ToString());
        }

        internal static void Parse(string str)
        { 
            foreach (Match match in VariableRegex.Matches(str)) 
            {
                string variableName = match.Captures[0].Value;
                string variableValue = match.Captures[1].Value;
                Variables.Add(variableName, variableValue);
            }
        }
    }
}
