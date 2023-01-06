using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot.Hebrew
{
    internal class QuestionTester_HEBREW
    {
        public bool Test(QuestionTestPackage_HEBREW package)
        {
            return package.ExpectedOutput == Conversation_HEBREW.Parse(package.Input).IsQuestion;
        }
        public string TestArr(QuestionTestPackage_HEBREW[] packages)
        {
            string ret = "";
            Context output = new Context();
            int success = 0;
            for (int i = 0; i < packages.Length; i++)
            {
                output = Conversation_HEBREW.Parse(packages[i].Input);
                ret += $"\n\nבדיקה מספר {i + 1}: \n" +
                    $" \nקלט: {packages[i].Input}\n" +
                    $"\nפלט מצופה: \n{packages[i].ExpectedOutput}\n" +
                    $"\nפלט: \n{output.IsQuestion}\n\n" +
                    $"\nתוצאת בדיקה: {(Test(packages[i]) ? "עבר" : "נכשל")}" +
                    $"\n-------------------\n";
                if (Test(packages[i])) success++;
            }
            ret += $"Tests Passed: {success}";
            return ret;
        }
    }
    public class QuestionTestPackage_HEBREW
    {
        public string Input;
        public bool ExpectedOutput;

        public QuestionTestPackage_HEBREW() { }
        public QuestionTestPackage_HEBREW(string input, bool expectedOutput)
        {
            Input = input;
            ExpectedOutput = expectedOutput;
        }
    }
}
