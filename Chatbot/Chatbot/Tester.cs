using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot
{
    public class Tester
    {
        public bool Test(TestPackage package)
        {
            return package.ExpectedOutput == Conversation.Parse(package.Input);
        }
        public string TestArr(TestPackage[] packages)
        {
            string ret = "";
            for(int i = 0; i < packages.Length; i++)
            {
                ret += $"Test Number {i}: \nInput: {packages[i].Input}";
            }
        }
    }

    public class TestPackage
    {
        public string Input;
        public Context ExpectedOutput;
        public TestPackage(string input, Context expectedOutput)
        {
            Input = input;
            ExpectedOutput = expectedOutput;
        }
        public TestPackage() { }
        public override string ToString()
        {
            return $"Input: {Input}\nExpected Output: {ExpectedOutput.ToString()}";
        }
    }
}
