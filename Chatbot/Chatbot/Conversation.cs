﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatbot;
using System.IO;
using System.Text;

namespace Chatbot
{
    public class Conversation
    {
        public string UserName = "";
        public bool KnowsName => !string.IsNullOrEmpty(UserName);

        public static Context Parse(string originalText)
        {
            Context ret = new Context();

            ret.OriginalText = originalText;
            string lowerText = originalText.Trim().ToLower();
            char[] chars = lowerText.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (!(char.IsLetterOrDigit(chars[i])))
                {
                    chars[i] = ' ';
                }
            }
            string cleanText = new string(chars);
            cleanText = cleanText.Trim();

            if (cleanText.StartsWith("my name s")
                || cleanText.StartsWith("my name is ")) ret.TellingName = true;

            ret.CleanText = cleanText;

            if (lowerText.StartsWith("what") || lowerText.StartsWith("where ") || lowerText.StartsWith("why ") 
                || lowerText.StartsWith("who ") || lowerText.StartsWith("is ") || lowerText.StartsWith("am ")
                || lowerText.StartsWith("are ") || lowerText.StartsWith("do ") || lowerText.StartsWith("does ")
                || lowerText.StartsWith("did ") || lowerText.StartsWith("can ") || lowerText.StartsWith("was ")
                || lowerText.StartsWith("were ") || lowerText.StartsWith("will ") || lowerText.StartsWith("won ")
                || lowerText.StartsWith("whose ") || lowerText.StartsWith("had ") || lowerText.StartsWith("whose ")
                || lowerText.StartsWith("have ") || lowerText.StartsWith("when ") || lowerText.StartsWith("how")
                || lowerText.EndsWith('?')) ret.IsQuestion = true;

            ret.Words = new List<string>(cleanText.Split(' ', StringSplitOptions.RemoveEmptyEntries));

            return ret;
        }
        public string Answer(Context context)
        { 
            if(context.CleanText == "test")
            {
                string[] file = File.ReadAllText(
                    @"C:\Projects\gadshelly\DaviTech\Chatbot\Chatbot\SentencesTest.txt").Split("\r\n");
                int length = int.Parse(file[0]);
                TestPackage[] packages = new TestPackage[length];

                string input;
                Context expectedOutput = new Context();
                string[] contextFields;

                for (int i = 1; i <= length; i++)
                {
                    input = file[i].Split("//")[0];
                    contextFields = file[i].Split("//")[1].Split(',');
                    expectedOutput = new Context(new List<string>(contextFields[0].Split('+'))
                        , contextFields[1], contextFields[2], Convert.ToBoolean(int.Parse(contextFields[3]))
                        , Convert.ToBoolean(int.Parse(contextFields[4])));

                    packages[i - 1] = new TestPackage(input, expectedOutput);
                }

                Tester tester = new Tester();
                return tester.TestArr(packages);
            }

            if(context.CleanText == "qtest")
            {
                string[] file = File.ReadAllText(
    @"C:\Projects\gadshelly\DaviTech\Chatbot\Chatbot\QuestionsTest.txt").Split("\r\n");
                int length = int.Parse(file[0]);
                QuestionTestPackage[] packages = new QuestionTestPackage[length];

                for (int i = 1; i <= length; i++)
                {
                    packages[i - 1] = new QuestionTestPackage(file[i], true);
                }

                QuestionTester tester = new QuestionTester();
                return tester.TestArr(packages);
            }

            if (context.CleanText == "quit") return "quit";

            if (context.IsQuestion) return "Question detected. ";

            return "No question detected. ";
            //if (text.StartsWith("//")) return "Why did you write a comment?";
            //if (text == "hi" || text == "hello") return "Hello";
            //if (text.EndsWith("s your name") || text.EndsWith("s your name?"))
            //{
            //    if (!KnowsName)
            //    {
            //        TellingName = true;
            //        UserKnowsName = true;
            //        return "My name is Megabyte, what's yours?";
            //    }
            //    else return "My name is Megabyte.";
            //}
            //if(TellingName || text.StartsWith("my name is ") || text.StartsWith("my name s "))
            //{
            //    text = text.Replace("?", "");
            //    text = text.Replace("my name is ", "");
            //    text = text.Replace("my name s ", "");
            //    text = text.Replace(",what is yours", "");
            //    text = text.Replace(",what s yours", "");
            //    UserName = text;
            //    UserName.Replace(UserName[0], Char.ToUpper(UserName[0]));
            //    if (TellingName)
            //    {
            //        TellingName = false;
            //        return "Nice to meet you, " + UserName + ".";
            //    }
            //    else
            //    {
            //        UserKnowsName = true;
            //        return "Nice to meet you, " + UserName + ", My name is Megabyte.";
            //    }
            //}
            //if (text.StartsWith("thanks") || text.StartsWith("thank you")) return "Your welcome.";
        }
        public string Respond(string text)
        {
            Context context = Parse(text);
            return Answer(context);
        }
    }
}
