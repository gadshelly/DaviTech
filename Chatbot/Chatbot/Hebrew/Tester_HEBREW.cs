using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot.Hebrew
{
    internal class Tester_HEBREW
    {
        public bool Test(TestPackage_HEBREW package)
        {
            return package.ExpectedOutput == Conversation.Parse(package.Input);
        }
        public string TestArr(TestPackage[] packages)
        {
            string ret = "";
            Context output = new Context();
            for (int i = 0; i < packages.Length; i++)
            {
                output = Conversation.Parse(packages[i].Input);
                ret += $"\n\nTest Number {i + 1}: \n" +
                    $" \nInput: {packages[i].Input}\n" +
                    $"\nExpected Output: \n{packages[i].ExpectedOutput}\n" +
                    $"\nOutput: \n{output}\n\n" +
                    $"\nTest Result: {output.ToString() == packages[i].ExpectedOutput.ToString()}" +
                    $"\n-------------------\n";
            }
            return ret;
        }
    }
    public class TestPackage_HEBREW
    {
        public string Input;
        public Context ExpectedOutput;
        public TestPackage_HEBREW(string input, Context expectedOutput)
        {
            Input = input;
            ExpectedOutput = expectedOutput;
        }
        public TestPackage_HEBREW() { }
        public override string ToString()
        {
            return $"ערך מועבר: {Input}\nערך יציאה מצופה: {ExpectedOutput.ToString()}";
        }
    }
}
