﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot
{
    public class QuestionTester
    {
        public bool Test(QuestionTestPackage package)
        {
            return package.ExpectedOutput == Conversation.Parse(package.Input).IsQuestion;
        }
        public string TestArr(QuestionTestPackage[] packages)
        {
            string ret = "";
            Context output = new Context();
            int success = 0;
            for (int i = 0; i < packages.Length; i++)
            {
                output = Conversation.Parse(packages[i].Input);
                ret += $"\n\nTest Number {i + 1}: \n" +
                    $" \nInput: {packages[i].Input}\n" +
                    $"\nExpected Output: \n{packages[i].ExpectedOutput}\n" +
                    $"\nOutput: \n{output.IsQuestion}\n\n" +
                    $"\nTest Result: {(Test(packages[i]) ? "passed" : "failed")}" +
                    $"\n-------------------\n";
                if (Test(packages[i])) success++;
            }
            ret += $"Tests Passed: {success}";
            return ret;
        }
    }
    public class QuestionTestPackage
    {
        public string Input;
        public bool ExpectedOutput;
        
        public QuestionTestPackage() { }
        public QuestionTestPackage(string input, bool expectedOutput)
        {
            Input = input;
            ExpectedOutput = expectedOutput;
        }
    }
}
