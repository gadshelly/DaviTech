﻿using System;
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
            Context output = new Context();
            for(int i = 0; i < packages.Length; i++)
            {
                output = Conversation.Parse(packages[i].Input);
                ret += $"\n\nTest Number {i + 1}: \n" +
                    $" \nInput: {packages[i].Input}\n" +
                    $"\nExpected Output: \n{packages[i].ExpectedOutput}\n" +
                    $"\nOutput: \n{output}\n\n" +
                    $"\nTest Result: {(output.ToString() == packages[i].ExpectedOutput.ToString() ? "passed" : "failed")}" +
                    $"\n-------------------\n";
            }
            return ret;
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
