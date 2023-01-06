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
        public string TestArr(TestPackage_HEBREW[] packages)
        {
            string ret = "";
            Context output = new Context();
            for (int i = 0; i < packages.Length; i++)
            {
                output = Conversation_HEBREW.Parse(packages[i].Input);
                ret += $"\n\nבדיקה מספר {i + 1}: \n" +
                    $" \nקלט: {packages[i].Input}\n" +
                    $"\nפלט מצופה: \n{packages[i].ExpectedOutput}\n" +
                    $"\nפלט: \n{output}\n\n" +
                    $"\nתוצאת בדיקה: {(output.ToString() == packages[i].ExpectedOutput.ToString() ? "עבר" : "נכשל")}" +
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
            return $"קלט: {Input}\nפלט מצופה: {ExpectedOutput.ToString()}";
        }
    }
}
