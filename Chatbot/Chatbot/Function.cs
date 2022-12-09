using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot
{
    public class Function
    {
        private bool TellingName = false;

        public bool UserKnowsName = false;
        public string UserName = "";
        public bool KnowsName => !string.IsNullOrEmpty(UserName);
        public string Answer(string unmodifiedText)
        {
            string lowerText = unmodifiedText.Trim().ToLower();

            //for(int i = 0; i < unlistedText.Length; i++)
            //{
            //    if(!char.IsLetterOrDigit(unlistedText[i]))
            //    {
            //        unlistedText = unlistedText.Replace(unlistedText[i], ' ');
            //    }
            //}

            //for (int i = 0; i < unlistedText.Length; i++)
            //{
            //    if (!char.IsLetterOrDigit(unlistedText[i]))
            //    {
            //        unlistedText.Replace(unlistedText[i], ' ');
            //    }
            //}

            char[] chars = lowerText.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (!(char.IsLetterOrDigit(chars[i])))
                {
                    chars[i] = ' ';
                }
            }

            string cleanText = new string(chars);
            List<string> words = new List<string>(cleanText.Split(' ', StringSplitOptions.RemoveEmptyEntries));

            bool isQuestion = false;



            for (int i = 0; i < words.Length; i++)
            {
                text.Add(words[i]);
            }

            if (lowerText.StartsWith("//")) return "Why did you write a comment? What are you trying to hide from me?";
            if (lowerText.EndsWith("!!!") || lowerText.ToUpper() == unmodifiedText) return "No need to yell, I understand you just fine.";
            if (lowerText == "hi" || lowerText == "hello") return "Hello";
            if (lowerText.EndsWith("s your name") || lowerText.EndsWith("s your name?"))
            {
                if (!KnowsName)
                {
                    TellingName = true;
                    UserKnowsName = true;
                    return "My name is Megabyte, what's yours?";
                }
                else return "My name is Megabyte.";
            }
            if(TellingName || lowerText.StartsWith("my name is ") || lowerText.StartsWith("my name s "))
            {
                lowerText = lowerText.Replace("?", "");
                lowerText = lowerText.Replace("my name is ", "");
                lowerText = lowerText.Replace("my name s ", "");
                lowerText = lowerText.Replace(",what is yours", "");
                lowerText = lowerText.Replace(",what s yours", "");
                UserName = lowerText;
                UserName.Replace(UserName[0], Char.ToUpper(UserName[0]));
                if (TellingName)
                {
                    TellingName = false;
                    return "Nice to meet you, " + UserName + ".";
                }
                else
                {
                    UserKnowsName = true;
                    return "Nice to meet you, " + UserName + ", My name is Megabyte.";
                }
            }
            if (lowerText.StartsWith("thanks") || lowerText.StartsWith("thank you")) return "Your welcome.";
            return "I don't understand you.";
        }
    }
}
